using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS
{
    internal class L2HW1 : HomeWork
    {
        private new const string _lession = "Урок 2";
        private new const string _name = "Задание 1";
        private new const string _description = "Реализация двухсвязного списка в соответствии с интерфейсом";

        public L2HW1() : base(_lession, _name, _description) {}

        public override void Run()
        {
            NodeList testList = new NodeList();
            var rnd = new Random();
            IO.SendLine("Сгенерированы следующие значения:");
            for (int i = 0; i < 10; i++)
            {
                int value = rnd.Next(10);
                testList.AddNode(value);
                IO.Send( $"{value.ToString()} ");
            }
            IO.SendLine("");
            IO.SendLine("Добавлены следующие значения:");
            foreach (Node node in testList)
            {
                IO.Send($"{node.Value.ToString()} ");
            }
            IO.SendLine("");
            IO.SendLine($"Всего значений: {testList.GetCount().ToString()}");
            IO.SendLine($"Выполняю пузырьковую сортировку...");
            testList.SortBubble();
            foreach (Node node in testList)
            {
                IO.Send($"{node.Value.ToString()} ");
            }
            IO.SendLine("");
            Node tmp = null;
            do
            {
                var value = rnd.Next(10);
                IO.SendLine($"Выполняю бинарный поиск значения {value}");
                tmp = testList.SearchBinary(value);
            }
            while (tmp == null);

            IO.SendLine("Успешно.");


            do
            {
                var value = rnd.Next(10);
                IO.SendLine($"Попытка поиска и удаления элемента со значением: {value.ToString()}");
                testList.RemoveNode(testList.FindNode(value));
                if (testList.GetCount() < 10)
                {
                    IO.SendLine($"Успешно. Новое содержимое листа:");
                    foreach (Node node in testList)
                    {
                        IO.Send($"{node.Value.ToString()} ");
                    }
                    IO.SendLine("");
                }
                else
                {
                    IO.SendLine("Значение не найдено, генерация нового значения");
                }
            }
            while (testList.GetCount() == 10);

        }
    }
}
