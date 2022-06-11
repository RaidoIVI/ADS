namespace ADS
{
    internal class Rook : IChessman
    {
        private readonly static int code;
        private int x;
        private int y;

        static Rook()
        {
            code = IChessman.ID;
        }

        public Rook()
        {
            x = 0;
            y = 0;
        }

        public string Name => "Ладья";

        public string Description => "Ладья ходит по горизонтали в вертикали";

        public char Sign => 'R';

        public int Code => code;

        public int X => x;

        public int Y => y;

        public bool Beats(int x, int y) => this.x == x || this.y == y;

        public object Clone() => MemberwiseClone();

        public void SetCoodinats(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}