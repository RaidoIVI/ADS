namespace ADS
{
    internal class L5HW1 : HomeWork
    {
        private new const string _lession = "Урок 5";
        private new const string _name = "Задание 1";
        private new const string _description = "Реализация обхода в ширину и в глубину";

        public L5HW1() : base(_lession, _name, _description) { }

        public override void Run()
        {
            BTree tree = new BTree();
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                tree.Add(rnd.Next(10).ToString());
            }

            IO.SendLine("Сгенерировано следующее дерево");

            tree.Draw();

            IO.SendLine("Вывод значений при обходе в ширину");
            foreach (var item in tree.BFS())
            {
                item.Draw();
            }
            IO.SendLine();

            IO.SendLine("Вывод значений при обходе в глубину");
            foreach (var item in tree.DFS())
            {
                item.Draw();
            }
            IO.SendLine();
        }
    }
}
