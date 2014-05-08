namespace OpenPlottingLibrary
{
    public struct PolygonSet
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int z { get; private set; }

        public PolygonSet(int x, int y, int z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
