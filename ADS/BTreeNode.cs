namespace ADS
{
    internal class BTreeNode
    {
        private BTreeNode? parent;
        private BTreeNode? childLeft;
        private BTreeNode? childRight;
        private string value;
        private int hash;

        internal BTreeNode(string value)
        {
            this.value = value;
            hash = value.GetHashCode();
        }

        internal BTreeNode(int hash)
        {
            value = String.Empty;
            this.hash = hash;
        }

        private BTreeNode(string value, int hash, BTreeNode parent)
        {
            this.value = value;
            this.hash = hash;
            this.parent = parent;
        }

        internal void SetValue(string value)
        {
            this.value = value;
            hash = value.GetHashCode();
        }

        internal string GetValue()
        {
            return value;
        }

        internal BTreeNode? Find(int hash)
        {
            if (this.hash == hash)
            {
                return this;
            }
            if (this.hash > hash)
            {
                if (childLeft == null)
                {
                    return null;
                }
                else
                {
                    return childLeft.Find(hash);
                }
            }
            else
            {
                if (childRight == null)
                {
                    return null;
                }
                else
                {
                    return childRight.Find(hash);
                }
            }
        }

        internal void CreateChild(string value, int hash)
        {
            if (this.hash == hash)
            {
                this.value = value;
            }
            else
            {
                if (this.hash > hash)
                {
                    if (childLeft == null)
                    {
                        childLeft = new BTreeNode(value, hash, this);
                    }
                    else
                    {
                        childLeft.CreateChild(value, hash);
                    }
                }
                else
                {
                    if (childRight == null)
                    {
                        childRight = new BTreeNode(value, hash, this);
                    }
                    else
                    {
                        childRight.CreateChild(value, hash);
                    }
                }
            }
        }

        internal void AddChild(BTreeNode node)
        {
            if (hash > node.hash)
            {
                if (childLeft == null)
                {
                    childLeft = node;
                    node.parent = this;
                }
                else
                {
                    AddChild(node);
                }
                return;
            }
            if (hash < node.hash)
            {
                if (childRight == null)
                {
                    childRight = node;
                    node.parent = this;
                }
                else
                {
                    AddChild(node);
                }
                return;
            }
        }   // замена не происходит, считаем что все значения уникальны.

        internal BTreeNode? CutNode()
        {
            if (this.parent != null)
            {
                var parent = this.parent;
                parent.DropChild(this);
            }
            return this;
        }

        internal void DropChild(BTreeNode child)
        {
            if (childLeft == child)
            {
                childLeft = null;
            }
            if (childRight == child)
            {
                childRight = null;
            }
        }

        internal BTreeNode? GetParent()
        {
            return parent;
        }

        internal (BTreeNode? childLeft, BTreeNode? childRight) Remove()
        {
            parent.DropChild(this);
            return (childLeft, childRight);
        }

        internal BTreeNode[] GetChild()
        {
            List<BTreeNode> child = new List<BTreeNode>() { childLeft, childRight };
            return child.ToArray();
        }

        internal void Draw()
        {
            Io.Send(value);
        }
    }
}
