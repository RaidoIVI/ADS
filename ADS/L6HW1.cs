using Launcher;

namespace ADS
{
    internal class L6HW1 : IHomeWork
    {
        public string Name => "Задание 1";

        public string Lession => "Урок 6";

        public string Description => "Реализация Launcher отдельным проектом через интерфейс";

        public void Run()
        {
            IO.SendLine("Если вы видите эту надпись, то запуск выполнен успешно.");
        }
    }
}
