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

        public List<DGraph> Execute(DGraph graph)
        {
            var result = new List<DGraph>();
            N = graph.Nodes.Count;
            var g = graph.GetAdjacencyMatrix();
            var g_mirrored = GetMirroredG(g);

            List<int> nodes = new List<int>(N);
            for (int i = 0; i < N; i++)
                nodes.Add(i);

            while (nodes.Count != 0) // Повторяем шаги до тех пор пока в графе есть вершины
            {
                var component = FindComponent(g, g_mirrored, nodes[0]);

                // Сохраняем полученный подграф как новый граф
                var subgraph = new DGraph(graph.IsDirectedGraph);
                foreach (var node in component)
                    ErrorHandler.SafeExec(() => subgraph.AddNode(graph.Nodes[node].Id));

                for (int i = 0; i < component.Count; i++)
                    for (int j = 0; j < component.Count; j++)
                        if (g[component[i]][component[j]] == 1)
                            ErrorHandler.SafeExec(() => subgraph.AddConnection(i, j));

                // Шаг 3. Из исходного графа удалим вершины входящие в состам выделенного сильно связного подграфа
                foreach (var node in component)
                {
                    for (int i = 0; i < N; i++)
                    {
                        g[node][i] = 0;
                        g[i][node] = 0;
                    }
                    nodes.Remove(node);
                }

                result.Add(subgraph);
            }

            return result; // Возвращаем список сильно связных подграфов исходной графа
        }

        private List<int> FindComponent(List<List<int>> g, List<List<int>> g_mirrored, int v)
        {
            List<int> transitiveClosure = new List<int>(new int[N]);
            List<int> revertedTransitiveClosure = new List<int>(new int[N]);

            // Шаг 1(+). Находим прямое транзитивное замыкание
            FindTransitiveClosures(g, transitiveClosure, v, 1);

            // Шаг 1(-). Находим обратное транзитивное замыкание
            FindTransitiveClosures(g_mirrored, revertedTransitiveClosure, v, 1);

            // Шаг 2. Находим Множество образуемое пересечением множеств из Шага 1(+) и Шага 1(-)
            var result = new List<int>();
            for (int i = 0; i < N; i++)
                if (transitiveClosure[i] != 0 && revertedTransitiveClosure[i] != 0)
                    result.Add(i);

            return result; // Результатом первых двух шагов будет сильно связный подграф
        }

        /* Сохраняет в transitiveArray значения указывающие сколько нужно сделать переходов, 
         * чтобы попасть в данную вершину из вершины v (прямое транзитивное замыкание).
         * 
         * Если передать в g вместо обычной матрицы смежности, матрицу смежности отраженную
         * по главной диагонали, то получим количество переходов необходимое, чтобы попасть 
         * из данной вершины в вершину v (обратное транзитивное замыкание). */
        private void FindTransitiveClosures(List<List<int>>g, List<int> transitiveArray, int v, int deep) // Just dfs with deep counter
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

        private List<List<int>> GetMirroredG(List<List<int>> g)
        {
            List<List<int>> matrix = new List<List<int>>(new List<int>[N]);

            for (int i = 0; i < N; i++)
            {
                matrix[i] = new List<int>(new int[N]);
                for (int j = 0; j < N; j++)
                {
                    matrix[i][j] = g[j][i];
                }
            }

            return matrix;
        }
    }
}
