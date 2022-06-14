using Launcher;

namespace ADS
{

    internal class L4Hw1 : IHomeWork
    {
        public string Name => "Задание 1";

        public string Lession => "Урок 4";

        public string Description => "Двоичное дерево";

        public void Run()
        {
            BTree tree = new BTree();
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                tree.Add(rnd.Next().ToString());
            }
            tree.Draw();
        }
    }
}
