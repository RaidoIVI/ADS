using Launcher;

namespace ADS
{
    internal class L1HW1 : IHomeWork
    {
        public string Name => "Задание 1";

        public string Lession => "Урок 1";

        public string Description => "Определение простого числа методом простого перебора";

        public void Run()
        {
            Test();
        }

        private static string Prime(Int64 Number)
        {
            int d = 0;
            int i = 2;

            while (i < Number)
            {
                if (Number % i == 0)
                {
                    d++;
                }
                i++;
            }
            if (d == 0)
            {
                return $"{Number} простое";
            }
            else
                return $"{Number} составное";
        }

        private static void Test()
        {
            const int _prime = 9973;
            const int _composite = 9999;
            IO.SendLine();
            IO.SendLine($"При вводе {_prime} ответ {Prime(_prime)}");
            IO.SendLine($"При вводе {_composite} ответ {Prime(_composite)}");
            IO.SendLine();
        }
    }
}
