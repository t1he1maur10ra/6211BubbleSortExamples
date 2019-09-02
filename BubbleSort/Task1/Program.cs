using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static int size = 1000000;
        static void Main(string[] args)
        {
            Stopwatch st1 = new Stopwatch();
            double[] data = new double[size];
            Console.WriteLine("************** Bubble Sorting Exercise 1 **************\n");
            Populate(data);
            //Display(data);
            st1.Start();
            double[] sorted = StandardBubbleSort(data);
            st1.Stop();
            //Display(sorted);
            Console.WriteLine($"Standard bubble sort time: {st1.ElapsedMilliseconds}ms");
            st1.Reset();

            st1.Start();
            double[] sorted2 = ImprovedBubbleSort(data);
            st1.Stop();
            Console.WriteLine($"\nImproved bubble sort time: {st1.ElapsedMilliseconds}ms");

        }

        static void Populate(double[] arr)
        {
            Random rnd = new Random();
            for(int count = 0; count < arr.Length; count++)
            {
                arr[count] = Math.Round((rnd.NextDouble() * 100),2);
            }
        }

        static void Display<T>(T[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
                if((i+1)%10 == 0)
                    Console.WriteLine();
            }
        }

        static double[] StandardBubbleSort(double[] arr)
        {
            double[] temp = new double[size];
            Array.Copy(arr, 0, temp, 0, arr.Length);
            for(int i = 0; i < temp.Length; i++)
            {
                for(int j = 0; j < temp.Length-1; j++)
                {
                    if(temp[j] > temp[j+1])
                    {
                        double swap = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = swap;
                    }
                }
            }
            return temp;
        }

        static double[] ImprovedBubbleSort(double[] arr)
        {
            double[] temp = new double[size];
            Array.Copy(arr, 0, temp, 0, arr.Length);
            bool check = false;
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp.Length - 1 - i; j++)
                {
                    check = false;
                    if (temp[j] > temp[j + 1])
                    {
                        double swap = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = swap;
                        check = true;
                    }
                }
                if (!check)
                    break;
            }
            return temp;
        }
    }
}
