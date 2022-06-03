namespace ADS
{
    internal class Queen : IChessPiece
    {
        private const string _name = "Ферзь";
        private const char _sign = 'Q';
        private const string _description = "Ферзь бьет все клетки по горизонтали, вертикали и по обеим диагоналям";

        private int x;
        private int y;
        private static int code;
        private static int counter;

        static Queen()
        {
            code = IChessPiece.Code;
            IO.SendLine(code.ToString());
        }

        internal Queen(int x, int y) => SetCoordinats(x, y);

        public static string Name => _name;

        public static char Sign => _sign;

        public static string Description => _description;

        public int Code => code;

        public bool Beats(int x, int y)
        {
            if (this.x == x || this.y == y || (Math.Abs(this.x - x) == Math.Abs(this.y - y)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void SetCoordinats(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
