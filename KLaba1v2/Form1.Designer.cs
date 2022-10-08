namespace GraphDesigner
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCreateNet = new System.Windows.Forms.Button();
            this.btnAddElem = new System.Windows.Forms.Button();
            this.btnDelElem = new System.Windows.Forms.Button();
            this.btnAddCon = new System.Windows.Forms.Button();
            this.btnDelCon = new System.Windows.Forms.Button();
            this.tbAddElem = new System.Windows.Forms.TextBox();
            this.tbDelElem = new System.Windows.Forms.TextBox();
            this.tbAddCon2 = new System.Windows.Forms.TextBox();
            this.tbAddCon1 = new System.Windows.Forms.TextBox();
            this.tbDelCon2 = new System.Windows.Forms.TextBox();
            this.tbDelCon1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCountElems = new System.Windows.Forms.TextBox();
            this.btnCreateDirectedGraph = new System.Windows.Forms.Button();
            this.checkBoxGraphType = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnShowAdjacencyMatrix = new System.Windows.Forms.Button();
            this.btnExecuteMalgrangeAlgo = new System.Windows.Forms.Button();
            this.gViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.presetsDropdown = new System.Windows.Forms.ComboBox();
            this.btnUsePreset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateNet
            // 
            this.btnCreateNet.Location = new System.Drawing.Point(12, 65);
            this.btnCreateNet.Name = "btnCreateNet";
            this.btnCreateNet.Size = new System.Drawing.Size(120, 49);
            this.btnCreateNet.TabIndex = 0;
            this.btnCreateNet.Text = "Создать двунаправленный граф";
            this.btnCreateNet.UseVisualStyleBackColor = true;
            this.btnCreateNet.Click += new System.EventHandler(this.btnCreateNet_Click);
            // 
            // btnAddElem
            // 
            this.btnAddElem.Location = new System.Drawing.Point(189, 14);
            this.btnAddElem.Name = "btnAddElem";
            this.btnAddElem.Size = new System.Drawing.Size(120, 40);
            this.btnAddElem.TabIndex = 1;
            this.btnAddElem.Text = "Добавить элемент";
            this.btnAddElem.UseVisualStyleBackColor = true;
            this.btnAddElem.Click += new System.EventHandler(this.btnAddElem_Click);
            // 
            // btnDelElem
            // 
            this.btnDelElem.Location = new System.Drawing.Point(189, 69);
            this.btnDelElem.Name = "btnDelElem";
            this.btnDelElem.Size = new System.Drawing.Size(120, 40);
            this.btnDelElem.TabIndex = 2;
            this.btnDelElem.Text = "Удалить элемент";
            this.btnDelElem.UseVisualStyleBackColor = true;
            this.btnDelElem.Click += new System.EventHandler(this.btnDelElem_Click);
            // 
            // btnAddCon
            // 
            this.btnAddCon.Location = new System.Drawing.Point(405, 14);
            this.btnAddCon.Name = "btnAddCon";
            this.btnAddCon.Size = new System.Drawing.Size(120, 40);
            this.btnAddCon.TabIndex = 3;
            this.btnAddCon.Text = "Добавить связь";
            this.btnAddCon.UseVisualStyleBackColor = true;
            this.btnAddCon.Click += new System.EventHandler(this.btnAddCon_Click);
            // 
            // btnDelCon
            // 
            this.btnDelCon.Location = new System.Drawing.Point(405, 69);
            this.btnDelCon.Name = "btnDelCon";
            this.btnDelCon.Size = new System.Drawing.Size(120, 40);
            this.btnDelCon.TabIndex = 4;
            this.btnDelCon.Text = "Удалить связь";
            this.btnDelCon.UseVisualStyleBackColor = true;
            this.btnDelCon.Click += new System.EventHandler(this.btnDelCon_Click);
            // 
            // tbAddElem
            // 
            this.tbAddElem.Location = new System.Drawing.Point(150, 25);
            this.tbAddElem.Name = "tbAddElem";
            this.tbAddElem.Size = new System.Drawing.Size(33, 20);
            this.tbAddElem.TabIndex = 6;
            this.tbAddElem.Text = "0";
            // 
            // tbDelElem
            // 
            this.tbDelElem.Location = new System.Drawing.Point(151, 80);
            this.tbDelElem.Name = "tbDelElem";
            this.tbDelElem.Size = new System.Drawing.Size(33, 20);
            this.tbDelElem.TabIndex = 7;
            this.tbDelElem.Text = "0";
            // 
            // tbAddCon2
            // 
            this.tbAddCon2.Location = new System.Drawing.Point(366, 25);
            this.tbAddCon2.Name = "tbAddCon2";
            this.tbAddCon2.Size = new System.Drawing.Size(33, 20);
            this.tbAddCon2.TabIndex = 8;
            this.tbAddCon2.Text = "0";
            // 
            // tbAddCon1
            // 
            this.tbAddCon1.Location = new System.Drawing.Point(327, 25);
            this.tbAddCon1.Name = "tbAddCon1";
            this.tbAddCon1.Size = new System.Drawing.Size(33, 20);
            this.tbAddCon1.TabIndex = 9;
            this.tbAddCon1.Text = "0";
            // 
            // tbDelCon2
            // 
            this.tbDelCon2.Location = new System.Drawing.Point(366, 80);
            this.tbDelCon2.Name = "tbDelCon2";
            this.tbDelCon2.Size = new System.Drawing.Size(33, 20);
            this.tbDelCon2.TabIndex = 10;
            this.tbDelCon2.Text = "0";
            // 
            // tbDelCon1
            // 
            this.tbDelCon1.Location = new System.Drawing.Point(327, 80);
            this.tbDelCon1.Name = "tbDelCon1";
            this.tbDelCon1.Size = new System.Drawing.Size(33, 20);
            this.tbDelCon1.TabIndex = 11;
            this.tbDelCon1.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(575, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Количество вершин";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(144, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "Значение";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(149, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "Индекс";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(326, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "Индекс";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(365, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "Индекс";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(325, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "Индекс";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(364, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "Индекс";
            // 
            // tbCountElems
            // 
            this.tbCountElems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCountElems.Location = new System.Drawing.Point(681, 14);
            this.tbCountElems.Name = "tbCountElems";
            this.tbCountElems.ReadOnly = true;
            this.tbCountElems.Size = new System.Drawing.Size(59, 20);
            this.tbCountElems.TabIndex = 25;
            this.tbCountElems.Text = "0";
            // 
            // btnCreateDirectedGraph
            // 
            this.btnCreateDirectedGraph.Location = new System.Drawing.Point(12, 10);
            this.btnCreateDirectedGraph.Name = "btnCreateDirectedGraph";
            this.btnCreateDirectedGraph.Size = new System.Drawing.Size(120, 49);
            this.btnCreateDirectedGraph.TabIndex = 27;
            this.btnCreateDirectedGraph.Text = "Создать ориентированный граф";
            this.btnCreateDirectedGraph.UseVisualStyleBackColor = true;
            this.btnCreateDirectedGraph.Click += new System.EventHandler(this.btnCreateDirectedGraph_Click);
            // 
            // checkBoxGraphType
            // 
            this.checkBoxGraphType.AutoCheck = false;
            this.checkBoxGraphType.AutoSize = true;
            this.checkBoxGraphType.Checked = true;
            this.checkBoxGraphType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGraphType.Location = new System.Drawing.Point(683, 39);
            this.checkBoxGraphType.Name = "checkBoxGraphType";
            this.checkBoxGraphType.Size = new System.Drawing.Size(15, 14);
            this.checkBoxGraphType.TabIndex = 28;
            this.checkBoxGraphType.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(554, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Ориентированный граф";
            // 
            // btnShowAdjacencyMatrix
            // 
            this.btnShowAdjacencyMatrix.Location = new System.Drawing.Point(986, 14);
            this.btnShowAdjacencyMatrix.Name = "btnShowAdjacencyMatrix";
            this.btnShowAdjacencyMatrix.Size = new System.Drawing.Size(210, 20);
            this.btnShowAdjacencyMatrix.TabIndex = 30;
            this.btnShowAdjacencyMatrix.Text = "Вывести матрицу смежности";
            this.btnShowAdjacencyMatrix.UseVisualStyleBackColor = true;
            this.btnShowAdjacencyMatrix.Click += new System.EventHandler(this.btnShowAdjacencyMatrix_Click);
            // 
            // btnExecuteMalgrangeAlgo
            // 
            this.btnExecuteMalgrangeAlgo.Location = new System.Drawing.Point(986, 43);
            this.btnExecuteMalgrangeAlgo.Name = "btnExecuteMalgrangeAlgo";
            this.btnExecuteMalgrangeAlgo.Size = new System.Drawing.Size(210, 20);
            this.btnExecuteMalgrangeAlgo.TabIndex = 31;
            this.btnExecuteMalgrangeAlgo.Text = "Выполнить алгоритм Мальгранжа";
            this.btnExecuteMalgrangeAlgo.UseVisualStyleBackColor = true;
            this.btnExecuteMalgrangeAlgo.Click += new System.EventHandler(this.btnExecuteMalgrangeAlgo_Click);
            // 
            // gViewer
            // 
            this.gViewer.ArrowheadLength = 10D;
            this.gViewer.AsyncLayout = false;
            this.gViewer.AutoScroll = true;
            this.gViewer.BackwardEnabled = false;
            this.gViewer.BuildHitTree = true;
            this.gViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer.EdgeInsertButtonVisible = true;
            this.gViewer.FileName = "";
            this.gViewer.ForwardEnabled = false;
            this.gViewer.Graph = null;
            this.gViewer.InsertingEdge = false;
            this.gViewer.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer.LayoutEditingEnabled = true;
            this.gViewer.Location = new System.Drawing.Point(12, 129);
            this.gViewer.LooseOffsetForRouting = 0.25D;
            this.gViewer.MouseHitDistance = 0.05D;
            this.gViewer.Name = "gViewer";
            this.gViewer.NavigationVisible = false;
            this.gViewer.NeedToCalculateLayout = true;
            this.gViewer.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer.PaddingForEdgeRouting = 8D;
            this.gViewer.PanButtonPressed = false;
            this.gViewer.SaveAsImageEnabled = true;
            this.gViewer.SaveAsMsaglEnabled = true;
            this.gViewer.SaveButtonVisible = true;
            this.gViewer.SaveGraphButtonVisible = true;
            this.gViewer.SaveInVectorFormatEnabled = true;
            this.gViewer.Size = new System.Drawing.Size(1184, 468);
            this.gViewer.TabIndex = 33;
            this.gViewer.TightOffsetForRouting = 0.125D;
            this.gViewer.ToolBarIsVisible = true;
            this.gViewer.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewer.Transform")));
            this.gViewer.UndoRedoButtonsVisible = true;
            this.gViewer.WindowZoomButtonPressed = false;
            this.gViewer.ZoomF = 1D;
            this.gViewer.ZoomWindowThreshold = 0.05D;
            this.gViewer.EdgeAdded += new System.EventHandler(this.gViewer_EdgeAdded);
            // 
            // presetsDropdown
            // 
            this.presetsDropdown.FormattingEnabled = true;
            this.presetsDropdown.Location = new System.Drawing.Point(542, 64);
            this.presetsDropdown.Name = "presetsDropdown";
            this.presetsDropdown.Size = new System.Drawing.Size(198, 21);
            this.presetsDropdown.TabIndex = 34;
            // 
            // btnUsePreset
            // 
            this.btnUsePreset.Location = new System.Drawing.Point(542, 87);
            this.btnUsePreset.Name = "btnUsePreset";
            this.btnUsePreset.Size = new System.Drawing.Size(198, 22);
            this.btnUsePreset.TabIndex = 35;
            this.btnUsePreset.Text = "Использовать выбранный пресет";
            this.btnUsePreset.UseVisualStyleBackColor = true;
            this.btnUsePreset.Click += new System.EventHandler(this.btnUsePreset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 622);
            this.Controls.Add(this.btnUsePreset);
            this.Controls.Add(this.presetsDropdown);
            this.Controls.Add(this.gViewer);
            this.Controls.Add(this.btnExecuteMalgrangeAlgo);
            this.Controls.Add(this.btnShowAdjacencyMatrix);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.checkBoxGraphType);
            this.Controls.Add(this.btnCreateDirectedGraph);
            this.Controls.Add(this.tbCountElems);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDelCon1);
            this.Controls.Add(this.tbDelCon2);
            this.Controls.Add(this.tbAddCon1);
            this.Controls.Add(this.tbAddCon2);
            this.Controls.Add(this.tbDelElem);
            this.Controls.Add(this.tbAddElem);
            this.Controls.Add(this.btnDelCon);
            this.Controls.Add(this.btnAddCon);
            this.Controls.Add(this.btnDelElem);
            this.Controls.Add(this.btnAddElem);
            this.Controls.Add(this.btnCreateNet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateNet;
        private System.Windows.Forms.Button btnAddElem;
        private System.Windows.Forms.Button btnDelElem;
        private System.Windows.Forms.Button btnAddCon;
        private System.Windows.Forms.Button btnDelCon;
        private System.Windows.Forms.TextBox tbAddElem;
        private System.Windows.Forms.TextBox tbDelElem;
        private System.Windows.Forms.TextBox tbAddCon2;
        private System.Windows.Forms.TextBox tbAddCon1;
        private System.Windows.Forms.TextBox tbDelCon2;
        private System.Windows.Forms.TextBox tbDelCon1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbCountElems;
        private System.Windows.Forms.Button btnCreateDirectedGraph;
        private System.Windows.Forms.CheckBox checkBoxGraphType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnShowAdjacencyMatrix;
        private System.Windows.Forms.Button btnExecuteMalgrangeAlgo;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer;
        private System.Windows.Forms.ComboBox presetsDropdown;
        private System.Windows.Forms.Button btnUsePreset;
    }
}

