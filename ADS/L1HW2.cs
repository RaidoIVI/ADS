using Launcher;

namespace ADS
{
    internal class L1HW2 : IHomeWork
    {
        public string Name => "Задание 2";

        public string Lession => "Урок 1";

        public string Description => "Вычисление ассимптотической сложности";

        public void Run()
        {
            IO.SendLine();
            IO.SendLine("Т.к. в коде 3 вложенных цикла с полным перебором всех значений то сложность будет O(N^3)");
            IO.SendLine();
        }
    }
}
