using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLaba1v2
{
    public class Net
    {
        //public const bool AUTO_INCREMENT_VALUE_ENABLED = true;
        private int autoincrementCounter = 0;

        public readonly bool IsDirectedGraph = false;

        private List<Node> nodes;
        private int count;
        private int sum;

        public Net(bool isDirectedGraph = false)
        {
            count = 0;
            nodes = new List<Node>();
            IsDirectedGraph = isDirectedGraph;
        }

        public void AddNode(int value)
        {
            Node newNode = new Node(value);
            nodes.Add(newNode);
            count++;
            sum += value;
        }

        public string DeleteNode(int ind)
        {
            if (ind >= count || ind < 0) return $"Элемент с индексом '{ind}' не найден";

            for (int i = 0; i < count; i++)
            {
                if (i == ind) continue;

                DeleteConnection(i, ind);
            }

            sum -= nodes[ind].value;
            nodes.RemoveAt(ind);
            count--;

            return "";
        }

        public string AddConnection(int startNode, int endNode)
        {
            if (startNode >= count || startNode < 0) return $"Элемент с индексом '{startNode}' не найден";
            if (endNode >= count || endNode < 0) return $"Элемент с индексом '{endNode}' не найден";
            if (nodes[startNode].cons.Contains(nodes[endNode])) return $"Заданная связь '{startNode}' - '{endNode}' уже существует";

            nodes[startNode].AddConnection(nodes[endNode]);
            if (!IsDirectedGraph)
                nodes[endNode].AddConnection(nodes[startNode]);

            return "";
        }

        public string DeleteConnection(int startNode, int endNode)
        {
            if (startNode >= count || startNode < 0) return $"Элемент с индексом '{startNode}' не найден";
            if (endNode >= count || endNode < 0) return $"Элемент с индексом '{endNode}' не найден";
            if (!nodes[startNode].cons.Contains(nodes[endNode])) return $"Заданная связь '{startNode}' - '{endNode}' не найдена";

            nodes[startNode].DeleteConnection(nodes[endNode]);
            if (!IsDirectedGraph)
                nodes[endNode].DeleteConnection(nodes[startNode]);

            return "";
        }

        public string ChangeNodeValue(int ind, int newValue)
        {
            if (ind >= count || ind < 0) return $"Элемент с индексом '{ind}' не найден";

            sum -= nodes[ind].value - newValue;
            nodes[ind].ChangeValue(newValue);

            return "";
        }

        public int Count() => count;
        public int Sum() => sum;

        public int GetValue(int ind) => nodes[ind].value;
        public Node GetNode(int ind) => nodes[ind];
        public int GetIndex(Node node) => nodes.IndexOf(node);

        public List<List<int>> GetAdjacencyMatrix()
        {
            List<List<int>> matrix = new List<List<int>>(new List<int>[count]);

            for (int i = 0; i < count; i++)
            {
                matrix[i] = new List<int>(new int[count]);
                for (int j = 0; j < nodes[i].cons.Count; j++)
                {
                    int targetNodeIndex = nodes.IndexOf(nodes[i].cons[j]);
                    matrix[i][targetNodeIndex] = 1;
                }
            }

            return matrix;
        }
    }

    public class Node
    {
        public int Id;
        public int value;
        public List<Node> cons;

        public Node(int x)
        {
            value = x;
            cons = new List<Node>();
        }

        public void AddConnection(Node a)
        {
            cons.Add(a);
        }

        public void DeleteConnection(Node a)
        {
            cons.Remove(a);
        }

        public void ChangeValue(int newValue)
        {
            value = newValue;
        }
    }
}
