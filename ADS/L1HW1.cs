using Launcher;

namespace ADS
{
    internal class L1Hw1 : IHomeWork
    {
        public string Name => "Задание 1";

        public string Lession => "Урок 1";

        public string Description => "Определение простого числа методом простого перебора";

        public void Run()
        {
            Test();
        }

        private static string Prime(Int64 number)
        {
            int d = 0;
            int i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }
                i++;
            }
            if (d == 0)
            {
                return $"{number} простое";
            }
            else
                return $"{number} составное";
        }

        private static void Test()
        {
            const int prime = 9973;
            const int composite = 9999;
            Io.SendLine();
            Io.SendLine($"При вводе {prime} ответ {Prime(prime)}");
            Io.SendLine($"При вводе {composite} ответ {Prime(composite)}");
            Io.SendLine();
        }
    }
}
