namespace ADS
{
    internal class L3HW1 : HomeWork
    {
        private new const string _lession = "Урок 3";
        private new const string _name = "Задание 1";
        private new const string _description = "Сравнение скорости работы класса и структуры";

        public L3HW1() : base(_lession, _name, _description) { }

        public override void Run()
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
