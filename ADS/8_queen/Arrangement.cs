namespace ADS
{
    internal class Arrangement
    {
        Queue<IChessPiece> chessPieces;

        internal Arrangement()
        {
            chessPieces = new();
        }

        internal void Add(IChessPiece chessPiece, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                chessPieces.Enqueue(chessPiece);
            }
        }
    }
}
