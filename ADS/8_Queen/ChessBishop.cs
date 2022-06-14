namespace ADS
{
    internal class ChessBishop : IChessman
    {
        private readonly static int code;
        private int x;
        private int y;

        static ChessBishop()
        {
            code = IChessman.ID;
        }

        public ChessBishop()
        {
            x = 0;
            y = 0;
        }

        public string Name => "Слон";

        public int Code => code;

        public char Sign => 'B';

        public string Description => "Слон ходит по диагонали";

        public int X => x;

        public int Y => y;

        public bool Beats(int x, int y) => Math.Abs(this.x - x) == Math.Abs(this.y - y);

        public object Clone() => MemberwiseClone();

        public void SetCoodinats(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
