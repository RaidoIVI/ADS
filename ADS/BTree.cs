using System.Text;

namespace ADS
{
    internal class BTree
    {
        private BTreeNode root;

        public BTree()
        {
            root = new BTreeNode(0);
        }

        public BTree(BTreeNode root)
        {
            this.root = root;
        }

        public void Add(string value)
        {
            var hash = value.GetHashCode();
            root.CreateChild(value, hash);
        }

        public bool Contains(string value)
        {
            var hash = value.GetHashCode();
            if (root.Find(hash) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Remove(string value)
        {
            var hash = value.GetHashCode();
            var removed = root.Find(hash);
            if (removed == null) return;
            if (removed.GetParent == null) return;
            (BTreeNode, BTreeNode) child = removed.Remove();
            if (child.Item1 != null) root.AddChild(child.Item1);
            if (child.Item2 != null) root.AddChild(child.Item2);
        }

        public BTree? GetSubTree(string value)
        {
            var hash = value.GetHashCode();
            var currentNode = root.Find(hash);
            if (currentNode == null)
            {
                return null;
            }
            else
            {
                if (currentNode.GetParent() == null)
                {
                    return null;
                }
                else
                {
                    currentNode.GetParent().DropChild(currentNode);
                    return new BTree(currentNode);
                }
            }
        }

        public void Draw()
        {
            StringBuilder tree = new StringBuilder();
            GetTree(tree, root, "", true);
            IO.Send(tree.ToString());
            IO.SendLine();
        }

        private void GetTree(StringBuilder tree, BTreeNode node, string indent, bool last)
        {
            tree.Append(indent);
            if (last)
            {
                tree.Append("└─");
                indent += "  ";
            }
            else
            {
                tree.Append("├─");
                indent += ("│ ");
            }
            tree.Append($"{node.GetValue()} {node.GetValue().GetHashCode()}\n");
            BTreeNode[] child = node.GetChild();
            for (int i = 0; i < child.Length; i++)
            {
                if (child[i] != null) GetTree(tree, child[i], indent, i == child.Length - 1);
            }
        }
    }
}
