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
        //private const int CIRCLE_RADIUS = 20;
        //private const int TOP_MARGIN = 120;
        //private const int LEFT_MARGIN = 0;

        private Net net;
        private Form adjacencyMatrixForm;

        public delegate void AdjacencyMatrixUpdatedHandler(Net net);
        public event AdjacencyMatrixUpdatedHandler AdjacencyMatrixUpdatedEventHandler;

        public Form1()
        {
            InitializeComponent();
            //lbl = new List<Label>();
            //this.Paint += Form1_Paint;
            //pts = new Dictionary<Node, Point>();

            foreach (var preset in Presets.Get())
                presetsDropdown.Items.Add(preset.Name);
            presetsDropdown.SelectedIndex = 0;

            net = new Net(true);
            RefreshView();
        }

        //private void DrawTextInCircle(Point p, int ind, int val)
        //{
        //    Point pos = new Point(p.X + LEFT_MARGIN + 10, p.Y + TOP_MARGIN + 10);
        //    Label l = new Label();
        //    l.Location = pos;
        //    l.Text = "[" + ind + "]\n" + val;
        //    l.Font = new Font("Courier New", 7);
        //    l.BackColor = Color.FromArgb(0, 0, 0, 0);
        //    l.AutoSize = true;
        //    lbl.Add(l);
        //    Controls.Add(l);
        //}

        //List<Label> lbl;
        //Dictionary<Node, int> color;
        //Dictionary<Node, Point> pts;
        //List<Tuple<Node, Node>> cons;
        //int maxCnt = 0;
        //List<int> cntY;

        //void DFS(Node v, int cntx)
        //{
        //    if (cntx + 1 > maxCnt)
        //        maxCnt = cntx + 1;
        //    color[v] = 1;
        //    int koef = 0;
        //    if (cntx % 2 == 0) koef = 20;
        //    Point pt = new Point(20 + cntx * 70, 20 + cntY[cntx] * 70 + koef);
        //    if (pts[v].X != 0)
        //        cntY[(int)((pts[v].X - 20) / 70)]--;
        //    cntY[cntx]++;
        //    pts[v] = pt;
        //    DrawTextInCircle(pt, net.GetIndex(v), v.Value);
        //    for (int i = 0; i < v.Connections.Count; i++)
        //    {
        //        if (color[v.Connections[i]] == 0)
        //        {
        //            DFS(v.Connections[i], cntx + 1);
        //        }
        //        cons.Add(new Tuple<Node, Node>(v, v.Connections[i]));
        //    }
        //}

        void RefreshView()
        {
            //foreach (Label l in lbl)
            //    Controls.Remove(l);
            //lbl = new List<Label>();
            //cons = new List<Tuple<Node, Node>>();
            //maxCnt = 0;
            //pts = new Dictionary<Node, Point>();
            //cntY = new List<int>();
            //for (int i = 0; i < net.Count(); i++)
            //    cntY.Add(0);
            //for (int i = 0; i < net.Count(); i++)
            //    pts.Add(net.GetNode(i), new Point(0, 0));

            //color = new Dictionary<Node, int>();
            //for (int i = 0; i < net.Count(); i++)
            //    color.Add(net.GetNode(i), 0);

            //for (int i = 0; i < net.Count(); i++)
            //    if (color[net.GetNode(i)] == 0) DFS(net.GetNode(i), maxCnt);

            //this.Invalidate();
            //tbSum.Text = net.Sum().ToString();
            //tbCountElems.Text = net.Count().ToString();

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

        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    if (pts.Count > 0)
        //    {
        //        e.Graphics.Clear(this.BackColor);
        //        Pen pen = new Pen(Color.Black, 2);
        //        Pen pen2 = new Pen(Color.Gray, 2);
        //        foreach (Point pt in pts.Values)
        //        {
        //            e.Graphics.DrawEllipse(pen, new Rectangle(new Point(pt.X + LEFT_MARGIN, pt.Y + TOP_MARGIN), new Size(CIRCLE_RADIUS * 2, CIRCLE_RADIUS * 2)));
        //        }
        //        foreach (Tuple<Node, Node> c in cons)
        //        {
        //            Point p1 = new Point(pts[c.Item1].X + CIRCLE_RADIUS + LEFT_MARGIN, pts[c.Item1].Y + CIRCLE_RADIUS + TOP_MARGIN);
        //            Point p2 = new Point(pts[c.Item2].X + CIRCLE_RADIUS + LEFT_MARGIN, pts[c.Item2].Y + CIRCLE_RADIUS + TOP_MARGIN);
        //            int dx = (int)((double)(p2.X - p1.X) * CIRCLE_RADIUS / Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)));
        //            int dy = (int)((double)(p2.Y - p1.Y) * CIRCLE_RADIUS / Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)));

        //            p1 = new Point(p1.X + dx, p1.Y + dy);
        //            p2 = new Point(p2.X - dx, p2.Y - dy);

        //            e.Graphics.DrawLine(pen2, p1, p2);

        //            if (net.IsDirectedGraph)
        //            {
        //                var arrowLength = 12;
        //                var dx_ = dx * arrowLength / CIRCLE_RADIUS;
        //                var dy_ = dy * arrowLength / CIRCLE_RADIUS;
        //                var alpha = Math.PI / 6;

        //                var arrowLeft_dx = dx_ * Math.Cos(alpha) - dy_ * Math.Sin(alpha);
        //                var arrowLeft_dy = dx_ * Math.Sin(alpha) + dy_ * Math.Cos(alpha);
        //                var arrowLeft = new Point(p2.X - (int)arrowLeft_dx, p2.Y - (int)arrowLeft_dy);

        //                var arrowRight_dx = dx_ * Math.Cos(-alpha) - dy_ * Math.Sin(-alpha);
        //                var arrowRight_dy = dx_ * Math.Sin(-alpha) + dy_ * Math.Cos(-alpha);
        //                var arrowRight = new Point(p2.X - (int)arrowRight_dx, p2.Y - (int)arrowRight_dy);

        //                e.Graphics.DrawLine(pen2, arrowLeft, p2);
        //                e.Graphics.DrawLine(pen2, arrowRight, p2);
        //            }
        //        }
        //    }
        //}

        private void btnAddElem_Click(object sender, EventArgs e)
        {
            net.AddNode(Convert.ToInt32(tbAddElem.Text));
            RefreshView();
        }

        private void btnCreateNet_Click(object sender, EventArgs e)
        {
            net = new Net();
            RefreshView();
            checkBoxGraphType.Checked = false;
        }

        private void btnDelElem_Click(object sender, EventArgs e)
        {
            var result = net.DeleteNode(Convert.ToInt32(tbDelElem.Text));
            if (result == "")
                RefreshView();
            else
                MessageBox.Show(result);
        }

        private void btnAddCon_Click(object sender, EventArgs e)
        {
            var result = net.AddConnection(Convert.ToInt32(tbAddCon1.Text), Convert.ToInt32(tbAddCon2.Text));
            if (result == "")
                RefreshView();
            else
                MessageBox.Show(result);
        }

        private void btnDelCon_Click(object sender, EventArgs e)
        {
            var result = net.DeleteConnection(Convert.ToInt32(tbDelCon1.Text), Convert.ToInt32(tbDelCon2.Text));
            if (result == "")
                RefreshView();
            else
                MessageBox.Show(result);
        }

        private void btnChangeElem_Click(object sender, EventArgs e)
        {
            var result = net.ChangeNodeValue(Convert.ToInt32(tbChangeElemInd.Text), Convert.ToInt32(tbChangeElemVal.Text));
            if (result == "")
                RefreshView();
            else
                MessageBox.Show(result);
        }

        private void btnCreateDirectedGraph_Click(object sender, EventArgs e)
        {
            net = new Net(true);
            RefreshView();
            checkBoxGraphType.Checked = true;
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
            RefreshView();
        }
    }
}
