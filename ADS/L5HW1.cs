namespace ADS
{
    internal class L5Hw1 : HomeWork
    {
        private new const string Lession = "Урок 5";
        private new const string Name = "Задание 1";
        private new const string Description = "Реализация обхода в ширину и в глубину";

        public L5Hw1() : base(Lession, Name, Description) { }

        public override void Run()
        {
            BTree tree = new BTree();
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                tree.Add(rnd.Next(10).ToString());
            }

            Io.SendLine("Сгенерировано следующее дерево");

            tree.Draw();

            Io.SendLine("Вывод значений при обходе в ширину");
            foreach (var item in tree.Bfs())
            {
                item.Draw();
            }
            Io.SendLine();

            Io.SendLine("Вывод значений при обходе в глубину");
            foreach (var item in tree.Dfs())
            {
                item.Draw();
            }
            Io.SendLine();
        }
    }
}
