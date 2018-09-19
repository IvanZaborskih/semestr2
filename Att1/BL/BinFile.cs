using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BL
{
    public class BinFile
    {
        public string Name { get; set; }

        public BinFile(string path)
        {
            Name = path;
        }


        public string[] ReadFile()
        {
            List<string> arrStr = new List<string>();
            var fr = new StreamReader(this.Name);
            BinaryReader binr = new BinaryReader(fr.BaseStream);
            try
            {
                while (true)
                {
                    int i = binr.ReadInt32();
                    string str = i.ToString();
                    arrStr.Add(str);
                }
            }
            catch { }
            fr.Close();
            return arrStr.ToArray();
        }

        public string[] SetSize50()
        {
            long lengt = new FileInfo(Name).Length;
            StreamWriter sw = null;
            int size = 50 * sizeof(Int32);
            if (lengt < size)
            {
                sw = new StreamWriter(Name, true);
                var br = new BinaryWriter(sw.BaseStream);
                for (int i = (int)lengt; i < size; i++)
                {
                    br.Write(byte.MinValue);
                }
            }
            else if (lengt >= size)
            {
                StreamReader sr = new StreamReader(Name);
                BinaryReader br = new BinaryReader(sr.BaseStream);
                byte[] buf = new byte[size];
                br.Read(buf, 0, size);
                br.Close();
                sw = new StreamWriter(Name);
                var bw = new BinaryWriter(sw.BaseStream);
                bw.Write(buf);
            }
            sw.Close();
            return ReadFile(Name);
        }




        //static
        public static void ConvertTxtBin(string inputFile, string outputFile)
        {
            var fr = new StreamReader(inputFile);
            List<int> listInt = new List<int>();
            while (!fr.EndOfStream)
            {
                string s = fr.ReadLine();
                listInt.Add(Int32.Parse(s));
            }
            var br = new BinaryWriter(new StreamWriter(outputFile).BaseStream);
            foreach (var num in listInt)
            {
                br.Write(num);
            }
            br.Close();
            fr.Close();
        }

        public static string[] SetSize50(string name)
        {
            long lengt = new FileInfo(name).Length;
            StreamWriter sw=null;
            int size = 50 * sizeof(Int32);
            if (lengt < size)
            {
                sw = new StreamWriter(name, true);
                var br = new BinaryWriter(sw.BaseStream);
                for (int i = (int)lengt; i < size; i++)
                {
                    br.Write(byte.MinValue);
                }
            }
            else if (lengt >= size)
            {
                StreamReader sr = new StreamReader(name);
                BinaryReader br = new BinaryReader(sr.BaseStream);
                byte[] buf = new byte[size];
                br.Read(buf, 0, size);
                br.Close();
                sw = new StreamWriter(name);
                var bw = new BinaryWriter(sw.BaseStream);
                bw.Write(buf);
            }
            sw.Close();
            return ReadFile(name);
        }

        public static string[] ReadFile(string path)
        {
            List<string> arrStr = new List<string>();
            var fr = new StreamReader(path);
            BinaryReader binr = new BinaryReader(fr.BaseStream);
            try
            {
                while (true)
                {
                    int i = binr.ReadInt32();
                    string str = i.ToString();
                    arrStr.Add(str);
                }
            }
            catch { }
            fr.Close();
            return arrStr.ToArray();
        }

    }
}
