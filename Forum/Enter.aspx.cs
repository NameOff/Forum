using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Enter : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Name.Text = "Имя пользователя";
            Password.Text = "Пароль";
            Submit.Text = "Вход";
        }

        protected void Submit_OnClick(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.Users.ToList().Any(user => user.Confirmed && user.Name == Login.Text && user.Password == user.EncodePassword(PasswordBox.Text)))
            {
                FormsAuthentication.RedirectFromLoginPage(Login.Text, false);
                Response.Redirect("Default.aspx");
            }
            else
            {
                Result.Text = "Неверное имя пользователя или пароль";
            }
        }
    }
}