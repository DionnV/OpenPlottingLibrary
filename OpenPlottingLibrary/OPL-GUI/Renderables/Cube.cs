using System;
using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OPL_GUI.Renderables
{
    public class Cube : IRenderable
    {
        private int _vertexShaderHandle;
        private int _fragmentShaderHandle;
        private int _shaderProgramHandle;
        private int _projectionMatrixLocation;
        private int _modelViewMatrixLocation;
        private int _positionVboHandle;
        private int _normalVboHandle;
        private int _indicesVboHandle;

        private Matrix4 _projectionMatrix, modelviewMatrix;

        private string _vertexShaderSource = @"
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

        private string _fragmentShaderSource = @"
            #version 140
 
            precision highp float;
 
            const vec3 ambient = vec3( 0.1, 0.1, 0.1 );
            const vec3 lightVecNormalized = normalize( vec3( 0.5, 0.5, 2 ) );
            const vec3 lightColor = vec3( 1.0, 0.8, 0.2 );
 
            in vec3 normal;
 
            out vec4 out_frag_color;
 
            void main(void)
            {
              float diffuse = clamp( dot( lightVecNormalized, normalize( normal ) ), 0.0, 1.0 );
              out_frag_color = vec4( ambient + diffuse * lightColor, 1.0 );
            }";
 
        private Vector3[] _positionVboData = new Vector3[]{
            new Vector3(-1.0f, -1.0f,  1.0f),
            new Vector3( 1.0f, -1.0f,  1.0f),
            new Vector3( 1.0f,  1.0f,  1.0f),
            new Vector3(-1.0f,  1.0f,  1.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3( 1.0f, -1.0f, -1.0f), 
            new Vector3( 1.0f,  1.0f, -1.0f),
            new Vector3(-1.0f,  1.0f, -1.0f) };

        private uint[] _indicesVboData =
        {
            // front face
            0, 1, 2, 2, 3, 0,
            // top face
            3, 2, 6, 6, 7, 3,
            // back face
            7, 6, 5, 5, 4, 7,
            // left face
            4, 0, 3, 3, 7, 4,
            // bottom face
            0, 1, 5, 5, 4, 0,
            // right face
            1, 5, 6, 6, 2, 1, };

        public Cube()
        {
            CreateShaders();
            CreateProgram();

            QueryMatrixLocations();

            setProjectionMatrix(Matrix4.CreatePerspectiveFieldOfView(1.3f, 1.6f, 0.5f, 20));
            setModelviewMatrix(Matrix4.RotateX(0.5f) * Matrix4.CreateTranslation(0,0,0) * Matrix4.CreateScale(3));

            LoadVertexPositions();
            LoadVertexNormals();
            LoadIndexer();
            
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(0, 0.1f, 0.4f, 1);
        }

        public void Draw()
        { 
            GL.UseProgram(_shaderProgramHandle);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.DrawElements(BeginMode.Triangles, _indicesVboData.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        private void CreateShaders()
        {
            _vertexShaderHandle = GL.CreateShader(ShaderType.VertexShader);
            _fragmentShaderHandle = GL.CreateShader(ShaderType.FragmentShader);

            GL.ShaderSource(_vertexShaderHandle, _vertexShaderSource);
            GL.ShaderSource(_fragmentShaderHandle, _fragmentShaderSource);

            GL.CompileShader(_vertexShaderHandle);
            GL.CompileShader(_fragmentShaderHandle);
        }

        private void CreateProgram()
        {
            _shaderProgramHandle = GL.CreateProgram();

            GL.AttachShader(_shaderProgramHandle, _vertexShaderHandle);
            GL.AttachShader(_shaderProgramHandle, _vertexShaderHandle);

            GL.LinkProgram(_shaderProgramHandle);

            string log;
            GL.GetProgramInfoLog(_shaderProgramHandle, out log);
            Debug.WriteLine(log);
        }

        private void setProjectionMatrix(Matrix4 matrix)
        {
            _projectionMatrix = matrix;
            GL.UniformMatrix4(_projectionMatrixLocation, false, ref _projectionMatrix);
        }

        private void setModelviewMatrix(Matrix4 matrix)
        {
            modelviewMatrix = matrix;
            GL.UniformMatrix4(_modelViewMatrixLocation, false, ref modelviewMatrix);
        }

        private void QueryMatrixLocations()
        {
            _projectionMatrixLocation = GL.GetUniformLocation(_shaderProgramHandle, "projection_matrix");
            _modelViewMatrixLocation = GL.GetUniformLocation(_shaderProgramHandle, "modelview_matrix");
        }

        private void LoadVertexPositions()
        {
            GL.GenBuffers(1, out _positionVboHandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _positionVboHandle);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                new IntPtr(_positionVboData.Length * Vector3.SizeInBytes),
                _positionVboData, BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);
            GL.BindAttribLocation(_shaderProgramHandle, 0, "vertex_position");
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes, 0);
        }

        private void LoadVertexNormals()
        {
            GL.GenBuffers(1, out _normalVboHandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _normalVboHandle);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                new IntPtr(_positionVboData.Length * Vector3.SizeInBytes),
                _positionVboData, BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(1);
            GL.BindAttribLocation(_shaderProgramHandle, 1, "vertex_normal");
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes, 0);
        }

        private void LoadIndexer()
        {
            GL.GenBuffers(1, out _indicesVboHandle);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _indicesVboHandle);
            GL.BufferData<uint>(BufferTarget.ElementArrayBuffer,
                new IntPtr(_indicesVboData.Length * Vector3.SizeInBytes),
                _indicesVboData, BufferUsageHint.StaticDraw);
        }
    }
}