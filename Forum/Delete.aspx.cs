using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Delete : System.Web.UI.Page
    {
        public User User;

        public bool IsUserLogined()
        {
            return User != null;
        }

        public bool IsUserAdmin()
        {
            return User != null && User.Group == "Admin";
        }

        private bool IsToken(string token)
        {
            return Request.QueryString[token] != null;
        }

        private void RemoveUser(int id)
        {
            var db = new Database();
            foreach (var message in db.Messages.Where(msg => msg.UserId == id))
                RemoveMessage(message.Id);
            var user = db.Users.First(u => u.Id == id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        private void RemoveSubject(int id)
        {
            var db = new Database();
            foreach (var message in db.Messages.Where(msg => msg.SubjectId == id))
                RemoveMessage(message.Id);
            var subject = db.Subjects.First(subj => subj.Id == id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
        }

        private void RemoveSection(int id)
        {
            var db = new Database();
            var subjects = db.Subjects.Where(subj => subj.SectionId == id);
            foreach (var subject in subjects)
                RemoveSubject(subject.Id);
            var section = db.Sections.First(sect => sect.Id == id);
            db.Sections.Remove(section);
            db.SaveChanges();
        }

        private void RemoveMessage(int id)
        {
            var db = new Database();
            var message = db.Messages.First(msg => msg.Id == id);
            db.Messages.Remove(message);
            db.SaveChanges();
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
            string token = "";
            var tokens = new[] { "subject", "user", "section", "message" };
            foreach (var s in tokens)
            {
                if (IsToken(s))
                {
                    token = s;
                    break;
                }
            }
            if (token == "")
            {
                Response.Redirect("Default.aspx");
                return;
            }
            var id = int.Parse(Request.QueryString[token]);
            switch (token)
            {
                case "subject":
                    var db = new Database();
                    var subj = db.Subjects.First(s => s.Id == id);
                    var section = db.Sections.First(sect => sect.Id == subj.SectionId);
                    RemoveSubject(id);
                    Response.Redirect("/Section?section=" + section.Id);
                    break;
                case "user":
                    RemoveUser(id);
                    Response.Redirect(Request.UrlReferrer.AbsoluteUri);
                    break;
                case "section":
                    RemoveSection(id);
                    Response.Redirect("Default.aspx");
                    break;
                case "message":
                    RemoveMessage(id);
                    Response.Redirect(Request.UrlReferrer.AbsoluteUri);
                    break;
            }
        }
    }
}