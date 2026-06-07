using GasketWizard.Domain;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace GasketWizard
{
    public partial class WizardForm : Form
    {
        private StandartSizesDbContext _dbContext;

        public WizardForm()
        {
            InitializeComponent();

            tbSavingPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            btOk.Enabled = false;
            _dbContext = new StandartSizesDbContext();
        }

        public void SetParameters(
            Bitmap image,
            PartBase partBase)
        {
            pbSketch.Image = image;

            Type type = partBase.GetType();

            Text = ((DisplayNameAttribute)type.GetCustomAttribute(typeof(DisplayNameAttribute))).DisplayName;
        }

        private void btSelectSavingFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbSavingPath.Text = dialog.SelectedPath;
            }
        }

        private void lvSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ListView listView)
            {
                if (listView.SelectedIndices[0] != -1)
                    btOk.Enabled = true;
            }
        }

        private void WizardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
