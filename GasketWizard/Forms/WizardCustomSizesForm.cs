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
                _part = value;

                Type type = value.GetType();

                Text = type.GetCustomAttribute<PartTitleAttribute>().LocalizedTitle;

                _customSizes = type.GetProperties()
                                   .Where(p => p.GetCustomAttribute<PartParameterAttribute>() != null && p.GetCustomAttribute<PartParameterAttribute>().SizeType == Enums.SizesTypes.Custom)
                                   .ToArray();

                int row = 0;
                int maxLength = 20;

                foreach (PropertyInfo p in _customSizes)
                {
                    TableLayoutPanel tbl = new TableLayoutPanel();
                    tbl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                    tbl.Margin = new Padding(0, 10, 0, 10);
                    tbl.AutoSize = true;

                    tbl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                    string name = p.GetCustomAttribute<PartParameterAttribute>().LocalizedTitle;
                    string propertyValue = $"{p.GetValue(Part)}";

                    tbl.Controls.Add(new Label() { Text = name, AutoSize = true}, 0, 0);
                    tbl.Controls.Add(new TextBox() { Tag = new TextBoxTag( p, _part, p.PropertyType), Text = $"{propertyValue}" }, 0, 1);

                    maxLength = Math.Max(tbl.Size.Width, maxLength);

                    flpSizes.Controls.Add(tbl);

                    row++;
                }

                foreach(var c in flpSizes.Controls)
                {
                    if (c is TableLayoutPanel tbl)
                    {
                        foreach(var c2 in tbl.Controls)
                        {
                            if (c2 is TextBox tb)
                            {
                                tb.Width = maxLength;
                                tb.TextChanged += Tb_TextChanged;
                            }
                        }
                    }
                }

                btOk.Enabled = (Part.HasErrors == false);
            }
        }

        private void Tb_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox tb && tb.Tag is TextBoxTag tag)
            {
                flpIssues.Controls.Clear();

                bool isValid = true;

                object value;

                if (tag.PropertyType == typeof(double))
                {
                    isValid = double.TryParse(tb.Text, out double result);

                    value = result;
                }
                else //int
                {
                    isValid = int.TryParse(tb.Text, out int result);

                    value = result;
                }

                if (!isValid)
                {
                    btOk.Enabled = isValid;

                    ToolTip toolTip = new ToolTip();
                    toolTip.IsBalloon = true;
                    toolTip.ToolTipTitle = "Ошибка!";
                    toolTip.ToolTipIcon = ToolTipIcon.Error;
                    toolTip.Show("Ввод некорректных данных", tb, 0, -90, 1000);

                    return;
                }

                tag.Property.SetValue(Part, value);

                btOk.Enabled = (Part.HasErrors == false);

                foreach(string error in Part.Errors)
                {
                    flpIssues.Controls.Add(new Label() { Text = error, AutoSize = true, Margin = new Padding(0, 10, 0, 10) });
                }
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

        private void WizardCustomSizesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btOk.Enabled && DialogResult != DialogResult.OK)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите закрыть данное окно?\nДанные, которые вы вводили, будут стерты.", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes) 
                    e.Cancel = true;
            }
        }

        private void WizardCustomSizesForm_Load(object sender, EventArgs e)
        {

        }
    }

    class TextBoxTag
    {
        public PropertyInfo Property { get; private set; }

        public PartBase Part { get; private set; }

        public Type PropertyType { get; private set; }

        public TextBoxTag(
            PropertyInfo property,
            PartBase part,
            Type propertyType)
        {
            Part = part;
            Property = property;
            PropertyType = propertyType;
        }
    }
}
