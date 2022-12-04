using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EmploymentCenter.Model;

namespace EmploymentCenter.Service
{
    internal static class Mail
    {
        // отправитель - устанавливаем адрес и отображаемое в письме имя
        private static MailAddress from = new MailAddress("свойМайл@mail.ru", "Центр занятости");
        

        public static void SendMail(string mail,Отклик response)
        {
            
            // кому отправляем
             MailAddress to = new MailAddress(mail);


            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject =  $"Вакансия - {response.Вакансия.Название}";
            // текст письма
            m.Body = "<h2>Здравствуйте, уважаемый ***!\r\n\r\nМеня зовут ***, я HR-менеджер компании «***».\r\n\r\n\r\nМы внимательно ознакомились с Вашим резюме (ссылка) и считаем, " +
                "что Ваши знания и опыт соответствуют нашим заявленным требованиям на открытую вакансию нашей компании «***».</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("свойМайл@mail.ru", "5iefef23gjefeeeRxKmkr8rT");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();
        }
    }
}
