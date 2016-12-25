using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Section1 : System.Web.UI.Page
    {
        public List<Subject> GetAllSubjectsOfSection(int id)
        {
            return new Database().Subjects.Where(subject => subject.SectionId == id).ToList();
        }

        public int GetSectionId()
        {
            try
            {
                var key = int.Parse(Request.QueryString["section"]);
                return key;
            }
            catch
            {
                Response.Redirect("Default.aspx");
                return 0;
            }
        }

        public User User;

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
            if (SubjectName.Text.Length == 0)
                return;
            var db = new Database();
            var section = db.Sections.ToList().First(sect => sect.Id == GetSectionId());

            db.Subjects.Add(new Subject(section.Id, SubjectName.Text));
            db.SaveChanges();
            SubjectName.Text = "";
        }
    }
}