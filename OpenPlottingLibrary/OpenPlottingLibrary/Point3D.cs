namespace OpenPlottingLibrary
{
    struct Point3D
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public Point3D(float x, float y, float z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
