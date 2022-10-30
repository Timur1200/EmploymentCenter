using EmploymentCenter.Model;
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
    /// Логика взаимодействия для NewVacancyPage.xaml
    /// </summary>
    public partial class NewVacancyPage : Page
    {
        public NewVacancyPage()
        {
            InitializeComponent();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (DGridClient.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            PageNavigator.Frame.Navigate(new VacancyAddEditPage(DGridClient.SelectedItem as Вакансия));
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            if (DGridClient.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            var vacancy = DGridClient.SelectedItem as Вакансия;
            vacancy.Статус = true;
            EmploymentCenterEntities.GetContext().SaveChanges();
            Page_Loaded(null, null);
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGridClient.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            var vacancy = DGridClient.SelectedItem as Вакансия;
            EmploymentCenterEntities.GetContext().Вакансия.Remove(vacancy);
            EmploymentCenterEntities.GetContext().SaveChanges();
            MessageBox.Show("Вакансия удалена");
            Page_Loaded(null, null);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridClient.ItemsSource = EmploymentCenterEntities.GetContext().Вакансия.Where(q => q.Статус == null).ToList();
        }
    }
}
