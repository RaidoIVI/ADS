namespace ADS
{
    internal class Board
    {
        private readonly int sizeX;
        private readonly int sizeY;
        private int[,] boad;

        internal Board(int x, int y)
        {
            boad = new int[x, y];                                               // 0 свободная клетка, -1 клетка под боем, значение >0 тип фигуры
            sizeX = x;
            sizeY = y;
        }

        internal bool TryArrange(IChessPiece chessPiece, int x, int y)
        {
            if (boad[x, y] != 0) return false;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (boad[x, y] > 0 && chessPiece.Beats(x, y)) return false;
                }
            }
            //boad[x, y] = chessPiece.Code;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (chessPiece.Beats(x, y)) boad[x, y] = -1;
                }
            }
            return true;
        }

        internal int SizeX => sizeX;
        internal int SizeY => sizeY;

        internal int[,] Draw()
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (boad[i, j] < 0)
                    {
                        boad[i, j] = 0;
                    }
                }
            }
            return boad;
        }
    }
}
