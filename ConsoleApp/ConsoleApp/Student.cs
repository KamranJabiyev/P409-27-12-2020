using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public readonly int Id;
        private static int count = 0;
        public Student()
        {
            count++;
            Id = count;
        }
        public Student(string name,string surname):this()
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"{Id}-{Name} {Surname}";
        }
    }
}
