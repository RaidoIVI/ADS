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
            boards = new();
            newPlased = new();
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
                var boardsCount = boards.Count;
                for (int i = 0; i < boardsCount; i++)
                {
                    var tryBoard = boards.Dequeue();
                    StepNext(tryBoard, item);
                }
                boards = newPlased;
                boardsCount = boards.Count;
                IO.SendLine($"Ставится {counter} фигура {boards.Count} вариантов, прошло {timer.Elapsed}");
                counter++;
            }

            RemoveRelapse();
        }

        private static void StepNext(Board board, IChessman chessman)
        {
            bool match = false;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    Board tmpBoard = (Board)board.Clone();
                    IChessman tmpToPlace = (IChessman)chessman.Clone();
                    tmpToPlace.SetCoodinats(i, j);
                    if (tmpBoard.Add(tmpToPlace))
                    {
                        foreach (Board item in newPlased)
                        {
                            if (tmpBoard.Equals(item)) match = true;
                        }
                        if (!match)
                        {
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
