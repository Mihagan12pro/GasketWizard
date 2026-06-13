using GasketWizard.Domain;
using GasketWizard.Utils.Mappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                pbSketch.Image = MapPartWithSketch.Map(treeView.SelectedNode.Text);
            }
        }

        private void tvCatalog_DoubleClick(object sender, EventArgs e)
        {
            if (sender is TreeView treeView)
            {
                PartBase partBase = MapDisplayNameWithPart.Map(treeView.SelectedNode.Text);

                if (partBase != null)
                {
                    WizardForm wizardForm = new WizardForm(partBase.GetType());
                    wizardForm.Owner = this;
                    //wizardForm.SetParameters(MapPartWithSketch.Map(treeView.SelectedNode.Text), partBase);

                    wizardForm.ShowDialog();
                }
            }
        }
    }
}
