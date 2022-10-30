using EmploymentCenter.Model;
using EmploymentCenter.Service;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void RegClick(object sender, RoutedEventArgs e)
        {
            LoginWin.Frame.Navigate(new RegUserPage());
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            var list = EmploymentCenterEntities.GetContext().Пользователь.ToList();
            foreach (var item in list)
            {
                if (TBoxPhone.Text == item.Телефон && PassBox.Password == item.Пароль)
                {
                    Session.User1 = item;
                    Auth(1);
                    return;
                }
            }
            var list1 = EmploymentCenterEntities.GetContext().Работодатель.ToList();
            foreach (var item in list1)
            {
                if (TBoxPhone.Text == item.Телефон && PassBox.Password == item.Пароль)
                {
                    Session.User2 = item;
                    Auth(2);
                    return;
                }
            }

            var list2 = EmploymentCenterEntities.GetContext().Специалист.ToList();
            foreach (var item in list2)
            {
                if (TBoxPhone.Text == item.Телефон && PassBox.Password == item.Пароль)
                {
                    Session.User3 = item;
                    Auth(3);
                    return;
                }
            }

            MessageBox.Show("Пользователь не найден!");
        }

        private void Auth(int i)
        {
            AppWin appWin = new AppWin(i);
            appWin.Show();
           var a =  Window.GetWindow(this);
            a.Close();
        }
    }
}
