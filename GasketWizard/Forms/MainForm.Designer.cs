namespace GasketWizard
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Шайбы");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Каталог", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvCatalog = new System.Windows.Forms.TreeView();
            this.pbSketch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSketch)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvCatalog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbSketch);
            this.splitContainer1.Size = new System.Drawing.Size(1222, 680);
            this.splitContainer1.SplitterDistance = 399;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvCatalog
            // 
            this.tvCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCatalog.Location = new System.Drawing.Point(0, 0);
            this.tvCatalog.Name = "tvCatalog";
            treeNode1.Name = "NodeShim";
            treeNode1.Text = "Шайбы";
            treeNode2.Name = "NodeRoot";
            treeNode2.Text = "Каталог";
            this.tvCatalog.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvCatalog.Size = new System.Drawing.Size(395, 676);
            this.tvCatalog.TabIndex = 0;
            // 
            // pbSketch
            // 
            this.pbSketch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSketch.Location = new System.Drawing.Point(0, 0);
            this.pbSketch.Name = "pbSketch";
            this.pbSketch.Size = new System.Drawing.Size(809, 676);
            this.pbSketch.TabIndex = 0;
            this.pbSketch.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 680);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Каталог сальников";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSketch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvCatalog;
        private System.Windows.Forms.PictureBox pbSketch;
    }
}