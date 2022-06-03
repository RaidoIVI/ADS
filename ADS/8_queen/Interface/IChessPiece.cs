namespace ADS
{
    public interface IChessPiece                 // подготовка к решению в общем виде с набором разных фигур.
    {
        public bool Beats(int x, int y);
        public static string Name { get; }
        public static char Sign { get; }
        public static string Description { get; }
        public static int Code;

    }
}
