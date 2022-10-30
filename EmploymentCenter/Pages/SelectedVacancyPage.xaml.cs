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
    /// Логика взаимодействия для SelectedVacancyPage.xaml
    /// </summary>
    public partial class SelectedVacancyPage : Page
    {
        public SelectedVacancyPage(Вакансия вакансия,bool isAdmin)
        {
            InitializeComponent();
            _IsAdmin = isAdmin;
            _Vacancy = вакансия;
            DataContext = _Vacancy;
            if (isAdmin)
            {
                BtnSend.Visibility = Visibility.Collapsed;
                BtnDel.Visibility = Visibility.Visible;
            }
        }
        private Вакансия _Vacancy;
        private bool IsNotSended;
        private bool _IsAdmin;

        private void SendClick(object sender, RoutedEventArgs e)
        {
            if (IsNotSended)
            {
                
                Отклик отклик = new Отклик
                {
                    Пользователь = Session.User1,
                    Вакансия = _Vacancy,
                    ДатаОтправки = DateTime.Now,
                    Статус = 0
                };
                EmploymentCenterEntities.GetContext().Отклик.Add(отклик);
                EmploymentCenterEntities.GetContext().SaveChanges();
                Page_Loaded(null, null);
            }
            else
            {
                

                PageNavigator.Frame.Navigate(new MyResponsePage());
            }
            
            
        }

        private bool CheckSend()
        {
            bool x = 0 == EmploymentCenterEntities.GetContext().
                Отклик.Where(q => q.КодВакансии == _Vacancy.Код && q.КодПользователя == Session.User1.Код)
                .Count();
            if (x)
            {
                // если не отправил
                BtnSend.Content = "Откликнуться";
            }
            else
            {
                // если отправил
                BtnSend.Content = "Отправлен";
            }
            return x;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_IsAdmin)
            {
                return;
            }
            IsNotSended = CheckSend();
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show( "Вы действительно хотите удалить эту вакансию?", "Внимание!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
               var a= EmploymentCenterEntities.GetContext().Отклик.Where(q => q.КодВакансии == _Vacancy.Код).ToList();
                EmploymentCenterEntities.GetContext().Отклик.RemoveRange(a);
                EmploymentCenterEntities.GetContext().SaveChanges();
                EmploymentCenterEntities.GetContext().Вакансия.Remove(_Vacancy);
                EmploymentCenterEntities.GetContext().SaveChanges();
                PageNavigator.Frame.Navigate(new VacancyList(true));
                MessageBox.Show("Вакансия была удалена!");
            }
            else if (dialogResult == MessageBoxResult.No)
            {
                //do something else
            }
        }
    }
}
