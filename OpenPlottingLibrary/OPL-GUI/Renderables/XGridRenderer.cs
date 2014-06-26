using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using OpenPlottingLibrary;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OPL_GUI.Renderables
{
    public class XGridRenderer : IRenderable
    {
        private readonly List<Point3D> _points;
        string vertexShaderSource = @"
            #version 140
 
            // object space to camera space transformation
            uniform mat4 modelview_matrix;            
 
            // camera space to clip coordinates
            uniform mat4 projection_matrix;

            // incoming vertex position
            in vec3 vertex_position;
 
            // incoming vertex normal
            in vec3 vertex_normal;
 
            // transformed vertex normal
            out vec3 normal;
 
            void main(void)
            {
              //not a proper transformation if modelview_matrix involves non-uniform scaling
              normal = ( modelview_matrix * vec4( vertex_normal, 0 ) ).xyz;
 
              // transforming the incoming vertex position
              gl_Position = projection_matrix * modelview_matrix * vec4( vertex_position, 1 );
            }";

        string fragmentShaderSource = @"
            #version 140
 
            precision highp float;
 
            const vec3 ambient = vec3( 0.0, 0.5, 1.0 );
            const vec3 lightVecNormalized = normalize( vec3( 0.5, 0.5, 2 ) );
            const vec3 lightColor = vec3( 0.4, 0.5, 0.0 );
 
            in vec3 normal;
            in vec4 gl_FragCoord;
 
            out vec4 out_frag_color;
 
            void main(void)
            {
              float diffuse = clamp( dot( lightVecNormalized, normalize( normal ) ), 0.0, 1.0 );
              out_frag_color = vec4( 0.0, 0.0, 1.0, 0.0 );
            }";

        int vertexShaderHandle,
            fragmentShaderHandle,
            shaderProgramHandle,
            modelviewMatrixLocation,
            projectionMatrixLocation,
            positionVboHandle,
            normalVboHandle,
            indicesVboHandle,
            vaoHandle;

        private int _size;

        Matrix4 projectionMatrix, modelviewMatrix;

        private Vector3[] positionVboData;

        private uint[] indicesVboData;

        public XGridRenderer(List<Point3D> points)
            : this(points, 10)
        {

        }

        public XGridRenderer(List<Point3D> points, int size)
        {
            positionVboData = points.Select(x => new Vector3(x.x, x.y, (float)x.z)).ToArray();
            this._size = (size+1)*4;

            //if ((_size) != positionVboData.Count())
            //{
            //    throw new Exception("Size parameter is not correct");
            //}

            CreateShaders();
            CreateProgram();
            GL.UseProgram(shaderProgramHandle);

            QueryMatrixLocations();

            SetModelviewMatrix(Matrix4.CreateTranslation(0, 0, -5));

            // Generate and bind VAO
            GL.GenVertexArrays(1, out vaoHandle);
            GL.BindVertexArray(vaoHandle);

            LoadVertexPositions();
            LoadVertexNormals();
            LoadIndexer();

            // Other state
            GL.Enable(EnableCap.DepthTest);
        }

        public void Draw(Camera camera)
        {
            Matrix4 mat4 = new Matrix4();
            camera.GetProjectionMatrix(out mat4);
            SetProjectionMatrix(mat4);

            camera.GetModelviewMatrix(out mat4);
            SetModelviewMatrix(mat4);

            GL.LineWidth((float)0.5);

            GL.DrawElements(BeginMode.Lines, indicesVboData.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        public int GetShaderProgramHandle()
        {
            return this.shaderProgramHandle;
        }

        public int GetBufferHandle()
        {
            return vaoHandle;
        }

        private void CreateShaders()
        {
            vertexShaderHandle = GL.CreateShader(ShaderType.VertexShader);
            fragmentShaderHandle = GL.CreateShader(ShaderType.FragmentShader);

            GL.ShaderSource(vertexShaderHandle, vertexShaderSource);
            GL.ShaderSource(fragmentShaderHandle, fragmentShaderSource);

            GL.CompileShader(vertexShaderHandle);
            GL.CompileShader(fragmentShaderHandle);
        }

        private void CreateProgram()
        {
            shaderProgramHandle = GL.CreateProgram();
            QueryMatrixLocations();

            GL.AttachShader(shaderProgramHandle, vertexShaderHandle);
            GL.AttachShader(shaderProgramHandle, fragmentShaderHandle);

            GL.LinkProgram(shaderProgramHandle);

            string programInfoLog;
            GL.GetProgramInfoLog(shaderProgramHandle, out programInfoLog);
            Debug.WriteLine(programInfoLog);
        }

        private void QueryMatrixLocations()
        {
            projectionMatrixLocation = GL.GetUniformLocation(shaderProgramHandle, "projection_matrix");
            modelviewMatrixLocation = GL.GetUniformLocation(shaderProgramHandle, "modelview_matrix");
        }

        public void SetModelviewMatrix(Matrix4 matrix)
        {
            modelviewMatrix = matrix;
            GL.UniformMatrix4(modelviewMatrixLocation, false, ref modelviewMatrix);
        }

        private void SetProjectionMatrix(Matrix4 matrix)
        {
            projectionMatrix = matrix;
            GL.UniformMatrix4(projectionMatrixLocation, false, ref projectionMatrix);
        }

        private void LoadVertexPositions()
        {
            GL.GenBuffers(1, out positionVboHandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, positionVboHandle);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                new IntPtr(positionVboData.Length * Vector3.SizeInBytes),
                positionVboData, BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);
            GL.BindAttribLocation(shaderProgramHandle, 0, "vertex_position");
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes, 0);
        }

        private void LoadVertexNormals()
        {
            GL.GenBuffers(1, out normalVboHandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, normalVboHandle);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                new IntPtr(positionVboData.Length * Vector3.SizeInBytes),
                positionVboData, BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(1);
            GL.BindAttribLocation(shaderProgramHandle, 1, "vertex_normal");
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes, 0);

        }

        /// <summary>
        /// Create the index used for drawing. Makes use of degenerate triangles to create a plane from a
        /// set of points.
        /// </summary>
        private void LoadIndexer()
        {
            // Generate indexes for use on triangestrip

            //indicesVboData = new uint[positionVboData.Length * 2];

            List<uint> index = new List<uint>(positionVboData.Length * 2);

            int amountOfRows = _size - 1;

            for (uint i = 0; i <= amountOfRows; i++)
            {
                for (uint j = 0; j < _size; j++)
                {
                    index.Add((uint)(j + (i * _size)));
                    //index.Add((uint)(j + ((i + 1) * _size)));
                }

                //  Add degenerate triangles.
                //index.Add((uint)((_size - 1) + ((i + 1) * _size)));
                //index.Add((uint)(_size * (i + 1)));
            }

            indicesVboData = index.ToArray();

            GL.GenBuffers(1, out indicesVboHandle);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indicesVboHandle);
            GL.BufferData<uint>(BufferTarget.ElementArrayBuffer,
                new IntPtr(indicesVboData.Length * sizeof(uint)),
                indicesVboData, BufferUsageHint.StaticDraw);
        }
    }
}