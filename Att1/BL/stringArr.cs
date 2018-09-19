using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class StringArr
    {
        public string[] Arr { get; set; }

        public StringArr(string[] arr)
        {
            Arr = arr;
        }

        public static int TwoQue(string[] arrStr1,string[] arrStr2, out string[] strOut)
        {
            List<string> listOut = new List<string>();
            var X = new BL.Queue<double>();
            var Y = new BL.Queue<double>();
            foreach (var i in arrStr1)
                X.Add(double.Parse(i));
            foreach (var j in arrStr2)
                Y.Add(double.Parse(j));
            int counter = 0;
            while (!X.IsEmpty() && !Y.IsEmpty())
            {
                double x = X.Take();
                double y = Y.Take();
                if (x < y)
                {
                    X.Add(x + y);
                    listOut.Add(string.Format("x={0} y={1} Добавление в X {2}\n", Math.Round(x, 2), Math.Round(y, 2), Math.Round(x + y, 2)));
                }
                else
                {
                    Y.Add(x - y);
                    listOut.Add(string.Format("x={0} y={1} Добавление в Y {2}\n", Math.Round(x, 2), Math.Round(y, 2), Math.Round(x - y, 2)));
                }
                counter++;
            }
            strOut = listOut.ToArray();
            return counter;
        }


        public void Sol(out int sum, out int kol)
        {
            sum = 0;
            kol = 0;
            foreach (string str in Arr)
            {
                str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int numb = int.Parse(str);
                sum += numb;
                kol++;
            }
        }
    }
}
