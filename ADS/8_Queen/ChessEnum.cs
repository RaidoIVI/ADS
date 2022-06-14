using System.Diagnostics;

namespace ADS
{
    internal static class ChessEnum
    {
        private static Queue<Board> boards;
        private static int sizeX;
        private static int sizeY;
        private static Queue<Board> newPlased;

        static ChessEnum()
        { }

        internal static Queue<Board> Result => boards;

        internal static void Init(int x, int y)
        {
            boards = new(10_000_000);
            newPlased = new(10_000_000);
            sizeX = x;
            sizeY = y;
            boards.Enqueue(new Board(x, y));
        }

        internal static void Start(Queue<IChessman> chessmen)
        {
            Stopwatch timer = new();
            timer.Start();
            var counter = 1;
            foreach (IChessman item in chessmen)
            {
                newPlased = new();
                while (boards.Count != 0)
                {
                    var tryBoard = boards.Dequeue();
                    StepNext(tryBoard, item);
                }
                boards = newPlased;
                IO.SendLine($"Ставится {counter} фигура {boards.Count} вариантов, прошло {timer.Elapsed}");
                counter++;
            }
            timer.Stop();
        }

        private static void StepNext(Board board, IChessman chessman)
        {
            int minX = 0;
            int minY = 0;
            if (board.LastPlaced != null && board.LastPlaced.Code == chessman.Code)
            {
                minX = board.LastPlaced.X;
                minY = board.LastPlaced.Y;
            }
            for (int i = minX; i < sizeX; i++)
            {
                if (i == minX)
                {
                    for (int j = minY; j < sizeY; j++)
                    {
                        chessman.SetCoodinats(i, j);
                        if (board.TryAdd(chessman))
                        {
                            Board tmpBoard = (Board)board.Clone();
                            IChessman tmpToPlace = (IChessman)chessman.Clone();
                            tmpBoard.Add(tmpToPlace);
                            newPlased.Enqueue(tmpBoard);

                        }
                    }
                }
                else
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        chessman.SetCoodinats(i, j);
                        if (board.TryAdd(chessman))
                        {
                            Board tmpBoard = (Board)board.Clone();
                            IChessman tmpToPlace = (IChessman)chessman.Clone();
                            tmpBoard.Add(tmpToPlace);
                            newPlased.Enqueue(tmpBoard);

                        }
                    }
                }
            }
        }
    }
}
