using OpenTK;

namespace OPL_GUI
{
    public class Camera
    {
        private float _fieldOfView;
        private float _aspectRatio;
        private float _near;
        private float _far;
        private Matrix4 _projectionMatrix;

        public Camera(float fieldOfView, float aspectRatio, float near, float far)
        {
            _fieldOfView = fieldOfView;
            _aspectRatio = aspectRatio;
            _near = near;
            _far = far;
            UpdateProjectionMatrix();
        }

        public Matrix4 ProjectionMatrix
        {
            get { return _projectionMatrix; }
            set { _projectionMatrix = value; }
        }

        public float FieldOfView
        {
            get { return _fieldOfView; }
            set
            {
                _fieldOfView = value;
                UpdateProjectionMatrix();
            }
        }

        public float AspectRatio
        {
            get { return _aspectRatio; }
            set
            {
                _aspectRatio = value;
                UpdateProjectionMatrix();
            }
        }

        public float Near
        {
            get { return _near; }
            set
            {
                _near = value;
                UpdateProjectionMatrix();
            }
        }

        public float Far
        {
            get { return _far; }
            set
            {
                _far = value;
                UpdateProjectionMatrix();
            }
        }

        private void UpdateProjectionMatrix()
        {
            _projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(FieldOfView, AspectRatio, Near, Far);    
        }
    }
}