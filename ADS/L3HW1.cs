using Launcher;

namespace ADS
{
    internal class L3HW1 : IHomeWork
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
            IO.SendLine($"Инициализация {value}");
            range.DraftResult();
            range.TestWOSqrt();
            IO.SendLine("Вычисление расстояния без корня квадратного (примерное)");
            range.DraftResult();
            range.Test();
            IO.SendLine("Вычисление расстояния с корнем квадратным (точное)");
            range.DraftResult();
            IO.SendLine("---------------------------------------------------------------------------------");
        }
    }
}
