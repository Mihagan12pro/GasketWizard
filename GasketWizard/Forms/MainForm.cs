using GasketWizard.Domain;
using System;
using System.Windows.Forms;

namespace GasketWizard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            tvCatalog.ExpandAll();
        }

        private void tvCatalog_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (sender is TreeView treeView)
            {
                pbSketch.Image = PartBase.MapDisplayNameWithBitmap(treeView.SelectedNode.Text);
            }
        }

        private void tvCatalog_DoubleClick(object sender, EventArgs e)
        {
            if (sender is TreeView treeView)
            {
                Type partType = PartBase.MapDisplayNameWithPartType(treeView.SelectedNode.Text);

                if (partType != null)
                {
                    WizardForm wizardForm = new WizardForm(partType);
                    wizardForm.Owner = this;

                    if (wizardForm.ShowDialog() == DialogResult.OK)
                        DialogResult = DialogResult.OK;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
