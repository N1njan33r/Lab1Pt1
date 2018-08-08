using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lab1Pt1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("Welcome to the Lab 1 Number Converter");
        }

        #region Limit text to numeric chars only
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        #endregion

        public int textnum1 = 0;
        public int textnum2 = 0;
        public int textlen1 = 1;
        public int textlen2 = 1;

        private void ParseNumbers(int num1, int num2)
        {
            Console.WriteLine(num1);
            Console.WriteLine(num2);
        }
        
        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            bool x = true;

            if (TxtNum1.Text == "" && TxtNum2.Text == "")
            {
                Console.WriteLine("Please enter values in the boxes provided.");
            }
            else if (TxtNum1.Text.Length == 1 && TxtNum2.Text.Length ==1)
            {
                x = true;
                Console.WriteLine("SUCCESS! But because it's only one number.");
            }
            else if (TxtNum1.Text.Length == TxtNum2.Text.Length)
            {
                Console.WriteLine("Numbers are identical length.");
                textnum1 = int.Parse(TxtNum1.Text);
                textnum2 = int.Parse(TxtNum2.Text);
                textlen1 = TxtNum1.Text.Length;
                textlen2 = TxtNum2.Text.Length;

                int i = 1;
                int j = i + 1;
                while(j <= textlen1 && x == true)
                {
                    //Console.WriteLine(i);

                    var num1 = TxtNum1.Text;
                    var num2 = TxtNum2.Text;

                    if (num1[textlen1 - i] + num2[textlen2 - i] == num1[textlen1 - j] + num2[textlen2 - j])
                    {
                        x = true;
                    }
                    else
                    {
                        x = false;
                    }

                    i++;
                    j++;
                }

                if (x) { Console.WriteLine("SUCCESS!"); }
                else { Console.WriteLine("FAIL!"); }
            }
            else
            {
                Console.WriteLine("Numbers must be identical length.");
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtNum1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void TxtNum2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void TxtNum1_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                BtnSend_Click(BtnSend, e);
            }
        }
    }

    //public class Comparison
    //{
    //    private string numvalue1;

    //    public string Num1
    //    {
    //        get { return numvalue1; }
    //        set { numvalue1 = value; }
    //    }

    //    private string numvalue2;

    //    public string Num2
    //    {
    //        get { return numvalue2; }
    //        set
    //        {
    //            if (value != numvalue2)
    //            {
    //                numvalue2 = value;
    //            }
    //        }
    //    }
    //}
}
