using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_Sorting
{
    internal class Program
    {
        static int N = 100;
        static int[] a = new int[N];
        static void Main(string[] args)
        {
            RandomInit();
            PrintArray();

            Array.Sort(a);
            Console.WriteLine("\nArray.Sort() : ");
            PrintArray();

            RandomInit();
            BubbleSort();

            RandomInit();
            SelectionSort();

            RandomInit();
            InsertionSort();

            RandomInit();
            ShellSort();

            RandomInit();
            HeapSort();
        }

        private static void HeapSort()
        {
            // 처음 임의로 저장된 배열을 힙으로 만드는 과정
            for (int i = N / 2 - 1; i >= 0; i--) 
                DownHeap(a, N, i);

            Console.WriteLine("\nHeap 구성 : ");
            PrintArray();

            for (int i = N - 1; i >= 0; i--)
            {
                // 루트와 맨 뒤의 값 변경
                Swap(0, i);
                DownHeap(a, i, 0); // N -> i (1 씩 감소)
            }
            Console.WriteLine("HeapSort : ");
            PrintArray();
        }

        private static void DownHeap(int[] a, int n, int i)
        {
            int largest = i;
            int left = 2 * i;
            int right = 2 * i + 1;

            if (left < n && a[left] > a[largest])
                largest = left;
            if (right < n  && a[right] > a[largest])
                largest = right;

            if (largest != i) // 자식이 부모보다 큰 경우
            {
                Swap(i, largest);
                DownHeap(a, n, largest);
            }
        }

        private static void ShellSort()
        {
            int[] h = { 0, 1, 4, 10, 23, 57, 132, 301, 701, 1750 };
            int index = 0; // h[]의 시작하는 값 인덱스
            while (h[index] < N / 2) 
                index++;
            int gap = h[--index];
            
            Console.WriteLine("\nShellSort : ");
            while (gap > 0)
            {
                Console.WriteLine("gap = {0}", gap);
                for(int i = gap; i < N; i++)
                {
                    int current = a[i];
                    int j = i;
                    while (j >= gap && a[j - gap] > current)
                    {
                        a[j] = a[j - gap];
                        j = j - gap;
                    }
                    a[j] = current;
                }
                gap = h[--index];
            }
            PrintArray();
        }

        private static void InsertionSort()
        {
            for (int i = 0; i < N; i++)
            {
                int current = a[i];
                int j = i - 1;
                while (j >= 0 && a[j] > current)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = current;
            }
            Console.WriteLine("\nInsertionSort : ");
            PrintArray();
        }

        private static void SelectionSort()
        {
            for (int i = 0; i < N - 1; i++)
            {
                int min = i; // 최소값이 들어있는 인덱스
                for (int j = i + 1; j < N; j++)
                    if (a[min] > a[j])
                        min = j;
                Swap(i, min);
            }
            Console.WriteLine("\nSelectionSort : ");
            PrintArray();
        }

        private static void BubbleSort()
        {
            for(int i = N-1; i >= 0; i--)
                for (int j = 0; j < i; j++)
                    if (a[j] > a[j + 1])
                        Swap(j, j + 1);
            Console.WriteLine("\nBubbleSort : ");
            PrintArray();
        }

        private static void Swap(int i, int j)
        {
            int t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        private static void PrintArray()
        {
            foreach (var i in a)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        private static void RandomInit()
        {
            Random r = new Random();
            for (int i = 0; i < N; i++)
                a[i] = r.Next(1000);
        }
    }
}
