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
using System.Windows.Shapes;

namespace EmploymentCenter.Windows
{
    /// <summary>
    /// Логика взаимодействия для ResumeWin.xaml
    /// </summary>
    public partial class ResumeWin : Window
    {
        public ResumeWin(Пользователь пользователь)
        {
            InitializeComponent();
            _User = пользователь;
            this.Title = $"Резюме - {_User.Фио}";
            
            TBlockFio.Text = _User.Фио;
            TBlockPhone.Text = _User.Телефон;
            TBlockDesc.Text = _User.Резюме;
        }

        private Пользователь _User;
    }
}
