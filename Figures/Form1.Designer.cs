namespace Figures
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.FigureCB = new System.Windows.Forms.ToolStripComboBox();
            this.AddFigure = new System.Windows.Forms.ToolStripButton();
            this.RemoveFigure = new System.Windows.Forms.ToolStripButton();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.FiguresLB = new System.Windows.Forms.ListBox();
            this.figureColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.selectedFigureColor = new System.Windows.Forms.ToolStripButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FigureCB,
            this.AddFigure,
            this.RemoveFigure,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.figureColor,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.selectedFigureColor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(742, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // FigureCB
            // 
            this.FigureCB.Name = "FigureCB";
            this.FigureCB.Size = new System.Drawing.Size(121, 25);
            this.FigureCB.SelectedIndexChanged += new System.EventHandler(this.FigureCB_SelectedIndexChanged);
            // 
            // AddFigure
            // 
            this.AddFigure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddFigure.Image = ((System.Drawing.Image)(resources.GetObject("AddFigure.Image")));
            this.AddFigure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddFigure.Name = "AddFigure";
            this.AddFigure.Size = new System.Drawing.Size(33, 22);
            this.AddFigure.Text = "Add";
            this.AddFigure.Click += new System.EventHandler(this.AddFigure_Click);
            // 
            // RemoveFigure
            // 
            this.RemoveFigure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RemoveFigure.Image = ((System.Drawing.Image)(resources.GetObject("RemoveFigure.Image")));
            this.RemoveFigure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveFigure.Name = "RemoveFigure";
            this.RemoveFigure.Size = new System.Drawing.Size(54, 22);
            this.RemoveFigure.Text = "Remove";
            this.RemoveFigure.Click += new System.EventHandler(this.RemoveFigure_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(0, 28);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(742, 573);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.canvas_DoubleClick);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            // 
            // FiguresLB
            // 
            this.FiguresLB.Dock = System.Windows.Forms.DockStyle.Right;
            this.FiguresLB.FormattingEnabled = true;
            this.FiguresLB.Location = new System.Drawing.Point(622, 25);
            this.FiguresLB.Name = "FiguresLB";
            this.FiguresLB.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.FiguresLB.Size = new System.Drawing.Size(120, 588);
            this.FiguresLB.TabIndex = 2;
            this.FiguresLB.SelectedIndexChanged += new System.EventHandler(this.FiguresLB_SelectedIndexChanged);
            this.FiguresLB.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FiguresLB_MouseDoubleClick);
            // 
            // figureColor
            // 
            this.figureColor.BackColor = System.Drawing.Color.Black;
            this.figureColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.figureColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.figureColor.Name = "figureColor";
            this.figureColor.Size = new System.Drawing.Size(23, 22);
            this.figureColor.Text = "Цвет фигуры";
            this.figureColor.Click += new System.EventHandler(this.figureColor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(116, 22);
            this.toolStripLabel1.Text = "Цвет новой фигуры";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel2.Text = "Цвет фигуры";
            // 
            // selectedFigureColor
            // 
            this.selectedFigureColor.BackColor = System.Drawing.Color.Black;
            this.selectedFigureColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectedFigureColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectedFigureColor.Name = "selectedFigureColor";
            this.selectedFigureColor.Size = new System.Drawing.Size(23, 22);
            this.selectedFigureColor.Text = "toolStripButton1";
            this.selectedFigureColor.Click += new System.EventHandler(this.selectedFigureColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 613);
            this.Controls.Add(this.FiguresLB);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox FigureCB;
        private System.Windows.Forms.ToolStripButton AddFigure;
        private System.Windows.Forms.ToolStripButton RemoveFigure;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.ListBox FiguresLB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton figureColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton selectedFigureColor;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

