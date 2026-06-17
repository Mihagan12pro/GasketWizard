using GasketWizard.Creators;
using GasketWizard.Databases.StandartSizes;
using GasketWizard.Databases.StandartSizes.Files;
using GasketWizard.Domain;
using GasketWizard.Extensions;
using Kompas6API5;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GasketWizard
{
    public partial class WizardForm : Form
    {
        private IStandartSizesDb _sizesDb = new FileBasedStandartSizesDb();
        
        private readonly Type _partType;

        private readonly string _partClassName;
        private readonly string _partDisplayName;

        private readonly PropertyInfo _idProperty;
        private readonly PropertyInfo[] _partsProperties;

        public WizardForm(Type partType)
        {
            InitializeComponent();

            lvSizes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            tbSavingPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            _partType = partType;
            _partClassName = _partType.Name;
            _partDisplayName = _partType.GetCustomAttribute<DisplayNameAttribute>().DisplayName;

            _partsProperties = _partType.GetProperties();
            _idProperty = _partType.GetProperty("Id");

            pbSketch.Image = PartBase.MapDisplayNameWithBitmap(_partDisplayName);
            Text = _partDisplayName;

            btOk.Enabled = false;

            AddDataToListView();
        }

        private void AddDataToListView()
        {
            var parts = _sizesDb.GetAll(_partClassName);

            ColumnHeader idColumn = new ColumnHeader()
            {
                Text = _idProperty.GetDisplayName(),
            };
            lvSizes.Columns.Add(idColumn);

            foreach (var property in _partType.GetProperties())
            {
                if (property != _idProperty)
                {
                    ColumnHeader column = new ColumnHeader()
                    {
                        Text = property.GetDisplayName()
                    };

                    lvSizes.Columns.Add(column);
                }
            }


            foreach (var part in parts)
            {
                ListViewItem item = new ListViewItem(part.Id.ToString());

                foreach (var property in _partType.GetProperties())
                {
                    if (property != _idProperty)
                    {
                        item.SubItems.Add(property.GetValue(part).ToString());
                    }
                }

                lvSizes.Items.Add(item);
            }

            SetColumnsSize();
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

            var part = _sizesDb.GetById(lvSizes.SelectedIndices[0] + 1, _partType.Name);

            KompasObject kompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            CreatorsProvider.Create(part, cbSave.Checked, tbSavingPath.Text);
        }

        private void WizardForm_Resize(object sender, EventArgs e)
        {
            SetColumnsSize();
        }

        private void SetColumnsSize()
        {
            int width = lvSizes.Width / _partsProperties.Length;

            foreach(var obj in lvSizes.Columns)
            {
                if (obj is ColumnHeader column)
                {
                    column.Width = width;
                }
            }
        }
    }
}
