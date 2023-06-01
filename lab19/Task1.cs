using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace lab19
{
    internal class Task1
    {
        public static void Run()
        {
            List<int> array = new List<int>();
            int choice, num;
            do
            {
                Console.WriteLine("Enter what to do(1-init array,2-remove simple,3-remove fibonacci,4-save serealized,5-load serealized, 6-show):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        string[] input = Console.ReadLine().Split(',', ' ');
                        array = new List<int>();
                        foreach (string st in input)
                        {
                            int.TryParse(st, out num);
                            array.Add(num);
                        }
                        break;

                    case 2:
                        array = array.Where(num => !IsSimple(num)).ToList();
                        break;
                    case 3:
                        array = array.Where(num => !IsFibonacci(num)).ToList();
                        break;
                    case 4:
                        Save(array);
                        break;
                    case 5:
                        array = Read();
                        break;
                    case 6:
                        Console.WriteLine("Array:");
                        Console.WriteLine(string.Join(", ", array));
                        break;
                }
            } while (choice != 0);
        }
        public static void Save(List<int> array)
        {
            using (FileStream fs = new FileStream("D:\\VisualStudio\\Projects C#\\lab19\\lab19\\text1.dat", FileMode.OpenOrCreate))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(List<int>));
                dcs.WriteObject(fs, array);
            }
            Console.WriteLine("Object serialized");
        }

        public static List<int> Read()
        {
            List<int> result;
            using (FileStream fs = new FileStream("D:\\VisualStudio\\Projects C#\\lab19\\lab19\\text1.dat", FileMode.OpenOrCreate))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(List<int>));
                result = (List<int>)dcs.ReadObject(fs);
            }
            return result;
        }

        public static bool IsSimple(int num)
        {
            int res = 0;
            for (int i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    res++;
            }
            return res < 2;
        }

        public static bool IsFibonacci(int num)
        {
            int a = 0, b = 1, c = 1, tmp;
            while (a < num)
            {
                tmp = b + c;
                a = b;
                b = c;
                c = tmp;
            }
            return a == num;
        }
    }
}
