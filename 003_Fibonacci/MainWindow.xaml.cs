using System;
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

namespace _003_Fibonacci
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(textBox.Text);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            int fibo = 1;
            for (int i = 1; i <= n; i++)
            {
                fibo = Fibonacci(i);
                string s = fibo.ToString();
                listBox.Items.Add(s);
            }

            watch.Stop();

            var elapsedTicks = watch.ElapsedTicks;  // 또는 watch.ElapsedMilliseconds
            string result = "반복문 실행시간 = " + elapsedTicks / 10000.0 + "ms";
            listBox.Items.Add(result);

            watch = System.Diagnostics.Stopwatch.StartNew();

            int rfibo = 1;
            for (int i = 1; i <= n; i++)
            {
                rfibo = rFibonacci(i);
                string s = rfibo.ToString();
                listBox.Items.Add(s);
            }

            watch.Stop();

            elapsedTicks = watch.ElapsedTicks;
            result = "재귀함수 실행시간 = " + elapsedTicks / 10000.0 + " ms";
            listBox.Items.Add(result);
        }

        private int Fibonacci(int x) // 반복문
        {
            int a = 0, b = 0, c = 1;
            for (int i = 0; i <= x; i++)
            {
                a = b;
                b = c;
                c = a + b;
            }
            return a;
        }

        private int rFibonacci(int x) // 재귀
        {
            if (x == 1 || x == 2)
                return 1;
            else
                return rFibonacci(x - 1) + rFibonacci(x - 2);
        }
    }
}
