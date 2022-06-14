using Launcher;

namespace ADS
{
    internal class L3Hw1 : IHomeWork
    {
        public string Name => "Задание 1";

        public string Lession => "Урок 3";

        public string Description => "Сравнение скорости работы класса и структуры";

        public void Run()
        {
            Test(5000);
            Test(10000);
            Test(20000);
        }

        private void Test(int value)
        {
            Range range = new(value);
            Io.SendLine($"Инициализация {value}");
            range.DraftResult();
            range.TestWoSqrt();
            Io.SendLine("Вычисление расстояния без корня квадратного (примерное)");
            range.DraftResult();
            range.Test();
            Io.SendLine("Вычисление расстояния с корнем квадратным (точное)");
            range.DraftResult();
            Io.SendLine("---------------------------------------------------------------------------------");
        }
    }
}
