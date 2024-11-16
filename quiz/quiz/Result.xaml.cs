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

namespace quiz
{
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Page
    {
        public Result(int correctAnswers, int totalAnswers)
        {
            InitializeComponent();
            score.Content = $"You Got {correctAnswers} / {totalAnswers}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            NavigationService.Navigate(home);
        }
    }
}
