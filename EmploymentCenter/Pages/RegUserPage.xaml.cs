using EmploymentCenter.Model;
using EmploymentCenter.Windows;
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

namespace EmploymentCenter.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegUserPage.xaml
    /// </summary>
    public partial class RegUserPage : Page
    {
        public RegUserPage()
        {
            InitializeComponent();
            _user = new Пользователь();
            _user1 = new Работодатель();
            CBoxRole.Items.Add("Соискатель");
            CBoxRole.Items.Add("Работодатель");
            CBoxRole.SelectedIndex = 0;
            
            
        }
        private Пользователь _user;
        private Работодатель _user1;

        private void CBoxRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBoxRole.SelectedIndex == 0)
            {
                UserBar.Visibility = Visibility.Visible;
                User2Bar.Visibility = Visibility.Collapsed;
                DataContext = _user;
            }
            else if (CBoxRole.SelectedIndex == 1)
            {
                UserBar.Visibility = Visibility.Collapsed;
                User2Bar.Visibility = Visibility.Visible;
                DataContext = _user1;
            }
               
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (PassBox1.Password != PassBox2.Password)
            {
                MessageBox.Show("Введенные пароли не совпадают!");
                return;
            }
            if (CBoxRole.SelectedIndex == 0)
            {
                _user.Пароль = PassBox1.Password;
                EmploymentCenterEntities.GetContext().Пользователь.Add(_user);
            }
                
            else if (CBoxRole.SelectedIndex == 1)
            {
                _user1.Пароль = PassBox1.Password;
                EmploymentCenterEntities.GetContext().Работодатель.Add(_user1);
            }
              

            EmploymentCenterEntities.GetContext().SaveChanges();
            MessageBox.Show("Регистрация прошла успешно!");
            LoginWin.Frame.NavigationService.GoBack();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            LoginWin.Frame.NavigationService.GoBack();
        }
    }
}
