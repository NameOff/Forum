using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum
{
    public class OnlineUser
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public OnlineUser(string name)
        {
            Name = name;
        }

        public OnlineUser()
        {
            
        }
    }
}