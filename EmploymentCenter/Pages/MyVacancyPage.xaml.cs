using EmploymentCenter.Model;
using EmploymentCenter.Service;
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
    /// Логика взаимодействия для MyVacancyPage.xaml
    /// </summary>
    public partial class MyVacancyPage : Page
    {
        public MyVacancyPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridClient.ItemsSource = EmploymentCenterEntities.GetContext().Вакансия.Where(q => q.КодРаботодателя == Session.User2.Код).ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new VacancyAddEditPage(null));
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new VacancyAddEditPage(DGridClient.SelectedItem as Вакансия));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGridClient.SelectedItem == null)
            {
                return;
            }
            Вакансия vacancy = DGridClient.SelectedItem as Вакансия;
            if (vacancy.Статус == null)
            {
                MessageBox.Show("Вы не можете это сделать! Данная вакансия находится на рассмотрении!");
            }
            else
            {
                vacancy.Статус = !vacancy.Статус;
                EmploymentCenterEntities.GetContext().SaveChanges();
                Page_Loaded(null, null);
            }
            
        }

        private void ViewResponsePageClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new ResponseWorkersPage(DGridClient.SelectedItem as Вакансия));
        }
    }
}
