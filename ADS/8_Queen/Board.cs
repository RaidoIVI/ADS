namespace ADS
{
    internal class Board
    {
        private readonly int sizeX;
        private readonly int sizeY;
        internal List<IChessman> Placed;
        internal int LastPlacedX;
        internal int LastPlacedCode;

        internal Board(int x, int y)
        {
            Placed = new();
            sizeX = x;
            sizeY = y;
        }

        public Board Clone() => new Board(sizeX, sizeY, Placed);

        private Board(int sizeX, int sizeY, List<IChessman> placed)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.Placed = new(placed);
        }

        internal bool TryAdd(IChessman chessman)
        {
            foreach (IChessman item in Placed)
            {
                if (item.Beats(chessman.X, chessman.Y) || chessman.Beats(item.X, item.Y)) return false;
            }
            return true;
        }

        internal bool Add(IChessman chessman)
        {
            Placed.Add(chessman);   // раньше тут ставился клон
            LastPlacedX = chessman.X;
            LastPlacedCode = chessman.Code;
            return true;
        }

        internal void Draw()
        {
            foreach (IChessman item in Placed)
            {
                Io.Send($"{item.Name} X: {item.X} Y: {item.Y}");
                Io.SendLine();
            }
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    var tmp = Placed.Find(item => item.X == i && item.Y == j);
                    if (tmp != null)
                    {
                        Io.Send(tmp.Code.ToString());
                    }
                    else
                    {
                        Io.Send("0");
                    }
                }
                Io.SendLine();
            }
            Io.SendLine();
        }
    }
}