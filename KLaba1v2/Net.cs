using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDesigner
{
    public class Net
    {
        private int autoincrementCounter = 0;
        private int count;
        private int sum;

        public readonly bool IsDirectedGraph = false;

        public List<Node> Nodes;

        public Net(bool isDirectedGraph = false)
        {
            count = 0;
            Nodes = new List<Node>();
            IsDirectedGraph = isDirectedGraph;
        }

        public string AddNode(int id, int value = 0)
        {
            if (Nodes.Any(n => n.Id == id)) return $"Не удалось создать элемент с id = {id}, так как элемент с таким id уже существует";

            Node newNode = new Node(id, value);
            Nodes.Add(newNode);
            count++;
            sum += value;

            return "";
        }

        public void AddNode(int value = 0)
        {
            Node newNode = new Node(autoincrementCounter++, value);
            Nodes.Add(newNode);
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

            sum -= Nodes[ind].Value;
            Nodes.RemoveAt(ind);
            count--;

            return "";
        }

        public string AddConnection(int startNode, int endNode)
        {
            if (startNode >= count || startNode < 0) return $"Элемент с индексом '{startNode}' не найден";
            if (endNode >= count || endNode < 0) return $"Элемент с индексом '{endNode}' не найден";
            if (Nodes[startNode].Connections.Contains(Nodes[endNode])) return $"Заданная связь '{startNode}' - '{endNode}' уже существует";

            Nodes[startNode].AddConnection(Nodes[endNode]);
            if (!IsDirectedGraph)
                Nodes[endNode].AddConnection(Nodes[startNode]);

            return "";
        }

        public string DeleteConnection(int startNode, int endNode)
        {
            if (startNode >= count || startNode < 0) return $"Элемент с индексом '{startNode}' не найден";
            if (endNode >= count || endNode < 0) return $"Элемент с индексом '{endNode}' не найден";
            if (!Nodes[startNode].Connections.Contains(Nodes[endNode])) return $"Заданная связь '{startNode}' - '{endNode}' не найдена";

            Nodes[startNode].DeleteConnection(Nodes[endNode]);
            if (!IsDirectedGraph)
                Nodes[endNode].DeleteConnection(Nodes[startNode]);

            return "";
        }

        public string ChangeNodeValue(int ind, int newValue)
        {
            if (ind >= count || ind < 0) return $"Элемент с индексом '{ind}' не найден";

            sum -= Nodes[ind].Value - newValue;
            Nodes[ind].ChangeValue(newValue);

            return "";
        }

        public int Count() => count;
        public int Sum() => sum;

        public int GetValue(int ind) => Nodes[ind].Value;
        public Node GetNode(int ind) => Nodes[ind];
        public int GetIndex(Node node) => Nodes.IndexOf(node);

        public List<List<int>> GetAdjacencyMatrix()
        {
            List<List<int>> matrix = new List<List<int>>(new List<int>[count]);

            for (int i = 0; i < count; i++)
            {
                matrix[i] = new List<int>(new int[count]);
                for (int j = 0; j < Nodes[i].Connections.Count; j++)
                {
                    int targetNodeIndex = Nodes.IndexOf(Nodes[i].Connections[j]);
                    matrix[i][targetNodeIndex] = 1;
                }
            }

            return matrix;
        }
    }

    public class Node
    {
        public int Id;
        public int Value;
        public List<Node> Connections;

        public Node(int id, int value)
        {
            Id = id;
            Value = value;
            Connections = new List<Node>();
        }

        public void AddConnection(Node a)
        {
            Connections.Add(a);
        }

        public void DeleteConnection(Node a)
        {
            Connections.Remove(a);
        }

        public void ChangeValue(int newValue)
        {
            Value = newValue;
        }
    }
}
