using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphDesigner
{
    public static class ErrorHandler
    {
        public static void SafeExec(Action action)
        {
            try
            {
                action();
            }
            catch (GraphOperationException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
