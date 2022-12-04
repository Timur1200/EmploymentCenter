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
    /// Логика взаимодействия для ResponseWorkersPage.xaml
    /// </summary>
    public partial class ResponseWorkersPage : Page
    {
        public ResponseWorkersPage(Вакансия вакансия)
        {
            InitializeComponent();
            _vacancy = вакансия;
        }
        private Вакансия _vacancy;

        private void ResumeClick(object sender, RoutedEventArgs e)
        {
            Пользователь user = (DGridClient.SelectedItem as Отклик).Пользователь;
            ResumeWin resumeWin = new ResumeWin(user);
            resumeWin.Show();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            DGridClient.ItemsSource = EmploymentCenterEntities.GetContext().Отклик.Where(q => q.Вакансия.Код == _vacancy.Код && q.Статус == 0).ToList();
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            EmploymentCenterEntities.GetContext().SaveChanges();
            MessageBox.Show("Что то делаю");
            Отклик отклик = DGridClient.SelectedItem as Отклик;
            отклик.Статус = (int)StatusResponseEnum.Принят;
            EmploymentCenterEntities.GetContext().SaveChanges();
            MessageBox.Show(отклик.Код.ToString());
           
            Mail.SendMail(отклик.Пользователь.Почта, отклик);
            PageLoaded(null, null);
            
            
        }

        private void DeclineClick(object sender, RoutedEventArgs e)
        {
            Отклик отклик = DGridClient.SelectedItem as Отклик;
            отклик.Статус = (int)StatusResponseEnum.Отклонен;
            EmploymentCenterEntities.GetContext().SaveChanges();
            PageLoaded(null, null);
        }

       
    }
}
