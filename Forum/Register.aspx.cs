using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Name.Text = "Имя пользователя";
            Password.Text = "Пароль";
            CheckPassword.Text = "Повторите пароль";
            Submit.Text = "Регистрация";
            EmailText.Text = "Электронная почта";
        }

        private bool SendMessage(string email, int id)
        {
            try
            {
                var to = new MailAddress(email);
                var from = new MailAddress("smtp.client.test@mail.ru");
                var mail = new MailMessage(from, to)
                {
                    Subject = "Регистрация на форуме",
                    Body =
                        $"Для подтверждения регистрации пройдите по ссылке {"http://localhost:54655/Confirm?key="}{id}"
                };

                var smtp = new SmtpClient
                {
                    Host = "smtp.mail.ru",
                    Port = 587,
                    Credentials = new NetworkCredential("smtp.client.test@mail.ru", "smtp123"),
                    EnableSsl = true
                };

                smtp.Send(mail);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool IsEmailCorrect(string email)
        {
            return true;
        }

        protected void Submit_OnClick(object sender, EventArgs e)
        {
            var database = new Database();
            Result.ForeColor = System.Drawing.Color.Red;
            /*
            if (database.Users.Any(user => user.Email == Email.Text))
            {
                Result.Text = "На данный электронный ящик уже зарегистрирован пользователь";
                return;
            }
            */
            if (Login.Text.Length == 0)
            {
                Result.Text = "Имя пользователя не должно быть пустым";
                return;
            }
            if (database.Users.Any(user => user.Name == Login.Text))
            {
                Result.Text = "Такой пользователь уже существует.";
                return;
            }
            if (PasswordBox.Text.Length < 6)
            {
                Result.Text = "Пароль должен содержать как минимум 6 символов.";
                return;
            }
            if (PasswordBox.Text != PasswordBox2.Text)
            {
                Result.Text = "Пароли должны совпадать";
                return;
            }
            if (!Page.IsValid)
            {
                Result.Text = "Incorrect";
                return;
            }

            if (!IsEmailCorrect(Email.Text))
            {
                Result.Text = "Вы ввели неверную электронную почту";
                return;
            }

            database.Users.Add(new User(Login.Text, PasswordBox.Text, Email.Text, "Author", false));
            database.SaveChanges();
            var id = database.Users.ToList().First(user => user.Name == Login.Text).Id;
            SendMessage(Email.Text, id);
            Result.ForeColor = System.Drawing.Color.Black;
            Result.Text = "Подтвердите регистрацию на почте";
        }
    }
}