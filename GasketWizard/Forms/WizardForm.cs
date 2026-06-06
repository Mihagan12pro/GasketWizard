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
    }
}
