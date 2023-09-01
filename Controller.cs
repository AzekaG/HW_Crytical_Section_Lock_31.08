using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace HW_Crytical_Section_Lock_31._08
{
    internal class Controller
    {
        const int CountPairs = 10;
        Random rand;
        public List<int> list;
        public List<int> list2;
        FileStream pFile;
        string path;
       public  Controller() 
        {
            rand = new Random();
            list = new List<int>();
            list2 = new List<int>();
          //  pFile = new FileStream("txtFile.txt", FileMode.OpenOrCreate, FileAccess.Write);
        }




        public void MakeSomNums()
        {
            for (int i = 0; i < CountPairs; i++)
            {
                list.Add(rand.Next(0, 100));
                list2.Add(rand.Next(0, 100));
            }
        }


        public void CreateSomeNums()
        {


            lock(this)
            {

                pFile = new FileStream("txtFile.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(pFile);
                streamWriter.WriteLine("Random pairs : ");
                for (int i = 0; i < CountPairs; i++)
                {
                   
                    streamWriter.WriteLine(list.Last() + "  " + list2.Last());
                }
                streamWriter.Close();
            }
        }

        public void CreateSummNums()
        {

            lock (this)
            {
                pFile = new FileStream("txtFile.txt", FileMode.OpenOrCreate, FileAccess.Write);
                pFile.Position = pFile.Length;
                StreamWriter streamWriter = new StreamWriter(pFile);
                
                streamWriter.WriteLine("Summ : ");

                for (int i = 0; i < CountPairs; i++)
                {
                    
                    streamWriter.WriteLine(list.ElementAt(i) + list2.ElementAt(i));
                }
                streamWriter.Close();
            }
        }


        public void CreateProd()
        {
            lock (this)
            {
                pFile = new FileStream("txtFile.txt", FileMode.OpenOrCreate, FileAccess.Write);
                pFile.Position = pFile.Length;
                StreamWriter streamWriter = new StreamWriter(pFile);

                streamWriter.WriteLine("Product  : ");

                for (int i = 0; i < CountPairs; i++)
                {
                    streamWriter.WriteLine(list.ElementAt(i) * list2.ElementAt(i));
                }
                streamWriter.Close();
            }
        }





    }
}
