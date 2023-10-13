using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _005_SortAlgorithm
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        static int MAX = 100000;
        int[] a = new int[MAX];
        int N = 0; // 데이터의 개수

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            N = int.Parse(txtData.Text);

            Random r = new Random();
            for (int i = 0; i < N; i++)
            {
                a[i] = r.Next(3 * N);
            }

            Graph();
        }

        private void Graph()
        {
            can.Children.Clear();

            for(int i = 0; i < N; i++)
            {
                Line l = new Line();
                l.X1 = l.X2 = i * 5 + 2; // X축 5씩 증가
                if (l.X1 > can.Width)
                {
                    break;
                }
                l.Y1 = can.Height - (int)(a[i] / (3.0 * N) * can.Height);
                l.Y2 = can.Height; // 0
                l.Stroke = Brushes.RoyalBlue;
                l.StrokeThickness = 4;
                can.Children.Add(l);
            }
        }

        private void BtnTime_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            BubbleSort();
            watch.Stop();
            long tickBubble = watch.ElapsedTicks;

            // 정렬된 그래프 표시
            Graph();

            // 측정시간을 Canvas에 표시
            TextBlock txtBubble = new TextBlock();
            txtBubble.Text = "Bubble Sort : " + tickBubble / 10000.0 + " ms.";
            txtBubble.Foreground = Brushes.Black;
            txtBubble.Background = Brushes.White;
            Canvas.SetLeft(txtBubble, 60);
            Canvas.SetTop(txtBubble, 40);
            can.Children.Add(txtBubble);

            Random r = new Random();
            for (int i = 0; i < N; i++)
            {
                a[i] = r.Next(3 * N);
            }

            //watch.Reset();
            watch = System.Diagnostics.Stopwatch.StartNew();
            QuickSort(a, 0, N - 1);
            watch.Stop();
            long tickQuick = watch.ElapsedTicks;

            TextBlock txtQuick = new TextBlock();
            txtQuick.Text = "Quick Sort : " + tickQuick / 10000.0 + " ms.";
            txtQuick.Foreground = Brushes.Black;
            txtQuick.Background = Brushes.White;
            Canvas.SetLeft(txtQuick, 60);
            Canvas.SetTop(txtQuick, 60);
            can.Children.Add(txtQuick);

            for (int i = 0; i < N; i++)
            {
                a[i] = r.Next(3 * N);
            }

            watch = System.Diagnostics.Stopwatch.StartNew();
            MergeSort(a, 0, N - 1);
            watch.Stop();
            long tickMerge = watch.ElapsedTicks;

            TextBlock txtMerge = new TextBlock();
            txtMerge.Text = "Merge Sort : " + tickMerge / 10000.0 + " ms.";
            txtMerge.Foreground = Brushes.Black;
            txtMerge.Background = Brushes.White;
            Canvas.SetLeft(txtMerge, 60);
            Canvas.SetTop(txtMerge, 80);
            can.Children.Add(txtMerge);
        }

        private void BtnBubble_Click(object sender, RoutedEventArgs e)
        {
            BubbleSort();
        }

        private void BtnQuick_Click(object sender, RoutedEventArgs e)
        {
            QuickSort(a, 0, N - 1);
        }

        private void BtnMerge_Click(object sender, RoutedEventArgs e)
        {
            MergeSort(a, 0, N - 1);
            Graph();
        }

        private void BubbleSort()
        {
            for (int i = N - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (a[j] > a[j + i])
                    {
                        int t = a[j];
                        a[j] = a[j + i];
                        a[j + i] = t;
                    }
                }
            }
            Graph();
        }

        private void QuickSort(int[] a, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(a, left, right);
                QuickSort(a, left, q-1);
                QuickSort(a, q + 1, right);
            }
        }

        private int Partition(int[] a, int left, int right)
        {
            int i = left;
            int j = right;

            int pivot = a[left];

            while (i < j)
            {
                while ((i <= right) && (a[i] < pivot))
                    i++;
                while ((j>=left) && (a[j] > pivot))
                    j--;

                if (i < j)
                {
                    int t = a[i];
                    a[i] = a[j];
                    a[j] = t;

                    if (a[i] == a[j])
                        j--;
                }
            }
            return j;
        }

        private void MergeSort(int[] a, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right)/2;
                MergeSort(a, left, mid);
                MergeSort(a, mid + 1, right);
                Merge(a, left, mid, right);
            }
        }

        int[] sorted = new int[MAX];
        private void Merge(int[] a, int left, int mid, int right)
        {
            int i, j, k = left;
            for (i = left, j = mid + 1; i <= mid && j <= right;)
                sorted[k++] = (a[i] <= a[j]) ? a[i++] : a[j++];
            if (i > mid)
                for (int l = j; l <= right; l++)
                    sorted[k++] = a[l];
            else
                for(int l = i; l <= mid; l++)
                    sorted[k++] = a[l];

            // sorted[]를 a[]로 복사
            for (int l = left; l <= right; l++)
            {
                a[l] = sorted[l];
            }

        }
    }
}
