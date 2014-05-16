﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using OpenPlottingLibrary;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OPL_GUI.Renderables
{
    public class PointRenderer : IRenderable
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
 
            const vec3 ambient = vec3( 0.0, 0.0, 0.0 );
            const vec3 lightVecNormalized = normalize( vec3( 0.5, 0.5, 2 ) );
            const vec3 lightColor = vec3( 0.0, 0.0, 0.0 );
 
            in vec3 normal;
 
            out vec4 out_frag_color;
 
            void main(void)
            {
              float diffuse = clamp( dot( lightVecNormalized, normalize( normal ) ), 0.0, 1.0 );
              out_frag_color = vec4( ambient + diffuse * lightColor, 1.0 );
            }";

        int vertexShaderHandle,
            fragmentShaderHandle,
            shaderProgramHandle,
            modelviewMatrixLocation,
            projectionMatrixLocation,
            positionVboHandle,
            normalVboHandle,
            indicesVboHandle;

        Matrix4 projectionMatrix, modelviewMatrix;

        private Vector3[] positionVboData;

        private uint[] indicesVboData;

        public PointRenderer(List<Point3D> points)
        {
            positionVboData = points.Select(x => new Vector3(x.x, x.y, x.z)).ToArray();

            CreateShaders();
            CreateProgram();
            GL.UseProgram(shaderProgramHandle);

            QueryMatrixLocations();

            SetModelviewMatrix(Matrix4.CreateTranslation(0, 0, -4));

            LoadVertexPositions();
            LoadVertexNormals();
            LoadIndexer();

            // Other state
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(1, 1f, 1f, 1);
        }

        public void Draw(Camera camera)
        {
            SetProjectionMatrix(camera.ProjectionMatrix);
            
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.DrawElements(BeginMode.TriangleStrip, indicesVboData.Length,
                DrawElementsType.UnsignedInt, IntPtr.Zero);

            GL.Flush();
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

        private void SetModelviewMatrix(Matrix4 matrix)
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

        private void LoadIndexer()
        {
            // Generate indexes for use on triangestrip

            indicesVboData = new uint[positionVboData.Length];
            for (int i = 0; i < positionVboData.Length; i++)
            {
                indicesVboData[i] = (uint)i;
            }

            GL.GenBuffers(1, out indicesVboHandle);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indicesVboHandle);
            GL.BufferData<uint>(BufferTarget.ElementArrayBuffer,
                new IntPtr(indicesVboData.Length * sizeof(uint)),
                indicesVboData, BufferUsageHint.StaticDraw);
        } 
    }
}