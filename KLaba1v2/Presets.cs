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
                        var net = new DGraph(true);
                        for (int i = 0; i < 11; i++)
                            net.AddNode();

                        net.AddConnection(0, 6);
                        net.AddConnection(1, 0);
                        net.AddConnection(1, 1);
                        net.AddConnection(1, 7);
                        net.AddConnection(1, 10);
                        net.AddConnection(2, 2);
                        net.AddConnection(2, 3);
                        net.AddConnection(2, 8);
                        net.AddConnection(2, 9);
                        net.AddConnection(3, 3);
                        net.AddConnection(3, 4);
                        net.AddConnection(4, 3);
                        net.AddConnection(5, 5);
                        net.AddConnection(5, 7);
                        net.AddConnection(6, 10);
                        net.AddConnection(8, 2);
                        net.AddConnection(9, 0);
                        net.AddConnection(9, 3);
                        net.AddConnection(9, 4);
                        net.AddConnection(9, 8);
                        net.AddConnection(10, 0);
                        net.AddConnection(10, 4);
                        net.AddConnection(10, 5);
                        net.AddConnection(10, 10);

                        return net;
                    }
                },
                new Preset
                {
                    Name = "Пресет 2",
                    Execute = () =>
                    {
                        var net = new DGraph(true);
                        for (int i = 0; i < 15; i++)
                            net.AddNode();

                        net.AddConnection(0, 6);
                        net.AddConnection(0, 12);
                        net.AddConnection(1, 9);
                        net.AddConnection(1, 12);
                        net.AddConnection(2, 5);
                        net.AddConnection(3, 6);
                        net.AddConnection(4, 2);
                        net.AddConnection(5, 4);
                        net.AddConnection(5, 7);
                        net.AddConnection(6, 1);
                        net.AddConnection(6, 2);
                        net.AddConnection(6, 9);
                        net.AddConnection(6, 11);
                        net.AddConnection(6, 12);
                        net.AddConnection(7, 4);
                        net.AddConnection(8, 11);
                        net.AddConnection(8, 12);
                        net.AddConnection(9, 12);
                        net.AddConnection(10, 4);
                        net.AddConnection(10, 13);
                        net.AddConnection(11, 3);
                        net.AddConnection(11, 14);
                        net.AddConnection(12, 7);
                        net.AddConnection(12, 10);
                        net.AddConnection(13, 1);
                        net.AddConnection(13, 10);
                        net.AddConnection(14, 8);
                        net.AddConnection(14, 10);

                        return net;
                    }
                },
                new Preset
                {
                    Name = "Пресет 3",
                    Execute = () =>
                    {
                        var net = new DGraph(true);
                        for (int i = 0; i < 15; i++)
                            net.AddNode();

                        net.AddConnection(0, 7);
                        net.AddConnection(2, 7);
                        net.AddConnection(2, 8);
                        net.AddConnection(2, 14);
                        net.AddConnection(3, 1);
                        net.AddConnection(3, 8);
                        net.AddConnection(3, 12);
                        net.AddConnection(4, 2);
                        net.AddConnection(5, 3);
                        net.AddConnection(5, 6);
                        net.AddConnection(5, 12);
                        net.AddConnection(6, 5);
                        net.AddConnection(7, 9);
                        net.AddConnection(8, 0);
                        net.AddConnection(9, 0);
                        net.AddConnection(10, 1);
                        net.AddConnection(10, 8);
                        net.AddConnection(11, 0);
                        net.AddConnection(11, 4);
                        net.AddConnection(11, 9);
                        net.AddConnection(12, 6);
                        net.AddConnection(12, 7);
                        net.AddConnection(12, 8);
                        net.AddConnection(13, 0);
                        net.AddConnection(13, 3);
                        net.AddConnection(13, 8);
                        net.AddConnection(14, 3);
                        net.AddConnection(14, 4);
                        net.AddConnection(14, 10);
                        net.AddConnection(14, 13);

                        return net;
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
