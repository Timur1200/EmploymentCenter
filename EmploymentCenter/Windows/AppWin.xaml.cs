using EmploymentCenter.Model;
using EmploymentCenter.Pages;
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
using System.Windows.Shapes;

namespace EmploymentCenter.Windows
{
    /// <summary>
    /// Логика взаимодействия для AppWin.xaml
    /// </summary>
    public partial class AppWin : Window
    {
        public AppWin(int role)
        {
            InitializeComponent();
            if (role == 1) UserMenu1.Visibility = Visibility.Visible;
            else if (role == 2) UserMenu2.Visibility = Visibility.Visible;
            else if (role==3) UserMenu3.Visibility = Visibility.Visible;
            PageNavigator.Frame = MainFrame;
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            LoginWin loginWin = new LoginWin(); 
            loginWin.Show();
            this.Close();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Back();
        }

        private void MyVacancyClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new MyVacancyPage());
        }

        private void NewVacancyClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new NewVacancyPage());
        }

        private void SearchVacancyClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new VacancyList(false));
        }

        private void MyResponseClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new MyResponsePage());
        }

        private void AllVacancyClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new VacancyList(true));
        }
    }
}
