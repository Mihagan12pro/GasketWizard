using System.Windows.Forms;

namespace GasketWizard.Commands
{
    public static class HelloKompasCommand
    {
        public static void HelloKompas(this GasketWizardApp app)
        {
            MessageBox.Show("Привет, КОМПАС-3D!");
        }
    }
}
