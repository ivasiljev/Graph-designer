using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphDesigner
{
    public class Net
    {
        private int autoincrementCounter = 0;

        public readonly bool IsDirectedGraph = false;

        public List<Node> Nodes { get; set; }
        public bool Silent { get; set; } = false;

        public delegate void NodeAddedHandler(Node node);
        public event NodeAddedHandler OnNodeAdded;

        public delegate void NodeDeletedHandler(Node node);
        public event NodeDeletedHandler OnNodeDeleted;

        public delegate void ConnectionAddedHandler(Tuple<Node, Node> connection);
        public event ConnectionAddedHandler OnConnectionAdded;

        public delegate void ConnectionDeletedHandler(Tuple<Node, Node> connection);
        public event ConnectionDeletedHandler OnConnectionDeleted;

        public delegate void GraphChangedHandler();
        public event GraphChangedHandler OnGraphChanged;

        public Net(bool isDirectedGraph = false)
        {
            Nodes = new List<Node>();
            IsDirectedGraph = isDirectedGraph;
        }

        public Node AddNode(int id)
        {
            if (Nodes.Any(n => n.Id == id)) throw new GraphOperationException($"Не удалось создать элемент с id = {id}, так как элемент с таким id уже существует");

            Node newNode = new Node(id);
            Nodes.Add(newNode);

            if (id >= autoincrementCounter) autoincrementCounter = id + 1;

            if (!IsSilent())
            {
                OnNodeAdded?.Invoke(newNode);
                OnGraphChanged?.Invoke();
            }

            return newNode;
        }

        public Node AddNode()
        {
            return AddNode(autoincrementCounter);
        }

        public void DeleteNode(int ind)
        {
            if (ind >= Nodes.Count || ind < 0) throw new GraphOperationException($"Элемент с индексом '{ind}' не найден");

            for (int i = 0; i < Nodes.Count; i++)
            {
                if (i == ind) continue;

                DeleteConnection(i, ind);
            }

            var nodeToDel = Nodes[ind];
            Nodes.Remove(nodeToDel);

            if (!IsSilent())
            {
                OnNodeDeleted?.Invoke(nodeToDel);
                OnGraphChanged?.Invoke();
            }
        }

        public void DeleteNodeById(int id)
        {
            var targetNode = GetNodeById(id);

            DeleteNode(Nodes.IndexOf(targetNode));
        }

        public void AddConnection(Node startNode, Node endNode)
        {
            if (startNode.Connections.Contains(endNode)) throw new GraphOperationException($"Заданная связь '{startNode.Id}' - '{endNode.Id}' уже существует");

            startNode.AddConnection(endNode);
            if (!IsDirectedGraph)
                endNode.AddConnection(startNode);

            if (!IsSilent())
            {
                OnConnectionAdded?.Invoke(new Tuple<Node, Node>(startNode, endNode));
                OnGraphChanged?.Invoke();
            }
        }

        public void AddConnection(int startNodeIndex, int endNodeIndex)
        {
            if (startNodeIndex >= Nodes.Count || startNodeIndex < 0) throw new GraphOperationException($"Элемент с индексом '{startNodeIndex}' не найден");
            if (endNodeIndex >= Nodes.Count || endNodeIndex < 0) throw new GraphOperationException($"Элемент с индексом '{endNodeIndex}' не найден");

            AddConnection(Nodes[startNodeIndex], Nodes[endNodeIndex]);
        }

        public void AddConnectionByIds(int startNodeId, int endNodeId)
        {
            var startNode = GetNodeById(startNodeId);
            var endNode = GetNodeById(endNodeId);

            AddConnection(startNode, endNode);
        }

        public void DeleteConnection(Node startNode, Node endNode)
        {
            if (!startNode.Connections.Contains(endNode)) throw new GraphOperationException($"Заданная связь '{startNode.Id}' - '{endNode.Id}' не найдена");

            startNode.DeleteConnection(endNode);
            if (!IsDirectedGraph)
                endNode.DeleteConnection(startNode);

            if (!IsSilent())
            {
                OnConnectionDeleted?.Invoke(new Tuple<Node, Node>(startNode, endNode));
                OnGraphChanged?.Invoke();
            }
        }

        public void DeleteConnection(int startNodeIndex, int endNodeIndex)
        {
            if (startNodeIndex >= Nodes.Count || startNodeIndex < 0) throw new GraphOperationException($"Элемент с индексом '{startNodeIndex}' не найден");
            if (endNodeIndex >= Nodes.Count || endNodeIndex < 0) throw new GraphOperationException($"Элемент с индексом '{endNodeIndex}' не найден");

            DeleteConnection(Nodes[startNodeIndex], Nodes[endNodeIndex]);
        }

        public void DeleteConnectionByIds(int startNodeId, int endNodeId)
        {
            var startNode = GetNodeById(startNodeId);
            var endNode = GetNodeById(endNodeId);

            DeleteConnection(startNode, endNode);
        }

        public List<List<int>> GetAdjacencyMatrix()
        {
            List<List<int>> matrix = new List<List<int>>(new List<int>[Nodes.Count]);

            for (int i = 0; i < Nodes.Count; i++)
            {
                matrix[i] = new List<int>(new int[Nodes.Count]);
                for (int j = 0; j < Nodes[i].Connections.Count; j++)
                {
                    int targetNodeIndex = Nodes.IndexOf(Nodes[i].Connections[j]);
                    matrix[i][targetNodeIndex] = 1;
                }
            }

            return matrix;
        }

        public Node GetNodeById(int id)
        {
            var node = Nodes.FirstOrDefault(n => n.Id == id);
            if (node == null) throw new GraphOperationException($"Элемент с id = '{id}' не найден");
            return node;
        }

        private bool IsSilent()
        {
            if (Silent)
            {
                Silent = false;
                return true;
            }
            return false;
        }
    }

    public class Node
    {
        public int Id;
        public List<Node> Connections;

        public Node(int id)
        {
            Id = id;
            Connections = new List<Node>();
        }

        public void AddConnection(Node a)
        {
            if (a == null) throw new GraphOperationException("Элемент, с которым добавляется связь не найден");

            Connections.Add(a);
        }

        public void DeleteConnection(Node a)
        {
            if (a == null) throw new GraphOperationException("Элемент, с которым добавляется связь не найден");

            Connections.Remove(a);
        }
    }
}
