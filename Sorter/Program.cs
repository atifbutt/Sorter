using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Algorithms algorithm = new Algorithms();
                Program program = new Program();

                Console.WriteLine("> Sorter");
                Console.Write("> Write 'Auto' to Auto-Generate list or 'Browse' to browse: ");

                int[] list = program.listSelection();
                (int[] l, int t) bubbleSort = algorithm.BubbleSort(list, 0);
                (int[] l, int t) selectionSort = algorithm.SelectionSort(list, 0);
                (int[] l, int t) insertionSort = algorithm.InsertionSort(list, 0);

                Console.WriteLine($"Bubble Sort Computation Time : {bubbleSort.t} ms");
                Console.WriteLine($"Selection Sort Computation Time : {selectionSort.t} ms");
                Console.WriteLine($"Insertion Sort Computation Time : {insertionSort.t} ms");

                foreach (int i in bubbleSort.l) File.AppendAllText("Bubble.txt", i.ToString() + " ");
                foreach (int i in selectionSort.l) File.AppendAllText("Selection.txt", i.ToString() + " ");
                foreach (int i in insertionSort.l) File.AppendAllText("insertion.txt", i.ToString() + " ");

                Console.WriteLine("Wait...! lists are saving in text files.");
                Console.WriteLine("Saved successfully.....");

                var input = Console.ReadLine();
                if (input == "exit") Environment.Exit(0);
            }
            
        }
        public int[] listSelection()
        {
            int[] list = new int[1000000];
            var select = Console.ReadLine();
            if (select == "Auto")
            {
                Console.Write("> Enter Number Limit: ");
                int length = int.Parse(Console.ReadLine());

                Console.Write("> Enter Min Value: ");
                int MinValue = int.Parse(Console.ReadLine());

                Console.Write("> Enter Max Value: ");
                int MaxValue = int.Parse(Console.ReadLine());
                
                Random rand = new Random();
                list = new int[length];
                for (int i = 0; i < length; i++)
                {
                    int no = rand.Next(MinValue, MaxValue);
                    if (!list.Contains(no)) list[i] = no;
                }
                foreach (int i in list) File.AppendAllText("Random.txt", i.ToString() + Environment.NewLine);
                return list;
            }

            else if (select == "Browse")
            {
                Console.Write("> Enter Path of Txt File: ");
                var path = Console.ReadLine();
                var file = File.ReadAllLines(path);
                list = new int[file.Count()];
                int i = 0;
                foreach (string s in file)
                {
                    list[i] = int.Parse(s);
                    i++;
                }
                Console.WriteLine("> Successfully read the file");
                return list;
            }
            return list;
        }
    }
}
