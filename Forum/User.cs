using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Forum
{
    public class User : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Group { get; set; }
        public bool Confirmed { get; set; }

        public string EncodePassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var textToHash = Encoding.Default.GetBytes(password);
            var result = md5.ComputeHash(textToHash);
            return BitConverter.ToString(result).Replace("-", "");
        }



        public User(string name, string password, string email, string group, bool confirmed)
        {
            Name = name;
            Password = EncodePassword(password);
            Email = email;
            Group = group;
            Confirmed = confirmed;
        }

        public User()
        {

        }

        public object Clone()
        {
            var user = new User(Name, Password, Email, Group, Confirmed);
            user.Id = Id;
            return user;
        }
    }
}