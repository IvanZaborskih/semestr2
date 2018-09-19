using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._1._25
{
    static class Program
    {
        internal static Form1 MainForm;
        internal static GraphEdit EditorForm;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Form1();
            EditorForm = new GraphEdit();
            Application.Run(MainForm);
        }
    }
}
