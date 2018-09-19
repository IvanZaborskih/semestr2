using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BL
{
    public class FileWork
    {
        public string Way { get; set; }
        
        public FileWork(string way)
        {
            Way = way;
        }

        public string[] ReadFile()
        {
            return File.ReadAllLines(Way);
        }





        public void SumInt(out int Sum,out int Kol)
        {
            string[] arr=ReadFile();
            StringArr str = new StringArr(arr);
            str.Sol(out int sum,out int kol);
            Sum = sum;
            Kol = kol;
        }

    }
}
