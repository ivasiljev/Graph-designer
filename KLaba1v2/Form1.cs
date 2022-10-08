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
using DrawingColor = Microsoft.Msagl.Drawing.Color;

namespace GraphDesigner
{
    public partial class Form1 : Form
    {
        private Net net;

        public Net Net 
        { 
            get => net; 
            set
            {
                if (net != null) UnsubscribeFromNetEvents();
                net = value;
                SyncGraphViewer();
                UpdateView();
                SubscribeOnNetEvents();
                GraphChanged();
            }
        }
        private Form adjacencyMatrixForm;

        public delegate void AdjacencyMatrixUpdatedHandler(Net net);
        public event AdjacencyMatrixUpdatedHandler AdjacencyMatrixUpdatedEventHandler;

        public Form1()
        {
            InitializeComponent();

            foreach (var preset in Presets.Get())
                presetsDropdown.Items.Add(preset.Name);
            presetsDropdown.SelectedIndex = 0;

            Net = new Net(true);
        }

        private void UpdateView()
        {
            if (net.IsDirectedGraph)
            {
                lblArrow1.Text = "→";
                lblArrow2.Text = "→";
                radioGraphType1.Checked = true;
                radioGraphType2.Checked = false;
            }
            else
            {
                lblArrow1.Text = "—";
                lblArrow2.Text = "—";
                radioGraphType1.Checked = false;
                radioGraphType2.Checked = true;
            }
        }

        private void SyncGraphViewer()
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
        }

        private void SubscribeOnNetEvents()
        {
            net.OnNodeAdded += NodeAdded;
            net.OnNodeDeleted += NodeDeleted;
            net.OnConnectionAdded += ConnectionAdded;
            net.OnConnectionDeleted += ConnectionDeleted;
            net.OnGraphChanged += GraphChanged;
        }

        private void UnsubscribeFromNetEvents()
        {
            net.OnNodeAdded -= NodeAdded;
            net.OnNodeDeleted -= NodeDeleted;
            net.OnConnectionAdded -= ConnectionAdded;
            net.OnConnectionDeleted -= ConnectionDeleted;
            net.OnGraphChanged -= GraphChanged;
        }

        private void GraphChanged()
        {
            gViewer.Graph = gViewer.Graph; // Force redrawing graph

            if (Application.OpenForms.OfType<AdjacencyMatrix>().Count() > 0)
            {
                AdjacencyMatrixUpdatedEventHandler?.Invoke(net);
            }
        }

        private void ConnectionDeleted(Tuple<Node, Node> connection)
        {
            var targetEdge = gViewer.Graph.Edges.FirstOrDefault(e => e.Source == connection.Item1.Id.ToString() && e.Target == connection.Item2.Id.ToString());
            if (targetEdge == null)
                throw new Exception($"Failed to delete connection {connection.Item1.Id} - {connection.Item2.Id} from gViewer");

            gViewer.Graph.RemoveEdge(targetEdge);
        }

        private void ConnectionAdded(Tuple<Node, Node> connection)
        {
            gViewer.Graph.AddEdge(connection.Item1.Id.ToString(), connection.Item2.Id.ToString());
        }

        private void NodeDeleted(Node node)
        {
            var targetNode = gViewer.Graph.FindNode(node.Id.ToString());
            gViewer.Graph.RemoveNode(targetNode);
        }

        private void NodeAdded(Node node)
        {
            gViewer.Graph.AddNode(node.Id.ToString());
        }

        private void btnAddElem_Click(object sender, EventArgs e)
        {
            var newNode = net.AddNode();
            gViewer.Graph.AddNode(newNode.Id.ToString());
        }

        private void btnCreateNet_Click(object sender, EventArgs e)
        {
            Net = new Net();
        }

        private void btnCreateDirectedGraph_Click(object sender, EventArgs e)
        {
            Net = new Net(true);
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
            adjacencyMatrixForm.StartPosition = FormStartPosition.CenterScreen;
            adjacencyMatrixForm.Show(this);
        }

        List<DrawingColor> colors = new List<DrawingColor>()
        {
            DrawingColor.Red,
            DrawingColor.Green,
            DrawingColor.Blue,
            DrawingColor.Magenta,
            DrawingColor.Yellow,
            DrawingColor.Aqua,
            DrawingColor.MintCream,
            DrawingColor.Coral,
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
            Net = Presets.Get()[presetsDropdown.SelectedIndex].Execute();
        }

        private void gViewer_EdgeAdded(object sender, EventArgs e)
        {
            var edge = (Edge)sender;
            var startNodeId = int.Parse(edge.Source);
            var endNodeId = int.Parse(edge.Target);

            net.Silent = true;
            net.AddConnectionByIds(startNodeId, endNodeId);
        }
    }
}
