using Launcher;

namespace ADS
{
    internal class L1HW3 : IHomeWork
    {
        public string Name => "Задание 3";

        public string Lession => "Урок 1";

        public string Description => "Нахождение N-го числа Фибоначи";

        public void Run()
        {
            Int64 memberNumber = Int64.Parse(IO.Get("Введите номер члена последовательности Фибоначи (нет проверки на некорректный ввод): "));
            IO.SendLine();
            IO.SendLine($"Оба метода вычисляют {memberNumber} член последовательности");
            IO.SendLine($"Рекурсия считает что это {FibonachiRecursion(memberNumber)}");
            IO.SendLine($"Цикл считает что это {FibonachiCicle(memberNumber)}");
            IO.SendLine();
        }

        private static Int64 FibonachiRecursion(Int64 Value)
        {
            if (Value == 0)
            {
                return 0;
            }
            else if (Value == 1)
            {
                return 1;
            }
            else
            {
                return FibonachiRecursion(Value - 1) + FibonachiRecursion(Value - 2);
            }
        }

        private static Int64 FibonachiCicle(Int64 Value)
        {
            Int64 member1 = 0;
            Int64 member2 = 1;
            for (Int64 i = 2; i < Value + 1; i++)
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
