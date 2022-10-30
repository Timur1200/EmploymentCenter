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
    /// Логика взаимодействия для VacancyList.xaml
    /// </summary>
    public partial class VacancyList : Page
    {
        public VacancyList(bool IsAdmin)
        {
            InitializeComponent();
            _IsAdmin = IsAdmin;
        }
        bool _IsAdmin;
        private List<Вакансия> _VacancyList;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _VacancyList = EmploymentCenterEntities.GetContext().Вакансия.Where(q => q.Статус.Value).ToList();
            LView.ItemsSource = _VacancyList;
        }

        private void LView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new SelectedVacancyPage(LView.SelectedItem as Вакансия,_IsAdmin));
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBoxSearch.Text == "")
            {
                LView.ItemsSource = _VacancyList;
                return;
            }
            string text = TBoxSearch.Text.ToLower();
            LView.ItemsSource = EmploymentCenterEntities.GetContext().Вакансия.Where(q => q.Статус.Value && (q.Название.ToLower().Contains(text) || (q.Специальности.Имя.ToLower().Contains(text)))).ToList();
        }
    }
}
