using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCenter.Model
{
    partial class Отклик
    {
        public string Status
        {
            get
            {
                return ((StatusResponseEnum)Статус).ToString();
            }
        }
    }
}
