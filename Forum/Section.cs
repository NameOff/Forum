using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Section(string name)
        {
            Name = name;
        }

        public Section()
        {

        }
    }
}