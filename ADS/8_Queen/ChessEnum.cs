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
        {
            boards = new(10_000_000);
            newPlased = new(10_000_000);
        }

        internal static Queue<Board> Result => boards;

        internal static void Init(int x, int y)
        {
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
                //RemoveRelapse();
                boards = newPlased;

                IO.SendLine($"Ставится {counter} фигура {boards.Count} вариантов, прошло {timer.Elapsed}");
                counter++;
            }

            //RemoveRelapse();
        }

        private static void StepNext(Board board, IChessman chessman)
        {
            //bool match = false;
            int minX = 0;
            int minY = 0;
            if (board.LastPlaced != null && board.LastPlaced.Code == chessman.Code)
            {
                minX = board.LastPlaced.X;
                minY = board.LastPlaced.Y;
            }
            for (int i = minX; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    //Board tmpBoard = (Board)board.Clone();
                    //IChessman tmpToPlace = (IChessman)chessman.Clone();
                    chessman.SetCoodinats(i, j);
                    if (board.TryAdd(chessman))
                    {
                        //foreach (Board item in newPlased)
                        //{
                        //    if (tmpBoard.Equals(item)) match = true;
                        //}
                        //if (!match)
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

        private static void RemoveRelapse()
        {
            int count = boards.Count;
            for (int i = 0; i < count; i++)
            {
                Board thisBoard = boards.Dequeue();
                bool match = false;
                foreach (Board board in boards)
                {
                    if (thisBoard.Equals(board)) match = true;
                }
                if (!match) boards.Enqueue(thisBoard);
            }
        }
    }
}
