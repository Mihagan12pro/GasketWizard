using System.Windows.Forms;

namespace GasketWizard
{
    partial class WizardForm
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
            this.tblForm = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbSketch = new System.Windows.Forms.PictureBox();
            this.lvSizes = new System.Windows.Forms.ListView();
            this.tblOkCancelPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.tblSavingOptions = new System.Windows.Forms.TableLayoutPanel();
            this.cbSave = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btSelectSavingFolder = new System.Windows.Forms.Button();
            this.tbSavingPath = new System.Windows.Forms.TextBox();
            this.tblForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSketch)).BeginInit();
            this.tblOkCancelPanel.SuspendLayout();
            this.tblSavingOptions.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblForm
            // 
            this.tblForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblForm.ColumnCount = 1;
            this.tblForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblForm.Controls.Add(this.splitContainer1, 0, 0);
            this.tblForm.Controls.Add(this.tblOkCancelPanel, 0, 2);
            this.tblForm.Controls.Add(this.tblSavingOptions, 0, 1);
            this.tblForm.Location = new System.Drawing.Point(43, 19);
            this.tblForm.Margin = new System.Windows.Forms.Padding(10);
            this.tblForm.Name = "tblForm";
            this.tblForm.RowCount = 3;
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblForm.Size = new System.Drawing.Size(1018, 663);
            this.tblForm.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbSketch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvSizes);
            this.splitContainer1.Size = new System.Drawing.Size(1012, 535);
            this.splitContainer1.SplitterDistance = 561;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 1;
            // 
            // pbSketch
            // 
            this.pbSketch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSketch.Location = new System.Drawing.Point(0, 0);
            this.pbSketch.Name = "pbSketch";
            this.pbSketch.Size = new System.Drawing.Size(557, 531);
            this.pbSketch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSketch.TabIndex = 0;
            this.pbSketch.TabStop = false;
            // 
            // lvSizes
            // 
            this.lvSizes.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvSizes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvSizes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSizes.FullRowSelect = true;
            this.lvSizes.GridLines = true;
            this.lvSizes.HideSelection = false;
            this.lvSizes.HoverSelection = true;
            this.lvSizes.Location = new System.Drawing.Point(0, 0);
            this.lvSizes.MultiSelect = false;
            this.lvSizes.Name = "lvSizes";
            this.lvSizes.Size = new System.Drawing.Size(427, 531);
            this.lvSizes.TabIndex = 0;
            this.lvSizes.UseCompatibleStateImageBehavior = false;
            this.lvSizes.View = System.Windows.Forms.View.Details;
            this.lvSizes.SelectedIndexChanged += new System.EventHandler(this.lvSizes_SelectedIndexChanged);
            // 
            // tblOkCancelPanel
            // 
            this.tblOkCancelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tblOkCancelPanel.ColumnCount = 2;
            this.tblOkCancelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblOkCancelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblOkCancelPanel.Controls.Add(this.btOk, 1, 0);
            this.tblOkCancelPanel.Controls.Add(this.btCancel, 0, 0);
            this.tblOkCancelPanel.Location = new System.Drawing.Point(646, 604);
            this.tblOkCancelPanel.Name = "tblOkCancelPanel";
            this.tblOkCancelPanel.RowCount = 1;
            this.tblOkCancelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblOkCancelPanel.Size = new System.Drawing.Size(369, 56);
            this.tblOkCancelPanel.TabIndex = 0;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(216, 7);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(150, 46);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "Ок";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(31, 7);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(150, 46);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // tblSavingOptions
            // 
            this.tblSavingOptions.ColumnCount = 2;
            this.tblSavingOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSavingOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSavingOptions.Controls.Add(this.cbSave, 1, 0);
            this.tblSavingOptions.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tblSavingOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSavingOptions.Location = new System.Drawing.Point(3, 544);
            this.tblSavingOptions.Name = "tblSavingOptions";
            this.tblSavingOptions.RowCount = 1;
            this.tblSavingOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSavingOptions.Size = new System.Drawing.Size(1012, 54);
            this.tblSavingOptions.TabIndex = 2;
            // 
            // cbSave
            // 
            this.cbSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSave.AutoSize = true;
            this.cbSave.Location = new System.Drawing.Point(694, 22);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(315, 29);
            this.cbSave.TabIndex = 0;   
            this.cbSave.Text = "Сохранить после создания";
            this.cbSave.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.btSelectSavingFolder, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tbSavingPath, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(685, 48);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // btSelectSavingFolder
            // 
            this.btSelectSavingFolder.Location = new System.Drawing.Point(3, 3);
            this.btSelectSavingFolder.Name = "btSelectSavingFolder";
            this.btSelectSavingFolder.Size = new System.Drawing.Size(150, 42);
            this.btSelectSavingFolder.TabIndex = 0;
            this.btSelectSavingFolder.Text = "Выбрать...";
            this.btSelectSavingFolder.UseVisualStyleBackColor = true;
            this.btSelectSavingFolder.Click += new System.EventHandler(this.btSelectSavingFolder_Click);
            // 
            // tbSavingPath
            // 
            this.tbSavingPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSavingPath.Location = new System.Drawing.Point(176, 14);
            this.tbSavingPath.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.tbSavingPath.Name = "tbSavingPath";
            this.tbSavingPath.ReadOnly = true;
            this.tbSavingPath.Size = new System.Drawing.Size(489, 31);
            this.tbSavingPath.TabIndex = 1;
            // 
            // WizardForm
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(1091, 711);
            this.Controls.Add(this.tblForm);    
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.WizardForm_Load);
            //this.Resize += new System.EventHandler(this.Ri);
            this.tblForm.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSketch)).EndInit();
            this.tblOkCancelPanel.ResumeLayout(false);
            this.tblSavingOptions.ResumeLayout(false);
            this.tblSavingOptions.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblForm;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pbSketch;
        private System.Windows.Forms.TableLayoutPanel tblSavingOptions;
        private System.Windows.Forms.CheckBox cbSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btSelectSavingFolder;
        private System.Windows.Forms.TextBox tbSavingPath;
        private ListView lvSizes;
        private TableLayoutPanel tblOkCancelPanel;
        private Button btOk;
        private Button btCancel;
    }
}