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
    /// Логика взаимодействия для PersonalDataPage.xaml
    /// </summary>
    public partial class PersonalDataPage : Page
    {
        public PersonalDataPage()
        {
            InitializeComponent();
            DataContext = Session.User1;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            EmploymentCenterEntities.GetContext().SaveChanges();
            MessageBox.Show("Данные были обновлены!");
        }
    }
}
