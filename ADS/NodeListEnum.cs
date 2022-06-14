using System.Collections;

namespace ADS
{
    internal class NodeListEnum : IEnumerator
    {
        private readonly Node firstNode;
        private readonly Node lastNode;
        private Node currentNode;

        public NodeListEnum(Node firstNode, Node lastNode)
        {
            currentNode = firstNode;
            this.firstNode = firstNode;
            this.lastNode = lastNode;
        }

        public void Reset()
        {
            currentNode = firstNode;
        }

        public bool MoveNext()
        {
            if (currentNode.NextNode == lastNode)
            {
                return false;
            }
            else
            {
                currentNode = currentNode.NextNode;
                return true;
            }
        }

        public object Current => currentNode;
    }
}
