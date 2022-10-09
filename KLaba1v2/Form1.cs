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
        private DGraph graph;

        public DGraph Graph 
        { 
            get => graph; 
            set
            {
                if (graph != null) UnsubscribeFromGraphEvents();
                graph = value;
                SyncGraphViewer();
                UpdateView();
                SubscribeOnGraphEvents();
                GraphChanged();
            }
        }
        private Form adjacencyMatrixForm;

        public delegate void AdjacencyMatrixUpdatedHandler(DGraph graph);
        public event AdjacencyMatrixUpdatedHandler AdjacencyMatrixUpdatedEventHandler;

        public Form1()
        {
            InitializeComponent();

            foreach (var preset in Presets.Get())
                presetsDropdown.Items.Add(preset.Name);
            presetsDropdown.SelectedIndex = 0;

            Graph = new DGraph(true);
        }

        private void UpdateView()
        {
            if (graph.IsDirectedGraph)
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
            foreach (var node in Graph.Nodes)
                graph.AddNode(node.Id.ToString());

            foreach (var node in Graph.Nodes)
            {
                foreach (var connection in node.Connections)
                    graph.AddEdge(node.Id.ToString(), connection.Id.ToString());
            }

            gViewer.Graph = graph;
        }

        private void SubscribeOnGraphEvents()
        {
            Graph.OnNodeAdded += NodeAdded;
            Graph.OnNodeDeleted += NodeDeleted;
            Graph.OnConnectionAdded += ConnectionAdded;
            Graph.OnConnectionDeleted += ConnectionDeleted;
            Graph.OnGraphChanged += GraphChanged;
        }

        private void UnsubscribeFromGraphEvents()
        {
            Graph.OnNodeAdded -= NodeAdded;
            Graph.OnNodeDeleted -= NodeDeleted;
            Graph.OnConnectionAdded -= ConnectionAdded;
            Graph.OnConnectionDeleted -= ConnectionDeleted;
            Graph.OnGraphChanged -= GraphChanged;
        }

        private void GraphChanged()
        {
            foreach (var entity in gViewer.Entities)
                if (entity.MarkedForDragging)
                {
                    entity.MarkedForDragging = false;
                }

            gViewer.Graph = gViewer.Graph; // Force redrawing graph

            if (Application.OpenForms.OfType<AdjacencyMatrix>().Count() > 0)
            {
                AdjacencyMatrixUpdatedEventHandler?.Invoke(graph);
            }

            if (tbCountElems.Text != gViewer.Graph.NodeCount.ToString())
                tbCountElems.Text = gViewer.Graph.NodeCount.ToString(); // Update nodes count
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
            Node newNode = null;
            ErrorHandler.SafeExec(() => { newNode = graph.AddNode(); });
            if (newNode != null)
                gViewer.Graph.AddNode(newNode.Id.ToString());
        }

        private void btnCreateGraph_Click(object sender, EventArgs e)
        {
            Graph = new DGraph();
        }

        private void btnCreateDirectedGraph_Click(object sender, EventArgs e)
        {
            Graph = new DGraph(true);
        }

        private void btnDelElem_Click(object sender, EventArgs e)
        {
            ErrorHandler.SafeExec(() => Graph.DeleteNodeById(Convert.ToInt32(tbDelElem.Text)));
        }

        private void btnAddCon_Click(object sender, EventArgs e)
        {
            ErrorHandler.SafeExec(() => Graph.AddConnectionByIds(Convert.ToInt32(tbAddCon1.Text), Convert.ToInt32(tbAddCon2.Text)));
        }

        private void btnDelCon_Click(object sender, EventArgs e)
        {
            ErrorHandler.SafeExec(() => Graph.DeleteConnectionByIds(Convert.ToInt32(tbDelCon1.Text), Convert.ToInt32(tbDelCon2.Text)));
        }

        private void btnShowAdjacencyMatrix_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AdjacencyMatrix>().Count() > 0)
                adjacencyMatrixForm.Close();

            adjacencyMatrixForm = new AdjacencyMatrix(Graph);
            adjacencyMatrixForm.StartPosition = FormStartPosition.CenterScreen;
            adjacencyMatrixForm.Show(this);
        }

        private List<DrawingColor> colors = new List<DrawingColor>()
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
            ExecuteMalgrangeAlgorithm();
        }

        private List<DGraph> ExecuteMalgrangeAlgorithm(bool skipRender = false)
        {
            var random = new Random();
            var malgrangeAlgo = new MalgrangeAlgorithm();
            var malgrangeAlgorithmResult = malgrangeAlgo.Execute(graph);

            if (!skipRender)
            {
                var currentColorIndex = 0;
                foreach (var subgraph in malgrangeAlgorithmResult)
                {
                    foreach (var node in subgraph.Nodes)
                    {
                        var foundNode = gViewer.Graph.FindNode(node.Id.ToString());
                        foundNode.Attr.FillColor = currentColorIndex < colors.Count ? colors[currentColorIndex] : new DrawingColor((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
                    }
                    currentColorIndex++;
                }
                gViewer.Refresh();
            }

            return malgrangeAlgorithmResult;
        }

        private void btnUsePreset_Click(object sender, EventArgs e)
        {
            Graph = Presets.Get()[presetsDropdown.SelectedIndex].Execute();
        }

        private void gViewer_EdgeAdded(object sender, EventArgs e)
        {
            var edge = (Edge)sender;
            var startNodeId = int.Parse(edge.Source);
            var endNodeId = int.Parse(edge.Target);

            Graph.Silent = true;
            ErrorHandler.SafeExec(() => Graph.AddConnectionByIds(startNodeId, endNodeId));
        }

        private void gViewer_EdgeRemoved(object sender, EventArgs e)
        {
            var edge = (Edge)sender;
            var startNodeId = int.Parse(edge.Source);
            var endNodeId = int.Parse(edge.Target);

            Graph.Silent = true;
            ErrorHandler.SafeExec(() => Graph.DeleteConnectionByIds(startNodeId, endNodeId));
        }

        private void btnGenerateGraph_Click(object sender, EventArgs e)
        {
            var countOfNodes = int.Parse(tbCountNodesToGenerate.Text);
            var edgeProbability = int.Parse(tbProbabilityOfEdge.Text);

            Graph = new DGraph(countOfNodes, edgeProbability, true);

            ExecuteMalgrangeAlgorithm();
        }

        private async void gViewer_MouseUp(object sender, MouseEventArgs e)
        {
            await Task.Delay(10); // If no delay method calls before elements marked selected
            var selectedNodes = new List<IViewerNode>();
            foreach (var entity in gViewer.Entities)
                if (entity.MarkedForDragging && entity is IViewerNode viewerNode)
                {
                    selectedNodes.Add(viewerNode);
                }

            var selectedNodeId = "-1";
            var secondNodeId = "-1";
            if (selectedNodes.Count == 1 || selectedNodes.Count == 2)
            {
                selectedNodeId = (gViewer.SelectedObject as Microsoft.Msagl.Drawing.Node).Id;
            }
            if (selectedNodes.Count == 2)
            {
                secondNodeId = selectedNodes.First(n => n.Node.Id != selectedNodeId).Node.Id;
                (selectedNodeId, secondNodeId) = (secondNodeId, selectedNodeId);
            }


            if (gViewer.SelectedObject is Edge edge)
            {
                selectedNodeId = edge.Source;
                secondNodeId = edge.Target;
            }


            if (selectedNodeId != "-1")
            {
                tbDelElem.Text = selectedNodeId;
                tbDelCon1.Text = selectedNodeId;
                tbAddCon1.Text = selectedNodeId;
            }
            if (selectedNodeId != "-1" && secondNodeId == "-1")
            {
                secondNodeId = selectedNodeId;
            }
            if (secondNodeId != "-1")
            {
                tbDelCon2.Text = secondNodeId;
                tbAddCon2.Text = secondNodeId;
            }
        }

        private void btnConsoleWritePreset_Click(object sender, EventArgs e)
        {
            Console.WriteLine("-------->Print preset connections:");
            foreach (var node in Graph.Nodes)
            {
                foreach (var targetNode in node.Connections)
                {
                    Console.WriteLine($"graph.AddConnection({Graph.Nodes.IndexOf(node)}, {Graph.Nodes.IndexOf(targetNode)});");
                }
            }
            Console.WriteLine("-------->End of preset connections list");
        }
    }
}
