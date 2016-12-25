using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class GetOnlineUsers : System.Web.UI.Page
    {
        private List<string> GetUsers()
        {
            var db = new Database();
            return db.OnlineUsers.Select(user => user.Name).ToList();
        }

        private string GenerateJson()
        {
            var start = "{ \"users\": [";
            var users = GetUsers();
            foreach (var user in users)
                start += string.Format("\"{0}\", ", user);
            if (users.Any())
                start = start.Substring(0, start.Length - 2);
            start += "]}";
            return start;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var json = GenerateJson();
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
    }
}