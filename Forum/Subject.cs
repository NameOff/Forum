using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum
{
    public class Subject
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Name { get; set; }

        public Subject(int sectionId, string name)
        {
            SectionId = sectionId;
            Name = name;
        }

        public Subject()
        {

        }
    }
}