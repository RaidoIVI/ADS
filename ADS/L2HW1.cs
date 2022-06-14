using Launcher;

namespace ADS
{
    internal class L2Hw1 : IHomeWork
    {
        public string Name => "Задание 1";

        public string Lession => "Урок 2";

        public string Description => "Реализация двухсвязного списка в соответствии с интерфейсом";

        public void Run()
        {
            NodeList testList = new();
            var rnd = new Random();
            Io.SendLine("Сгенерированы следующие значения:");
            for (int i = 0; i < 10; i++)
            {
                int value = rnd.Next(10);
                testList.AddNode(value);
                Io.Send($"{value} ");
            }
            Io.SendLine();
            Io.SendLine("Добавлены следующие значения:");
            foreach (Node node in testList)
            {
                Io.Send($"{node.Value} ");
            }
            Io.SendLine("");
            Io.SendLine($"Всего значений: {testList.GetCount()}");
            Io.SendLine($"Выполняю пузырьковую сортировку...");
            testList.SortBubble();
            foreach (Node node in testList)
            {
                Io.Send($"{node.Value} ");
            }
            Io.SendLine();
            Node tmp;
            do
            {
                var value = rnd.Next(10);
                Io.SendLine($"Выполняю бинарный поиск значения {value}");
                tmp = testList.SearchBinary(value);
            }
            while (tmp == null);

            Io.SendLine("Успешно.");


            do
            {
                var value = rnd.Next(10);
                Io.SendLine($"Попытка поиска и удаления элемента со значением: {value}");
                testList.RemoveNode(testList.FindNode(value));
                if (testList.GetCount() < 10)
                {
                    Io.SendLine($"Успешно. Новое содержимое листа:");
                    foreach (Node node in testList)
                    {
                        Io.Send($"{node.Value} ");
                    }
                    Io.SendLine();
                }
                else
                {
                    Io.SendLine("Значение не найдено, генерация нового значения");
                }
            }
            while (testList.GetCount() == 10);

        }
    }
}
