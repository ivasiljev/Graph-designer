namespace KLaba1v2
{
    partial class AdjacencyMatrix
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.adjacencyMatrixTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.adjacencyMatrixTable)).BeginInit();
            this.SuspendLayout();
            // 
            // adjacencyMatrixTable
            // 
            this.adjacencyMatrixTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adjacencyMatrixTable.Location = new System.Drawing.Point(12, 12);
            this.adjacencyMatrixTable.Name = "adjacencyMatrixTable";
            this.adjacencyMatrixTable.Size = new System.Drawing.Size(240, 150);
            this.adjacencyMatrixTable.TabIndex = 0;
            // 
            // AdjacencyMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 364);
            this.Controls.Add(this.adjacencyMatrixTable);
            this.Name = "AdjacencyMatrix";
            this.Text = "AdjacencyMatrix";
            ((System.ComponentModel.ISupportInitialize)(this.adjacencyMatrixTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView adjacencyMatrixTable;
    }
}