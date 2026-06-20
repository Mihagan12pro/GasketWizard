using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace GasketWizard.Forms
{
    public partial class WizardCustomSizesForm : Form
    {
        private PropertyInfo[] _customSizes;

        private PartBase _part;

        public PartBase Part
        {
            get
            {
                return _part;
            }
            set
            {
                Type type = value.GetType();

                Text = type.GetDisplayName();

                _customSizes = type.GetProperties()
                                   .Where(p => p.GetCustomAttribute<SizeTypeAttribute>().SizeType == Enums.SizeType.Custom)
                                   .ToArray();

                foreach (PropertyInfo p in _customSizes)
                {
                    TableLayoutPanel tbl = new TableLayoutPanel();

                    tbl.Controls.Add(new Label() { Text = p.GetDisplayName()}, 0, 0);
                    tbl.Controls.Add(new TextBox() { }, 0, 1);

                    flpSizes.Controls.Add(tbl);
                }

                _part = value;
            }
        }

        public WizardCustomSizesForm()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
