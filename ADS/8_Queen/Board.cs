namespace ADS
{
    internal class Board : IDisposable
    {
        private int sizeX;
        private int sizeY;
        internal List<IChessman> placed;
        internal int LastPlacedX;
        internal int LastPlacedCode;

        internal Board(int x, int y)
        {
            placed = new();
            sizeX = x;
            sizeY = y;
        }

        public Board Clone() => new Board(sizeX, sizeY, placed);

        private Board(int sizeX, int sizeY, List<IChessman> placed)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.placed = new(placed);
        }

        internal bool TryAdd(IChessman chessman)
        {
            foreach (IChessman item in placed)
            {
                if (item.Beats(chessman.X, chessman.Y) || chessman.Beats(item.X, item.Y)) return false;
            }
            return true;
        }

        internal void Add(IChessman chessman)
        {
            placed.Add(chessman);   // раньше тут ставился клон
            LastPlacedX = chessman.X;
            LastPlacedCode = chessman.Code;
        }

        internal void Draw()
        {
            foreach (IChessman item in placed)
            {
                IO.Send($"{item.Name} X: {item.X} Y: {item.Y}");
                IO.SendLine();
            }
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    var tmp = placed.Find(item => item.X == i && item.Y == j);
                    if (tmp != null)
                    {
                        IO.Send(tmp.Code.ToString());
                    }
                    else
                    {
                        IO.Send("0");
                    }
                }
                IO.SendLine();
            }
            IO.SendLine();
        }

        public void Dispose()
        {

        }
    }
}