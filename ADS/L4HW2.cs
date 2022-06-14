using Launcher;
using System.Diagnostics;

namespace ADS
{
    internal class L4Hw2 : IHomeWork
    {
        public string Name => "Задание 2";

        public string Lession => "Урок 4";

        public string Description => "Сравнение скорости массива и HashSet";

        public void Run()
        {
            var stopWatch = new Stopwatch();
            var rnd = new Random();
            Io.SendLine("Инициализация массива 100 000 строк...");
            stopWatch.Start();
            string[] array = new string[100000];
            for (int i = 0; i < 100000; i++)
                array[i] = rnd.Next().ToString();
            stopWatch.Stop();
            Io.SendLine($"Инициализация заняла {stopWatch.Elapsed}");
            Io.SendLine("Инициализация HashSet 100 000 строк");
            stopWatch.Restart();
            HashSet<string> set = new HashSet<string>(1000000);
            for (int i = 0; i < 100000; i++)
            {
                set.Add(i.ToString());
            }
            stopWatch.Stop();
            Io.SendLine($"Инициализация заняла {stopWatch.Elapsed}");
            Io.SendLine();
            Io.SendLine("Поиск случайного значения в массиве");
            string findValue = rnd.Next().ToString();
            stopWatch.Restart();
            foreach (string s in array)
            {
                if (s == findValue) stopWatch.Stop();
            }
            Io.SendLine($"Поиск занял {stopWatch.Elapsed}");
            Io.SendLine("Поиск случайного значения в HashSet");
            stopWatch.Restart();
            set.Contains(findValue);
            stopWatch.Stop();
            Io.SendLine($"Поиск занял {stopWatch.Elapsed}");
            Io.SendLine();
        }
    }
}