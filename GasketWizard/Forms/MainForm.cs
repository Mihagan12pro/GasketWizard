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
                //PartBase partBase = MapDisplayNameWithPart.Map(treeView.SelectedNode.Text);

                //if (partBase != null)
                //{
                //    WizardForm wizardForm = new WizardForm(partBase.GetType());
                //    wizardForm.Owner = this;

                //    wizardForm.Show();
                //}
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
