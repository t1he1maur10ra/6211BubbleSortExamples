using System;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = new WebClient().DownloadString("https://uinames.com/api/?ext&amount=500");
            List<Person> data = new JavaScriptSerializer().Deserialize<List<Person>>(json);
            Stopwatch s1 = new Stopwatch();
            s1.Start();
            BubbleSort(data);
            s1.Stop();

            foreach(Person x in data)
            {
                Console.WriteLine($"Name: {x.name} {x.surname}\nAge: {x.age}\n");
            }
            Console.WriteLine($"Bubble sort time: {s1.ElapsedMilliseconds}ms");
        }

        static void BubbleSort(List<Person> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                /*Internal loop goes through the elements and checks each one*/
                for (int j = 0; j < lst.Count - 1; j++)
                {
                    /*If the current element is larger than the next element, swap them*/
                    if (lst[j].age > lst[j + 1].age)
                    {
                        Person temp = lst[j + 1];
                        lst[j + 1] = lst[j];
                        lst[j] = temp;
                    }
                }
            }
        }
    }


    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string region { get; set; }
        public int age { get; set; }
        public string title { get; set; }
        public string phone { get; set; }
        public Birthday birthday { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Credit_Card credit_card { get; set; }
        public string photo { get; set; }
    }

    public class Birthday
    {
        public string dmy { get; set; }
        public string mdy { get; set; }
        public int raw { get; set; }
    }

    public class Credit_Card
    {
        public string expiration { get; set; }
        public string number { get; set; }
        public int pin { get; set; }
        public int security { get; set; }
    }

}
