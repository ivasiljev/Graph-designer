using Microsoft.Msagl.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphDesigner
{
    public partial class Form1 : Form
    {
        private Net net;
        private Form adjacencyMatrixForm;

        public delegate void AdjacencyMatrixUpdatedHandler(Net net);
        public event AdjacencyMatrixUpdatedHandler AdjacencyMatrixUpdatedEventHandler;

        public Form1()
        {
            InitializeComponent();

            foreach (var preset in Presets.Get())
                presetsDropdown.Items.Add(preset.Name);
            presetsDropdown.SelectedIndex = 0;

            net = new Net(true);
            RefreshViewer();
        }

        void RefreshViewer()
        {
            Graph graph = new Graph();
            foreach (var node in net.Nodes)
                graph.AddNode(node.Id.ToString());

            foreach (var node in net.Nodes)
            {
                foreach (var connection in node.Connections)
                    graph.AddEdge(node.Id.ToString(), connection.Id.ToString());
            }

            gViewer.Graph = graph;

            if (Application.OpenForms.OfType<AdjacencyMatrix>().Count() > 0)
            {
                AdjacencyMatrixUpdatedEventHandler?.Invoke(net);
            }
        }

        private void btnAddElem_Click(object sender, EventArgs e)
        {
            var newNode = net.AddNode();
            gViewer.Graph.AddNode(newNode.Id.ToString());
        }

        private void btnCreateNet_Click(object sender, EventArgs e)
        {
            net = new Net();
            RefreshViewer();
            checkBoxGraphType.Checked = false;
        }

        private void btnCreateDirectedGraph_Click(object sender, EventArgs e)
        {
            net = new Net(true);
            RefreshViewer();
            checkBoxGraphType.Checked = true;
        }

        private void btnDelElem_Click(object sender, EventArgs e)
        {
            net.DeleteNodeById(Convert.ToInt32(tbDelElem.Text));
        }

        private void btnAddCon_Click(object sender, EventArgs e)
        {
            net.AddConnectionByIds(Convert.ToInt32(tbAddCon1.Text), Convert.ToInt32(tbAddCon2.Text));
        }

        private void btnDelCon_Click(object sender, EventArgs e)
        {
            net.DeleteConnectionByIds(Convert.ToInt32(tbDelCon1.Text), Convert.ToInt32(tbDelCon2.Text));
        }

        private void btnShowAdjacencyMatrix_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AdjacencyMatrix>().Count() > 0)
                adjacencyMatrixForm.Close();

            adjacencyMatrixForm = new AdjacencyMatrix(net);
            adjacencyMatrixForm.StartPosition = FormStartPosition.CenterParent;
            adjacencyMatrixForm.Show(this);
        }

        List<Microsoft.Msagl.Drawing.Color> colors = new List<Microsoft.Msagl.Drawing.Color>()
        {
            Microsoft.Msagl.Drawing.Color.Red,
            Microsoft.Msagl.Drawing.Color.Green,
            Microsoft.Msagl.Drawing.Color.Blue,
            Microsoft.Msagl.Drawing.Color.Magenta,
            Microsoft.Msagl.Drawing.Color.Yellow,
            Microsoft.Msagl.Drawing.Color.Aqua,
            Microsoft.Msagl.Drawing.Color.MintCream,
            Microsoft.Msagl.Drawing.Color.Coral,
        };

        private void btnExecuteMalgrangeAlgo_Click(object sender, EventArgs e)
        {
            var malgrangeAlgo = new MalgrangeAlgorithm();
            var malgrangeAlgorithmResult = malgrangeAlgo.Execute(net);

            var currentColorIndex = 0;
            foreach (var net in malgrangeAlgorithmResult)
            {
                foreach (var node in net.Nodes)
                {
                    var foundNode = gViewer.Graph.FindNode(node.Id.ToString());
                    foundNode.Attr.FillColor = colors[currentColorIndex];
                }
                currentColorIndex++;
            }
            gViewer.Refresh();
        }

        private void btnUsePreset_Click(object sender, EventArgs e)
        {
            net = Presets.Get()[presetsDropdown.SelectedIndex].Execute();
            RefreshViewer();
        }

        private void gViewer_EdgeAdded(object sender, EventArgs e)
        {
            var edge = (Edge)sender;
            var startNodeId = Int32.Parse(edge.Source);
            var endNodeId = Int32.Parse(edge.Target);

            net.Silent = true;
            net.AddConnectionByIds(startNodeId, endNodeId);
        }
    }
}
