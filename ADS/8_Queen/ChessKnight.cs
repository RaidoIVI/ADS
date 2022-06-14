namespace ADS
{
    internal class ChessKnight : IChessman
    {
        private readonly static int code;
        private int x;
        private int y;

        static ChessKnight()
        {
            code = IChessman.ID;
        }

        public ChessKnight()
        {
            x = 0;
            y = 0;
        }

        public string Name => "Конь";

        public int Code => code;

        public char Sign => 'K';

        public int X => x;

        public int Y => y;

        public string Description => "Конь ходит буквой Г";

        public bool Beats(int x, int y)
        {
            if (this.x == x && this.y == y) return true;
            if (this.x - x > 2 || this.x - x < -2) return false;
            if (this.y - y > 2 || this.y - y < -2) return false;
            if (this.x == x || this.y == y || Math.Abs(this.x - x) == Math.Abs(this.y - y)) return false;
            return true;
        }

        public object Clone() => MemberwiseClone();

        public void SetCoodinats(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
