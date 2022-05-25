namespace ADS
{
    internal class Node
    {
        public int Value { get; set; }
        public Node? NextNode { get; set; }
        public Node? PrevNode { get; set; }

        internal Node(int value)
        {
            Value = value;
        }

        internal Node() { }
    }
}
