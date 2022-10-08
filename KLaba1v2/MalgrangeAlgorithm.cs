using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDesigner
{
    public class MalgrangeAlgorithm
    {
        private int N = 0;

        public MalgrangeAlgorithm() { }

        public List<Net> Execute(Net net)
        {
            var result = new List<Net>();
            N = net.Nodes.Count;
            var g = net.GetAdjacencyMatrix();

            List<int> nodes = new List<int>(N);
            for (int i = 0; i < N; i++)
                nodes.Add(i);

            while (nodes.Count != 0)
            {
                var component = FindComponent(g, nodes[0]);

                foreach (var node in component)
                    nodes.Remove(node);

                var newNet = new Net(net.IsDirectedGraph);
                foreach (var node in component)
                    newNet.AddNode(net.GetNode(node).Id);

                for (int i = 0; i < component.Count; i++)
                    for (int j = 0; j < component.Count; j++)
                        if (g[component[i]][component[j]] == 1)
                            newNet.AddConnection(j, i); // j and i swapped coz we have mirrored g

                result.Add(newNet);
            }

            return result;
        }

        private List<int> FindComponent(List<List<int>> g, int v)
        {
            List<int> transitiveClosure = new List<int>(new int[N]);
            List<int> revertedTransitiveClosure = new List<int>(new int[N]);

            FindTransitiveClosures(g, transitiveClosure, v, 1);

            for (int i = 0; i < N - 1; i++)
                for (int j = i + 1; j < N; j++)
                    (g[i][j], g[j][i]) = (g[j][i], g[i][j]); // Отражаем по главной диагонали
            FindTransitiveClosures(g, revertedTransitiveClosure, v, 1);

            var result = new List<int>();
            for (int i = 0; i < N; i++)
                if (transitiveClosure[i] != 0 && revertedTransitiveClosure[i] != 0)
                    result.Add(i);
            return result;
        }

        private void FindTransitiveClosures(List<List<int>>g, List<int> transitiveArray, int v, int deep)
        {
            transitiveArray[v] = deep;

            for (int i = 0; i < N; i++)
            {
                if (g[v][i] == 1 && transitiveArray[i] == 0)
                {
                    FindTransitiveClosures(g, transitiveArray, i, deep + 1);
                }
            }
        }
    }
}
