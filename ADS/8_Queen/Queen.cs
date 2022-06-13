namespace ADS
{
    internal struct Queen : IChessman
    {
        private readonly static int code;
        private int x;
        private int y;

        static Queen()
        {
            code = IChessman.ID;
        }

        public Queen()
        {
            x = 0;
            y = 0;
        }

        private Queen(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public string Name => "Ферзь";

        public string Description => "Ферзь ходит по вертикали, по горизонтали и по обеим диагоналям";

        public char Sign => 'Q';

        public int Code => code;

        public int X => x;

        public int Y => y;

        public bool Beats(int x, int y) => this.x == x || this.y == y || Math.Abs(this.x - x) == Math.Abs(this.y - y);

        public object Clone() => new Queen(x, y);

        public void SetCoodinats(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
