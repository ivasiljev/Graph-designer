using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDesigner
{
    [Serializable()]
    public class GraphOperationException : Exception
    {
        public GraphOperationException(string message) : base(message)
        { }
    }
}
