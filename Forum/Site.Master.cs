using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class SiteMaster : MasterPage
    {
        public User User;
        public List<string> OnlineUsers = new List<string>();

        public bool IsUserLogined()
        {
            return User != null;
        }

        public bool IsUserAdmin()
        {
            return User != null && User.Group == "Admin";
        }

        public void Disconnect(object sender, EventArgs e)
        {
            var db = new Database();
            var user = db.OnlineUsers.First(u => u.Name == User.Name);
            db.OnlineUsers.Remove(user);
            db.SaveChanges();
            FormsAuthentication.SignOut();
            User = null;
            Response.Redirect(Request.RawUrl);
        }

        public void RemoveYourself(object sender, EventArgs e)
        {
            Response.Redirect("/Delete?user=" + User.Id);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                string name = ticket.Name;
                var database = new Database();
                User = (User)database.Users.First(user => user.Name == name).Clone();
                if (!database.OnlineUsers.Any(user => user.Name == name))
                {
                    database.OnlineUsers.Add(new OnlineUser(name));
                    database.SaveChanges();
                }
            }
            catch
            {
                User = null;
            }
        }
    }
}