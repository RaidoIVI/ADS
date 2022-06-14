namespace ADS
{
    public interface IChessman : ICloneable
    {
        public bool Beats(int x, int y);              // Бьет ли фигура из текущего положения клетку с координатами (X,Y)
        public void SetCoodinats(int x, int y);       // Перемещает фигуру в новую позицию по координатам (X,Y)
        private static int _code;
        public string Name { get; }
        public int Code { get; }
        public char Sign { get; }
        public int X { get; }
        public int Y { get; }

        static IChessman()
        {
            _code = 0;
        }

        internal static int Id
        {
            get
            {
                _code++;
                return _code;
            }
        }
    }
}
