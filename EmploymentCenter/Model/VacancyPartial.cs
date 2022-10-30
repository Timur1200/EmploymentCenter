using EmploymentCenter.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCenter.Model
{
    partial class Вакансия
    {
        public string Date
        {
            get
            {
                return Дата.Value.ToString("d");
            }
        }
        public string Status
        {
            get
            {
                string status;
                if (Статус == null)
                {
                    status = "Отправлен на рассмотрение";
                }
                else if (Статус.Value)
                {
                    status = "Активен";
                }
                else
                {
                    status = "Приостановлен";
                }
                return status;
            }
        }

        public string Exp
        {
            get
            {
                if (Опыт.Value == 0) return "Без опыта работы";
                return $"Опыт работы {Опыт} {Helper.year(Опыт.Value)}";
            } 
        }

        public int Response
        {
            get
            {
               return EmploymentCenterEntities.GetContext().Отклик.Where(q => q.КодВакансии == this.Код && q.Статус != 2).Count();
            }
        }
    }
}
