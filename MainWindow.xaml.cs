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

namespace Kalkulator
{

    public partial class MainWindow : Window
    {
        Calcer forCalc = new Calcer();
        private const string DefaultExpression = "Введите выражение...";
        private const string ErrorExpression = "Айайай нильзя на нуль делить";
        public MainWindow()
        {
            forCalc.test();
            InitializeComponent();
        }

        private void Number_button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.Text == DefaultExpression || TextBox.Text == ErrorExpression)
            {
                TextBox.Text = "";
            }

            TextBox.Text += (sender as Button).Content;
        }

        private void Operator_button_Click(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;

            if (bt.Content.ToString()[0] == '-' || bt.Content.ToString()[0] == '(')
            {
                if (TextBox.Text == DefaultExpression) TextBox.Text = bt.Content.ToString();
                
            }

            if (TextBox.Text == DefaultExpression || TextBox.Text.Last() == '+' || TextBox.Text.Last() == '-' || TextBox.Text.Last() == '*' || TextBox.Text.Last() == '/')
            {
                return;
            }

            TextBox.Text += (sender as Button).Content;
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.Text.Length > 0 && TextBox.Text != DefaultExpression)
            {
                TextBox.Text = TextBox.Text.Substring(0, TextBox.Text.Length - 1);
            }

            if (TextBox.Text.Length == 0)
            {
                TextBox.Text = DefaultExpression;
            }
        }

        private void Clear_button_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = DefaultExpression;
            
        }

        private void Equal_button_Click(object sender, RoutedEventArgs e)
        {

            if (TextBox.Text != DefaultExpression)
            { 
                var solve = forCalc.SolveExpression(TextBox.Text);
                TextBox.Text = solve;
            }
        }
    }
}
