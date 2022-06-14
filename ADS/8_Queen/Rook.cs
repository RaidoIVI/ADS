namespace ADS
{
    internal class Rook : IChessman
    {
        private static readonly int сode;
        private int x;
        private int y;

        static Rook()
        {
            сode = IChessman.Id;
        }

        public Rook()
        {
            x = 0;
            y = 0;
        }

        public string Name => "Ладья";

        public string Description => "Ладья ходит по горизонтали в вертикали";

        public char Sign => 'R';

        public int Code => сode;

        public int X => x;

        public int Y => y;

        public bool Beats(int x, int y) => this.x == x || this.y == y;

        public object Clone() => MemberwiseClone();

        public void Dispose()
        { }

        public void SetCoodinats(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}