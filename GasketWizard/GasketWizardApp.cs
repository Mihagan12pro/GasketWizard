using GasketWizard.Commands;
using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GasketWizard
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class GasketWizardApp
    {
        [return: MarshalAs(UnmanagedType.BStr)]
        public string GetLibraryName()
        {
            return "Каталог: сальники";
        }

        public void ExternalRunCommand([In] short command, [In] short mode, [In, MarshalAs(UnmanagedType.IDispatch)] object kompas_)
        {
            switch (command)
            {
                case 1:
                    this.HelloKompas();
                    break;
                case 2:
                    WizardForm wizardForm = new WizardForm();
                    wizardForm.ShowDialog();
                    break;
            }
        }

        [return: MarshalAs(UnmanagedType.BStr)]
        public string ExternalMenuItem(short number, ref short itemType, ref short command)
        {
            string result = string.Empty;   //По уполчанию - пустая строка
            itemType = 1;                   //MENUITEM

            switch (number)
            {
                case 1:
                    result = "Привет, КОМПАС-3D!";
                    command = 1;
                    break;

                case 2:
                    result = "Шайба";
                    command = 2;
                    break;

                case 3:
                    itemType = 3;           //ENDMENU
                    command = -1;
                    break;
            }

            return result;
        }

        [ComRegisterFunction]
        public static void RegisterKompasLib(Type t)
        {
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                string keyName = @"SOFTWARE\Classes\CLSID\{" + t.GUID.ToString() + "}";
                regKey = regKey.OpenSubKey(keyName, true);
                regKey.CreateSubKey("Kompas_Library");
                regKey = regKey.OpenSubKey("InprocServer32", true);
                regKey.SetValue(null, System.Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\mscoree.dll");
                regKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("При регистрации класса для COM-Interop произошла ошибка:\n{0}", ex));
            }
        }

        [ComUnregisterFunction]
        public static void UnregisterKompasLib(Type t)
        {
            RegistryKey regKey = Registry.LocalMachine;
            string keyName = @"SOFTWARE\Classes\CLSID\{" + t.GUID.ToString() + "}";
            RegistryKey subKey = regKey.OpenSubKey(keyName, true);
            subKey.DeleteSubKey("Kompas_Library");
            subKey.Close();
        }
    }
}
