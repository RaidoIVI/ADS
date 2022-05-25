namespace ADS
{
    internal struct PointStructDouble
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointStructDouble()
        {
            var rnd = new Random();
            X = rnd.NextDouble();
            Y = rnd.NextDouble();
        }
    }
}




