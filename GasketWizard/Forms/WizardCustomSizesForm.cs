using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Extensions;
using System;
using System.Drawing;
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

                int row = 0;
                int maxLength = 20;

                foreach (PropertyInfo p in _customSizes)
                {
                    TableLayoutPanel tbl = new TableLayoutPanel();
                    tbl.AutoSize = true;

                    tbl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                    string name = p.GetDisplayName();

                    tbl.Controls.Add(new Label() { Text = name, AutoSize = true}, 0, 0);
                    tbl.Controls.Add(new TextBox() { }, 0, 1);

                    maxLength = Math.Max(tbl.Size.Width, maxLength);

                    tblSizes.Controls.Add(tbl, 0, row);

                    row++;
                }

                foreach(var c in tblSizes.Controls)
                {
                    if (c is TableLayoutPanel tbl)
                    {
                        foreach(var c2 in tbl.Controls)
                        {
                            if (c2 is TextBox tb)
                                tb.Width = maxLength;
                        }
                    }
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

        private void btCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
