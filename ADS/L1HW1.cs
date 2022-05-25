namespace ADS
{
    internal class L1HW1 : HomeWork
    {
        private new const string _lession = "Урок 1";
        private new const string _name = "Задание 1";
        private new const string _description = "Определение простого числа методом простого перебора";

        public L1HW1() : base(_lession, _name, _description) { }

        public override void Run()
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

    internal class L1HW2 : HomeWork
    {
        public L1HW2() : base(_lession, _name, _description) { }

        private new const string _lession = "Урок 1";
        private new const string _name = "Задание 2";
        private new const string _description = "Вычисление ассимптотической сложности";

        public override void Run()
        {
            IO.SendLine();
            IO.SendLine("Т.к. в коде 3 вложенных цикла с полным перебором всех значений то сложность будет O(N^3)");
            IO.SendLine();
        }
    }

    internal class L1HW3 : HomeWork
    {
        private new const string _lession = "Урок 1";
        private new const string _name = "Задание 3";
        private new const string _description = "Нахождение N-го числа Фибоначи";

        public L1HW3() : base(_lession, _name, _description) { }

        public override void Run()
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
