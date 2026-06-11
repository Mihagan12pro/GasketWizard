using GasketWizard.Databases.StandartSizes;
using GasketWizard.Databases.StandartSizes.Files;
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
        private IStandartSizesDb _sizesDb = new FileBasedStandartSizesDb();
        private Type partType;

        public WizardForm()
        {
            InitializeComponent();

            tbSavingPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            btOk.Enabled = false;
        }

        public void SetParameters(
            Bitmap image,
            PartBase partBase)
        {
            pbSketch.Image = image;

            partType = partBase.GetType();

            Text = ((DisplayNameAttribute)partType.GetCustomAttribute(typeof(DisplayNameAttribute))).DisplayName;

            var name = partBase.GetType().Name;
            var parts = _sizesDb.GetAll(name);

            PropertyInfo idProperty = partType.GetProperty("Id");
            lvSizes.Columns.Add(idProperty.GetCustomAttribute<DisplayNameAttribute>().DisplayName);
            
            foreach (var property in partType.GetProperties())
            {
                if (property != idProperty)
                {
                    lvSizes.Columns.Add(property.GetCustomAttribute<DisplayNameAttribute>().DisplayName);
                }
            }

            foreach (var part in parts)
            {
                ListViewItem item = new ListViewItem(part.Id.ToString());

                foreach (var property in partType.GetProperties())
                {
                    if (property != idProperty)
                    {
                        item.SubItems.Add(property.GetValue(part).ToString());
                    }
                }

                lvSizes.Items.Add(item);
            }
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
            btOk.Enabled = lvSizes.SelectedIndices.Count > 0;
        }

        private void WizardForm_Load(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {

        }

        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            _sizesDb.GetById(lvSizes.SelectedIndices[0] + 1, partType.Name);
        }
    }
}
