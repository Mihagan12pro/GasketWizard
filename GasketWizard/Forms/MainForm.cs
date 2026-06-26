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
            var typesGroups = assembly.GetTypes()
                                .Where(t => t.GetCustomAttribute<PartGroupAttribute>() != null && !t.IsAbstract)
                                .GroupBy(t => t.GetCustomAttribute<PartGroupAttribute>());

            TreeNode root = new TreeNode() { Text = "Каталог" };

            foreach(var t in typesGroups)
            {
                TreeNode groupNode = new TreeNode() { Text = t.Key.LocalizedGroup};

                foreach(var p in t)
                {
                    TreeNode partNode = new TreeNode() { Text = p.GetDisplayName() };

                    groupNode.Nodes.Add(partNode);
                }

                root.Nodes.Add(groupNode);
            }

            tvCatalog.Nodes.Add(root);

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
