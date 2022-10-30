using EmploymentCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCenter.Service
{
    internal class Session
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public static Пользователь User1 {get;set; }
        /// <summary>
        /// Работодатель
        /// </summary>
        public static Работодатель User2 { get; set; }
        /// <summary>
        /// Специалист
        /// </summary>
        public static Специалист User3 { get; set; }
    }
}
