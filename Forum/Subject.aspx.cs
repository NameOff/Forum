using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Subject1 : System.Web.UI.Page
    {
        public List<Message> GetAllMessagesOfSubject(int id)
        {
            return new Database().Messages.Where(message => message.SubjectId == id).ToList();
        }

        public string GetSubjectName(int id)
        {
            return new Database().Subjects.First(subject => subject.Id == id).Name;
        }

        public int GetSubjectId()
        {
            try
            {
                var key = int.Parse(Request.QueryString["subject"]);
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
                User =  (User)database.Users.First(user => user.Name == name).Clone();
            }
            catch
            {
                User = null;
            }
        }

        public string GetUserName(int messageId)
        {
            var db = new Database();
            var id = db.Messages.First(msg => msg.Id == messageId).UserId;

            return db.Users.First(user => user.Id == id).Name;
        }

        public DateTime GetTime(int messageId)
        {
            var db = new Database();
            return db.Messages.First(msg => msg.Id == messageId).Date;
        }

        protected void OnClick(object sender, EventArgs e)
        {
            if (MessageText.Text.Length == 0)
                return;
            var db = new Database();
            var subject = db.Subjects.ToList().First(subj => subj.Id == GetSubjectId());
            var msg = new Message(subject.Id, User.Id, MessageText.Text, DateTime.Now);

            db.Messages.Add(msg);
            db.SaveChanges();
            MessageText.Text = "";
        }
    }
}