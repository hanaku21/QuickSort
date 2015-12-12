using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{

    class Program
    {
        static double[] data;

        static void Main(string[] args)
        {
            try
            {
                char[] delimiter = { ' ' };
                bool isTryParse = true;
                Console.WriteLine("Quick sort programming");
                do
                {
                    Console.Write("Input Data :");
                    string x = Console.ReadLine();
                    string[] stx = x.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                    double[] inputdata = new double[stx.Length];
                    for (int i = 0; i < stx.Length; i++)
                    {
                        isTryParse = double.TryParse(stx[i], out inputdata[i]);
                        if (!isTryParse)
                        {
                            Console.WriteLine("Error : Input Data is not number. Try Again.");
                            break;
                        }
                    }
                    data = inputdata;
                } while (!isTryParse);

                QuickSort(0, data.Length-1);

                ShowData();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :"+ex.Message+Environment.NewLine+"Data:"+ex.Data);
                Console.ReadKey();
            }
        }

        static void QuickSort(int p, int r)
        {
            if (p < r)
            {
                int q = Partition(p,r);
                QuickSort( p, q - 1);
                QuickSort(q + 1, r);
            }
        }

        static int Partition(int p, int r)
        {
            double checking = data[r];
            int i = p-1;
                for (int j = p; j < r; j++)
                {
                    if (data[j] <= checking)
                    {
                        i = i + 1;
                        Exchange(i, j);
                    }
                }
                Exchange(i + 1, r);

            return i + 1;
        }

        static void Exchange(int i, int j)
        {
            double temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

        static void ShowData()
        {
            Console.Write("Output Result: ");
            foreach (double item in data)
            {
                Console.Write(item.ToString()+" ");
            }
        }

    }
}
