using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    partial class Group
    {
        public string Name { get; set; }
        public int MaxCount { get; set; }

        private Student[] students;
        public readonly int Id;
        private static int count = 0;
        public Group()
        {
            count++;
            Id = count;
            students = new Student[0];
        }

        public Group(string groupname,int maxcount):this()
        {
            Name = groupname;
            MaxCount = maxcount;
        }
    }
}
