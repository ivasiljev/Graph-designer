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
    public partial class AdjacencyMatrix : Form
    {
        private Net net;

        public AdjacencyMatrix(Net net)
        {
            InitializeComponent();

            adjacencyMatrixTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            adjacencyMatrixTable.ScrollBars = ScrollBars.None;

            this.net = net;
            Shown += AdjacencyMatrix_Shown;
            FormClosed += AdjacencyMatrix_FormClosed;
        }

        private void AdjacencyMatrix_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)this.Owner).AdjacencyMatrixUpdatedEventHandler -= AdjacencyMatrix_AdjecencyMatrixUpdatedEventHandler;
        }

        private void AdjacencyMatrix_Shown(object sender, EventArgs e)
        {
            ((Form1)this.Owner).AdjacencyMatrixUpdatedEventHandler += AdjacencyMatrix_AdjecencyMatrixUpdatedEventHandler;
            UpdateConnectionTable();
        }

        private void AdjacencyMatrix_AdjecencyMatrixUpdatedEventHandler(Net newNet)
        {
            if (newNet != net)
                net = newNet;
            UpdateConnectionTable();
        }

        private void UpdateConnectionTable()
        {
            var g = net.GetAdjacencyMatrix();

            adjacencyMatrixTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            adjacencyMatrixTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            adjacencyMatrixTable.ColumnCount = g.Count + 1;
            adjacencyMatrixTable.RowHeadersVisible = false;
            for (int i = 0; i < g.Count; i++)
                adjacencyMatrixTable.Columns[i + 1].Name = "X" + i.ToString();

            adjacencyMatrixTable.Rows.Clear();
            for (int i = 0; i < g.Count; i++)
            {
                string[] newRow = new string[g.Count + 1];
                newRow[0] = "X" + i.ToString();
                for (int j = 0; j < g.Count; j++)
                    newRow[j + 1] = g[i][j].ToString();

                adjacencyMatrixTable.Rows.Add(newRow);
            }

            var totalWidth = 0;
            for (int i = 0; i < adjacencyMatrixTable.Columns.Count; i++)
            {
                int columnWidth = adjacencyMatrixTable.Columns[i].Width;
                totalWidth += columnWidth;
            }

            var totalHeight = 0;
            for (int i = 0; i < adjacencyMatrixTable.Rows.Count; i++)
            {
                int rowHeight = adjacencyMatrixTable.Rows[i].Height;
                totalHeight += rowHeight;
            }

            this.Size = new Size(totalWidth + 50, totalHeight + 70);
            adjacencyMatrixTable.Size = new Size(totalWidth, totalHeight);
        }
    }
}
