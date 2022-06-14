using Launcher;

namespace ADS
{
    internal class L6Hw1 : IHomeWork
    {
        public string Name => "Задание 1";

        public string Lession => "Урок 6";

        public string Description => "Реализация Launcher отдельным проектом через интерфейс";

        public void Run()
        {
            Io.SendLine("Если вы видите эту надпись, то запуск выполнен успешно.");
        }
    }
}
