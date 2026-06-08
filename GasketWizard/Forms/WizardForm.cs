using GasketWizard.Databases.StandartSizes;
using GasketWizard.Databases.StandartSizes.Files;
using GasketWizard.Domain;
using GasketWizard.Utils.Mappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            var sizes = _sizesDb.GetAll(name);

            var keys = sizes.Keys.ToArray();

            List<ListViewItem> items = new List<ListViewItem>(sizes.Count);

            for ( int i = 0; i < sizes.Count; i++ )
            {
                var id = sizes[keys[0]];

                ListViewItem item = new ListViewItem(id[i], i);
                for(int j = 1; j < keys.Length; j++ )
                {
                    string key = keys[j];

                    item.SubItems.Add(sizes[key][i]);
                }

                items.Add(item);
            }

            foreach (var key in keys)
            {
                lvSizes.Columns.Add(key);
            }

            lvSizes.Items.AddRange(items.ToArray());
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
