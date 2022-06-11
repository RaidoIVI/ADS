using Launcher;
using System.Diagnostics;

namespace ADS
{
    internal class L8HW1 : IHomeWork
    {
        public string Name => "Задание 1";

        public string Lession => "Урок 8";

        public string Description => "Сортировка подсчетом";

        public void Run()
        {
            int itemCount = int.Parse(IO.Get("Введите количество значений для последовательности (нет проверки некорректного ввода): "));
            int maxValue = 1 + int.Parse(IO.Get("Введите максимальное значение (нет проверки некорректного ввода): "));
            var rnd = new Random();
            int[] sorted = new int[itemCount];
            IO.SendLine($"Инициализация массива в {itemCount} элементов случайными значениями 0-{maxValue - 1} включительно");
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < itemCount; i++)
            {
                sorted[i] = rnd.Next(maxValue);
            }
            sw.Stop();
            IO.SendLine($"Выполнено за {sw.Elapsed}");
            if ("y" == IO.Get("Для вывода результата введите y: ").ToLower())
            {
                for (int i = 0; i < itemCount; i++)
                {
                    IO.Send($"{sorted[i]} ");
                }
            }
            IO.SendLine();
            IO.SendLine("Начинаю сортировку...");
            sw.Restart();
            int[] helper = new int[maxValue];
            for (int i = 0; i < itemCount; i++)
            {
                helper[sorted[i]]++;
            }
            int slip = 0;
            for (int i = 0; i < helper.Length; i++)
            {
                for (int j = 0; j < helper[i]; j++)
                {
                    sorted[slip] = i;
                    slip++;
                }
            }
            sw.Stop();
            IO.SendLine($"Сортировка выполнена за {sw.Elapsed}");
            if ("y" == IO.Get("Для вывода результата введите y: ").ToLower())
            {
                for (int i = 0; i < itemCount; i++)
                {
                    IO.Send($"{sorted[i]} ");
                }
            }
            IO.SendLine();
        }
    }
}
