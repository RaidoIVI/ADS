namespace ADS
{
    internal class L7HW1 : HomeWork
    {
        private new const string _lession = "Урок 7";
        private new const string _name = "Задание 1";
        private new const string _description = "Решение задачи о 8 ферзях методом перебора";

        public L7HW1() : base(_lession, _name, _description) { }

        public override void Run()
        {
            var i = new ChessPiecesInit();
        }
    }
}
