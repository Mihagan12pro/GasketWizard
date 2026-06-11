using GasketWizard.Databases.StandartSizes;
using GasketWizard.Databases.StandartSizes.Files;
using GasketWizard.Domain;
using GasketWizard.Utils.Mappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace GasketWizard
{
    public partial class WizardForm : Form
    {
        private IStandartSizesDb _sizesDb = new FileBasedStandartSizesDb();

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

            Type type = partBase.GetType();

            Text = ((DisplayNameAttribute)type.GetCustomAttribute(typeof(DisplayNameAttribute))).DisplayName;

            var name = partBase.GetType().Name;
            var parts = _sizesDb.GetAll(name);

            var idColumn = new DataGridViewTextBoxColumn()
            {
                Name = type.BaseType.GetProperties().First().Name,
                HeaderText = type.BaseType.GetProperties().First().GetCustomAttribute<DisplayNameAttribute>().DisplayName,
                DataPropertyName = type.BaseType.GetProperties().First().Name
            };
            tblSizes.Columns.Add(idColumn);

            foreach (var prop in type.GetProperties())
            {
                if (prop.Name != type.BaseType.GetProperties().First().Name)
                {
                    tblSizes.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = prop.Name,
                        HeaderText = prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName,
                        DataPropertyName = prop.Name
                    });
                }
            }

            foreach (var part in parts)
            {
                //tblSizes.Rows.ad
            }
            //BindingSource bindingSource = new BindingSource();
            //bindingSource.DataSource = sizes;

            //tblSizes.DataSource = bindingSource;
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

        private void btCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
