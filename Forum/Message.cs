using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum
{
    public class Message
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public Message(int subjectId, int userId, string content, DateTime date)
        {
            SubjectId = subjectId;
            UserId = userId;
            Content = content;
            Date = date;
        }

        public Message()
        {

        }
    }
}