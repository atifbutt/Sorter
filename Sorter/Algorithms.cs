using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.IO;

namespace Sorter
{
    public class Algorithms
    {
        Stopwatch stopWatch = new Stopwatch();
        public (int[], int) BubbleSort(int[] Arr, int t)
        {

            stopWatch.Start();
            for (int i = 0; i <= Arr.Count() - 1; i++)
            {
                for (int j = 0; j < Arr.Count() - 1; j++)
                {
                    if (Arr[j] > Arr[j+1])
                    {
                        int temp = Arr[j];
                        Arr[j] = Arr[j + 1];
                        Arr[j + 1] = temp;
                    }
                }
            }
            stopWatch.Stop();
            var time = stopWatch.Elapsed.Milliseconds;
            return (Arr, time);
        }

        public (int[], int) SelectionSort(int[] arr, int t)
        {
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < arr.Count() - 1; i++)
            {
                int min = arr[i];
                for (int j = i + 1; j < arr.Count(); j++)
                {
                    if (arr[j] < min) min = arr[j];
                }

                if (min != arr[i])
                {
                    int temp = arr[i];
                    arr[i] = min;
                    arr[i + 1] = temp;
                }
            }

            stopWatch.Stop();
            var time = stopWatch.Elapsed.Milliseconds;
            return (arr, time);
        }

        public (int[], int) InsertionSort(int[] Arr, int t)
        {
            int CP;
            int VI;

            stopWatch.Reset();
            stopWatch.Start();

            for (int i = 0; i < Arr.Length; i++)
            {
                VI = Arr[i];
                CP = i;

                while (CP > 0 && Arr[CP - 1] > VI)
                {
                    Arr[CP] = Arr[CP - 1];
                    CP = VI;
                    CP = CP - 1;
                }

                Arr[CP] = VI;
            }

            stopWatch.Stop();
            var time = stopWatch.Elapsed.Milliseconds;
            return (Arr, t);
        }
    }
}
