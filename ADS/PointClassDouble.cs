namespace ADS
{
    internal class PointClassDouble
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointClassDouble()
        {
            var rnd = new Random();
            X = rnd.NextDouble();
            Y = rnd.NextDouble();
        }
    }
}




