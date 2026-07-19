using GasketWizard.Attributes;
using GasketWizard.Creators;
using GasketWizard.Databases.StandartSizes;
using GasketWizard.Databases.StandartSizes.Files;
using GasketWizard.Domain;
using GasketWizard.Domain.ValueObjects;
using GasketWizard.Extensions;
using GasketWizard.Forms;
using GasketWizard.Mappers;
using Kompas6API5;
using System;
using System.ComponentModel;
using System.Linq;
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
        private readonly PropertyInfo[] _partsStandartProperties, _partsCustomProperties;

        public WizardForm(Type partType)
        {
            InitializeComponent();

            lvSizes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            tbSavingPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            _partType = partType;
            _partClassName = _partType.Name;
            _partDisplayName = _partType.GetCustomAttribute<PartTitleAttribute>().LocalizedTitle;

            _partsStandartProperties = _partType.GetProperties()
                                                .Where(p => p.GetCustomAttribute<PartParameterAttribute>()!= null && p.GetCustomAttribute<PartParameterAttribute>().SizeType != Enums.SizesTypes.Custom)
                                                .ToArray();

            _partsCustomProperties = _partType.GetProperties()
                                                .Where(p => p.GetCustomAttribute<PartParameterAttribute>() != null && p.GetCustomAttribute<PartParameterAttribute>().SizeType == Enums.SizesTypes.Custom)
                                                .ToArray();
            _idProperty = _partType.GetProperty("Id");

            pbSketch.Image = BitmapMapper.MapDisplayName(_partDisplayName);
            Text = _partDisplayName;

            btOk.Enabled = false;

            AddDataToListView();
        }

        private void AddDataToListView()
        {
            var parts = _sizesDb.GetAll(_partClassName);

            ColumnHeader idColumn = new ColumnHeader()
            {
                Text = _idProperty.GetCustomAttribute<PartParameterAttribute>().Title,
            };
            lvSizes.Columns.Add(idColumn);

            foreach (var property in _partsStandartProperties)
            {
                if (property != _idProperty && property.GetCustomAttribute<PartParameterAttribute>().SizeType != Enums.SizesTypes.Custom)
                {
                    ColumnHeader column = new ColumnHeader()
                    {
                        Text = property.GetCustomAttribute<PartParameterAttribute>().LocalizedTitle
                    };

                    lvSizes.Columns.Add(column);
                }
            }


            foreach (var part in parts)
            {
                ListViewItem item = new ListViewItem(part.GetId().ToString());

                foreach (var property in _partsStandartProperties)
                {
                    if (property != _idProperty && property.GetCustomAttribute<PartParameterAttribute>() != null)
                    {
                        if (property.PropertyType.GetInterface(nameof(IValueObject)) != typeof(IValueObject))
                        {
                            item.SubItems.Add(property.GetValue(part).ToString());
                        }
                        else
                        {
                            var valueObjectValue = (IValueObject)property.GetValue(part);
           
                            item.SubItems.Add($"{valueObjectValue.Display}");
                        }
                    }
                }

                lvSizes.Items.Add(item);
            }

            SetColumnsPartParameter();
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
            DialogResult = DialogResult.Cancel;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            var part = _sizesDb.GetById((lvSizes.SelectedIndices[0] + 1).ToString(), _partType.Name);

            bool save = cbSave.Checked;

            if (_partsCustomProperties.Length > 0)
            {
                WizardCustomSizesForm wizardCustomSizesForm = new WizardCustomSizesForm();
                wizardCustomSizesForm.Part = part;

                if (wizardCustomSizesForm.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
            }

            KompasObject kompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            CreatorsProvider.Create(part, save, tbSavingPath.Text);
            DialogResult = DialogResult.OK;
        }

        private void WizardForm_RePartParameter(object sender, EventArgs e)
        {
            SetColumnsPartParameter();
        }

        private void SetColumnsPartParameter()
        {
            int width = lvSizes.Width / _partsStandartProperties.Length;

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
