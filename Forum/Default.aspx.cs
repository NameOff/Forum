using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class _Default : Page
    {
        public List<Section> GetAllSections()
        {
            return new Database().Sections.ToList();
        }

        public User User;
        public int SectionIdToDelete;

        public bool IsUserLogined()
        {
            return User != null;
        }

        public bool IsUserAdmin()
        {
            return User != null && User.Group == "Admin";
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
            }
            catch
            {
                User = null;
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            if (IsUserAdmin() && SectionName.Text.Length != 0)
            {
                var db = new Database();
                db.Sections.Add(new Section(SectionName.Text));
                db.SaveChanges();
            }
        }
    }
}