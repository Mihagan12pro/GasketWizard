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

        private void tvCatalog_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is TreeView treeView)
            {
                pbSketch.Image = MapPartWithSketch.Map(treeView.SelectedNode.Text);
            }
        }
    }
}
