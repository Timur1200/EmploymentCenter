using EmploymentCenter.Model;
using EmploymentCenter.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для VacancyAddEditPage.xaml
    /// </summary>
    public partial class VacancyAddEditPage : Page
    {
        public VacancyAddEditPage(Вакансия вакансия)
        {
            InitializeComponent();
            if (вакансия == null)
            {
                _Vacancy = new Вакансия {
                    Дата=DateTime.Now,
                    Работодатель = Session.User2
                };
            }
            else
            {
                _Vacancy = вакансия;
            }
            DataContext = _Vacancy;
        }
        private List<Специальности> _SpecList;
        private Вакансия _Vacancy;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _SpecList = EmploymentCenterEntities.GetContext().Специальности.ToList();
            CBoxProf.ItemsSource = _SpecList;
                
        }
        
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBoxSearch.Text == "")
            {
                CBoxProf.ItemsSource = _SpecList;
                CBoxProf.SelectedItem = null;
                return;
            }
            CBoxProf.IsDropDownOpen = true;
            string Text = TBoxSearch.Text;
            CBoxProf.ItemsSource = EmploymentCenterEntities.GetContext().Специальности.Where(q => q.Имя.Contains(Text)).ToList();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (_Vacancy.Код == 0) EmploymentCenterEntities.GetContext().Вакансия.Add(_Vacancy);
            EmploymentCenterEntities.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена");
            PageNavigator.Back();
        }
    }
}
