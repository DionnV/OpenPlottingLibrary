using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;

using OpenTK.Graphics;

namespace OPL_GUI
{
    public class Camera
    {
        #region Constructors

        public Camera()
            : this(new Vector3(), new Quaternion() { X = 0, Y = 1, Z = 0, W = 0 })
        { }

        public Camera(Vector3 position)
            : this(position, new Quaternion() { X = 0, Y = 1, Z = 0, W = 0 })
        { }

        public Camera(Vector3 position, Quaternion orientation)
        {
            TargetPosition = Position = position;
            TargetOrientation = Orientation = orientation;

            AspectRatio = 1.333f;
            FieldOfView = 60;
            ZNear = 1;
            ZFar = 64;
        }

        #endregion

        #region Public Members

        #region Properties


        public Vector3 Position { get; set; }
        public Quaternion Orientation { get; set; }

        public Vector3 TargetPosition { get; set; }
        public Quaternion TargetOrientation { get; set; }

        public Vector3 Forward { get { return Extension.Apply(Orientation, Vector3.UnitZ); } }
        public Vector3 Right { get { return Extension.Apply(Orientation, Vector3.UnitX); } }
        public Vector3 Up { get { return Extension.Apply(Orientation, Vector3.UnitY); } }

        public float AspectRatio { get; set; }
        public float FieldOfView { get; set; }
        public float ZNear { get; set; }
        public float ZFar { get; set; }

        #endregion

        #region Methods


        public void GetProjectionMatrix(out Matrix4 matrix)
        {
            matrix = Matrix4.Perspective((float)(FieldOfView * Math.PI / 180.0), AspectRatio, ZNear, ZFar);
        }

        public void GetModelviewProjectionMatrix(out Matrix4 result)
        {
            Matrix4 modelview;
            GetProjectionMatrix(out result);
            GetModelviewMatrix(out modelview);
            Matrix4.Mult(ref modelview, ref result, out result);
        }

        public void GetModelviewMatrix(out Matrix4 matrix)
        {
            var translation_matrix = Matrix4.Translation(-Position);
            var rotation_matrix = Matrix4.Rotate(Orientation);
            Matrix4.Mult(ref translation_matrix, ref rotation_matrix, out matrix);
        }

        public void RotateX(float angle)
        {
            Orientation *= Extension.CreateRotationX(angle);         
        }

        public void RotateY(float angle)
        {
            Orientation *= Extension.CreateRotationY(angle);
        }
        public void RotateZ(float angle)
        {
            Orientation *= Extension.CreateRotationZ(angle);         
        }

        public void SetX(float x)
        {
            Vector3 newPos = new Vector3(x, Position.Y, Position.Z);
            Position = newPos;
        }

        public void SetY(float y)
        {
            Vector3 newPos = new Vector3(Position.X, y, Position.Z);
            Position = newPos;
        }

        public void SetZ(float z)
        {
            Vector3 newPos = new Vector3(Position.X, Position.Y, z);
            Position = newPos;
        }
        #endregion

        #endregion  
    }
}

public static class Extension
{
    public static Vector3 Apply(this Quaternion quat, Vector3 vector)
    {
        Quaternion v = new Quaternion() { X = vector.X, Y = vector.Y, Z = vector.Z, W = 0 };
        Quaternion i = quat.Inverted();
        Quaternion t = i * v;
        v = t * quat;

        return new Vector3(v.X, v.Y, v.Z);
    }

    public static Quaternion CreateRotationX(float angle)
    {
        return new Quaternion()
        {
            X = (float)System.Math.Cos(angle / 2),
            Y = (float)System.Math.Sin(angle / 2),
            Z = 0,
            W = 0
        };
    }

    public static Quaternion CreateRotationY(float angle)
    {
        return new Quaternion()
        {
            X = (float)System.Math.Cos(angle / 2),
            Y = 0,
            Z = (float)System.Math.Sin(angle / 2),
            W = 0
        };
    }

    public static Quaternion CreateRotationZ(float angle)
    {
        return new Quaternion()
        {
            X = (float)System.Math.Cos(angle / 2),
            Y = 0,
            Z = 0,
            W = (float)System.Math.Sin(angle / 2)
        };
    }
}