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
                        var net = new Net(true);
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
                }
            };
        }
    }

    public class Preset
    {
        public Func<Net> Execute;
        public string Name;
    }
}
