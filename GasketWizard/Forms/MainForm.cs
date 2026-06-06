using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasketWizard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            tbSavingPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void btSelectSavingFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbSavingPath.Text = dialog.SelectedPath;
            }
        }
    }
}
