using Launcher;

namespace ADS
{
    internal class L1Hw3 : IHomeWork
    {
        public string Name => "Задание 3";

        public string Lession => "Урок 1";

        public string Description => "Нахождение N-го числа Фибоначи";

        public void Run()
        {
            Int64 memberNumber = Int64.Parse(Io.Get("Введите номер члена последовательности Фибоначи (нет проверки на некорректный ввод): "));
            Io.SendLine();
            Io.SendLine($"Оба метода вычисляют {memberNumber} член последовательности");
            Io.SendLine($"Рекурсия считает что это {FibonachiRecursion(memberNumber)}");
            Io.SendLine($"Цикл считает что это {FibonachiCicle(memberNumber)}");
            Io.SendLine();
        }

        private static Int64 FibonachiRecursion(Int64 value)
        {
            if (value == 0)
            {
                return 0;
            }
            else if (value == 1)
            {
                return 1;
            }
            else
            {
                return FibonachiRecursion(value - 1) + FibonachiRecursion(value - 2);
            }
        }

        private static Int64 FibonachiCicle(Int64 value)
        {
            Int64 member1 = 0;
            Int64 member2 = 1;
            for (Int64 i = 2; i < value + 1; i++)
            {
                if ((i % 2) == 0)
                {
                    member1 += member2;
                }
                else
                {
                    member2 += member1;
                }
            }
            return member1 > member2 ? member1 : member2;
        }
    }
}
