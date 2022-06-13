namespace ADS
{
    internal class Board : ICloneable
    {
        private int sizeX;
        private int sizeY;
        internal List<IChessman> placed;
        internal IChessman LastPlaced;

        internal Board(int x, int y)
        {
            placed = new();
            sizeX = x;
            sizeY = y;
        }

        public object Clone() => new Board(sizeX, sizeY, placed);

        //public IReadOnlyCollection<IChessman> GetChessmen => placed.AsReadOnly();

        //public override bool Equals(Object board)
        //{
        //    if (board == null || board.GetType() != typeof(Board))
        //    {
        //        return false;
        //    }
        //    int match = 0;

        //    foreach (IChessman chessman in ((Board)board).placed)
        //    {
        //        if (placed.Find(f => f.Code == chessman.Code && ((f.X == chessman.X && f.Y == chessman.Y))) != null) match++;
        //    }
        //    return match == placed.Count;
        //}


        private Board(int sizeX, int sizeY, List<IChessman> placed) : this(sizeX, sizeY)
        {
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

        internal bool Add(IChessman chessman)
        {
            //foreach (IChessman item in placed)
            //{
            //    if (item.Beats(chessman.X, chessman.Y) || chessman.Beats(item.X, item.Y)) return false;
            //}
            placed.Add(chessman);   // раньше тут ставился клон
            LastPlaced = placed.Last();
            return true;
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
    }
}