using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Confirm : System.Web.UI.Page
    {
        public bool Confirmed()
        {
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var key = int.Parse(Request.QueryString["key"]);
                var db = new Database();
                var user = db.Users.ToList().First(a => a.Id == key);
                if (key == user.Id)
                {
                    user.Confirmed = true;
                    db.Users.AddOrUpdate(user);
                    db.SaveChanges();
                    FormsAuthentication.RedirectFromLoginPage(user.Name, false);
                }
            }
            catch
            {
                // ignored
            }
            Response.Redirect("Default.aspx");
        }
    }
}