using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class txtFile
    {
        public static int TextSize(string name)
        {
            try
            {
                var readFile = new BL.FileWork(name);
                string[] arr = readFile.ReadFile();
                int kol = arr.Length;
                return kol;
            }
            catch
            {
                return -1;
            }
        }
    }
}
