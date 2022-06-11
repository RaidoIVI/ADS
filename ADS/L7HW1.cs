using Launcher;

namespace ADS
{
    internal class L7HW1 : IHomeWork
    {
        public string Name => "Задание 1";

        public string Lession => "Урок 8";

        public string Description => "Задача о 8 ферзях в общем виде. Для добавления новых фигур нужно добавить класс реализующий интерфейс IChessman";

        public void Run()
        {
            ChessmanInit.Run();
        }
    }
}
