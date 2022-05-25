using System.Collections;

namespace ADS
{
    internal class NodeList : ILinkedList, IEnumerable
    {
        private readonly Node firstNode;
        private readonly Node lastNode;

        public NodeList()
        {
            firstNode = new Node(0);                        //Служебные неудаляемые ноды, будут хранить число элементов
            lastNode = new Node(0);                         //тоже самое
            firstNode.NextNode = lastNode;
            lastNode.PrevNode = firstNode;
        }

        #region HW1

        public void AddNode(int value)
        {
            if (firstNode.Value == 0)
            {
                Node newNode = new(value);
                firstNode.NextNode = newNode;
                lastNode.PrevNode = newNode;
                newNode.PrevNode = firstNode;
                newNode.NextNode = lastNode;
                firstNode.Value++;
                lastNode.Value++;
            }
            else
            {
                AddNodeAfter(lastNode.PrevNode, value);
            }
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (node != lastNode && node != firstNode)
            {
                Node nextNode = node.NextNode;
                Node newNode = new(value)
                {
                    PrevNode = node,
                    NextNode = node.NextNode
                };
                node.NextNode = newNode;
                nextNode.PrevNode = newNode;
                firstNode.Value++;
                lastNode.Value++;
            }
        }

        public Node FindNode(int searchValue)
        {
            if (firstNode.Value != 0)
            {
                Node currentNode = firstNode.NextNode;

                while (currentNode != lastNode)
                {
                    if (currentNode.Value == searchValue)
                    {
                        return currentNode;
                    }
                    else
                    {
                        currentNode = currentNode.NextNode;
                    }
                }
            }
            return null;
        }

        public Node FindNode(Node searchNode)
        {
            if (firstNode.Value != 0)
            {
                Node currentNode = firstNode;
                while (currentNode != lastNode)
                {
                    if (currentNode == searchNode)
                    {
                        return currentNode;
                    }
                    else
                    {
                        currentNode = currentNode.NextNode;
                    }
                }
            }
            return null;
        }

        public int GetCount()
        {
            return firstNode.Value;
        }

        public void RemoveNode(int index)
        {
            var node = GetNode(index);
            if (node != null)
            {
                RemoveNode(node);
            }
        }

        private Node? GetNode(int index)
        {
            Node current = firstNode.NextNode;
            for (int i = 0; i < index; i++)
            {
                current = current.NextNode;
            }
            return current;
        }

        public void RemoveNode(Node node)
        {
            Node removeNode = FindNode(node);

            if (removeNode != null && removeNode != firstNode && removeNode != lastNode)
            {
                Node prevNode = removeNode.PrevNode;
                Node nextNode = removeNode.NextNode;
                prevNode.NextNode = nextNode;
                nextNode.PrevNode = prevNode;
                firstNode.Value--;
                lastNode.Value--;
            }
        }

        #endregion

        #region IEnumerator

        public NodeListEnum GetEnumerator()
        {
            return new NodeListEnum(firstNode, lastNode);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region HW2

        public void SortBubble()
        {
            for (int i = 0; i < firstNode.Value; i++)
            {
                Node current = firstNode;
                for (var j = 0; j < lastNode.Value; j++)
                {
                    current = current.NextNode;
                    if (current.Value > current.NextNode.Value)
                    {
                        (current.Value, current.NextNode.Value) = (current.NextNode.Value, current.Value);
                    }
                }
            }
        }

        public Node? SearchBinary(int value)
        {
            int min = 0;
            int max = firstNode.Value;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (value == GetNode(mid).Value)
                {
                    return GetNode(mid);
                }
                else if (value < GetNode(mid).Value)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return null;
        }

        #endregion
    }
}
