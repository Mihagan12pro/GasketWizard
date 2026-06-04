using GasketWizard.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasketWizard
{
    public partial class WizardForm : Form
    {
        public WizardForm()
        {
            InitializeComponent();
        }

        public void SetParameters(
            Bitmap image,
            PartBase partBase)
        {
            pbSketch.Image = image;

            Type type = partBase.GetType();

            Text = ((DisplayNameAttribute)type.GetCustomAttribute(typeof(DisplayNameAttribute))).DisplayName;
        }
    }
}
