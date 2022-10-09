using Microsoft.Msagl.Core.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDesigner
{
    public static class Presets
    {
        public static List<Preset> Get()
        {
            return new List<Preset>()
            {
                new Preset
                {
                    Name = "Пресет 1",
                    Execute = () =>
                    {
                        var graph = new DGraph(true);
                        for (int i = 0; i < 11; i++)
                            graph.AddNode();

                        graph.AddConnection(0, 6);
                        graph.AddConnection(1, 0);
                        graph.AddConnection(1, 1);
                        graph.AddConnection(1, 7);
                        graph.AddConnection(1, 10);
                        graph.AddConnection(2, 2);
                        graph.AddConnection(2, 3);
                        graph.AddConnection(2, 8);
                        graph.AddConnection(2, 9);
                        graph.AddConnection(3, 3);
                        graph.AddConnection(3, 4);
                        graph.AddConnection(4, 3);
                        graph.AddConnection(5, 5);
                        graph.AddConnection(5, 7);
                        graph.AddConnection(6, 10);
                        graph.AddConnection(8, 2);
                        graph.AddConnection(9, 0);
                        graph.AddConnection(9, 3);
                        graph.AddConnection(9, 4);
                        graph.AddConnection(9, 8);
                        graph.AddConnection(10, 0);
                        graph.AddConnection(10, 4);
                        graph.AddConnection(10, 5);
                        graph.AddConnection(10, 10);

                        return graph;
                    }
                },
                new Preset
                {
                    Name = "Пресет 2",
                    Execute = () =>
                    {
                        var graph = new DGraph(true);
                        for (int i = 0; i < 15; i++)
                            graph.AddNode();

                        graph.AddConnection(0, 6);
                        graph.AddConnection(0, 12);
                        graph.AddConnection(1, 9);
                        graph.AddConnection(1, 12);
                        graph.AddConnection(2, 5);
                        graph.AddConnection(3, 6);
                        graph.AddConnection(4, 2);
                        graph.AddConnection(5, 4);
                        graph.AddConnection(5, 7);
                        graph.AddConnection(6, 1);
                        graph.AddConnection(6, 2);
                        graph.AddConnection(6, 9);
                        graph.AddConnection(6, 11);
                        graph.AddConnection(6, 12);
                        graph.AddConnection(7, 4);
                        graph.AddConnection(8, 11);
                        graph.AddConnection(8, 12);
                        graph.AddConnection(9, 12);
                        graph.AddConnection(10, 4);
                        graph.AddConnection(10, 13);
                        graph.AddConnection(11, 3);
                        graph.AddConnection(11, 14);
                        graph.AddConnection(12, 7);
                        graph.AddConnection(12, 10);
                        graph.AddConnection(13, 1);
                        graph.AddConnection(13, 10);
                        graph.AddConnection(14, 8);
                        graph.AddConnection(14, 10);

                        return graph;
                    }
                },
                new Preset
                {
                    Name = "Пресет 3",
                    Execute = () =>
                    {
                        var graph = new DGraph(true);
                        for (int i = 0; i < 15; i++)
                            graph.AddNode();

                        graph.AddConnection(0, 7);
                        graph.AddConnection(2, 7);
                        graph.AddConnection(2, 8);
                        graph.AddConnection(2, 14);
                        graph.AddConnection(3, 1);
                        graph.AddConnection(3, 8);
                        graph.AddConnection(3, 12);
                        graph.AddConnection(4, 2);
                        graph.AddConnection(4, 11);
                        graph.AddConnection(5, 3);
                        graph.AddConnection(5, 6);
                        graph.AddConnection(5, 12);
                        graph.AddConnection(6, 5);
                        graph.AddConnection(7, 9);
                        graph.AddConnection(7, 11);
                        graph.AddConnection(8, 0);
                        graph.AddConnection(9, 0);
                        graph.AddConnection(10, 1);
                        graph.AddConnection(10, 8);
                        graph.AddConnection(11, 0);
                        graph.AddConnection(11, 9);
                        graph.AddConnection(12, 6);
                        graph.AddConnection(12, 7);
                        graph.AddConnection(12, 8);
                        graph.AddConnection(13, 0);
                        graph.AddConnection(13, 3);
                        graph.AddConnection(13, 8);
                        graph.AddConnection(14, 3);
                        graph.AddConnection(14, 4);
                        graph.AddConnection(14, 10);
                        graph.AddConnection(14, 13);

                        return graph;
                    }
                }
            };
        }
    }

    public class Preset
    {
        public Func<DGraph> Execute;
        public string Name;
    }
}
