namespace ADS
{

    internal class L4HW1 : HomeWork
    {
        private new const string _lession = "Урок 4";
        private new const string _name = "Задание 1";
        private new const string _description = "Двоичное дерево";

        public L4HW1() : base(_lession, _name, _description) { }

        public override void Run()
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
