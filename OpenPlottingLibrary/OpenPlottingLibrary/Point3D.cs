namespace OpenPlottingLibrary
{
    public struct Point3D
    {
        public float x { get; private set; }
        public float y { get; private set; }
        public double z { get; private set; }

        public Point3D(float x, float y, double z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
