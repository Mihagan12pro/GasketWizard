using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace GasketWizard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();
            var partTypes = assembly.GetTypes()
                                .Where(t => t.GetCustomAttribute<PartGroupAttribute>() != null && !t.IsAbstract);

            var groups = partTypes.Select(t => t.GetCustomAttribute<PartGroupAttribute>().LocalizedGroup)
                                  .Distinct();

            TreeNode rootNode = new TreeNode() { Text = "Каталог" };

            foreach ( var group in groups )
            {
                TreeNode groupNode = new TreeNode() { Text = group };

                var parts = partTypes.Where(t => t.GetCustomAttribute<PartGroupAttribute>().LocalizedGroup == group);

                foreach(var part in parts)
                {
                    TreeNode partNode = new TreeNode() { Text = part.GetDisplayName() };

                    groupNode.Nodes.Add(partNode);
                }

                rootNode.Nodes.Add(groupNode);
            }

            tvCatalog.Nodes.Add(rootNode);

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
