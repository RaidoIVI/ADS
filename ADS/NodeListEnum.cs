using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS
{
    internal class NodeListEnum : IEnumerator
    {
        private Node firstNode;
        private Node lastNode;
        private Node currentNode;

        public NodeListEnum (Node firstNode, Node lastNode)
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
