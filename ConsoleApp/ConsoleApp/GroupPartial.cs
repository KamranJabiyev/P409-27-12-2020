using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    partial class Group
    {
        public override string ToString()
        {
            return $"{Id}-{Name}";
        }

        public void AddStudent(Student st)
        {
            if (students.Length < MaxCount)
            {
                Array.Resize(ref students, students.Length + 1);
                students[students.Length - 1] = st;
                Helper.Alert(ConsoleColor.Green, $"{Name} qrupuna {st.Name} adli telebe elave edildi!!!");
                return;
            }
            Helper.Alert(ConsoleColor.Red, $"{Name} qrupu artiq doludur!!!");
        }

        public void ShowAllStudent()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (Student stu in students)
            {
                Console.WriteLine(stu);
            }
            Console.ResetColor();
        }

        public void FindStudent(string name)
        {
            int count = 0;
            foreach (Student stu in students)
            {
                if (stu.Name.ToLower() == name.ToLower())
                {
                    Helper.Alert(ConsoleColor.Blue, stu.ToString());
                    count++;
                } 
            }
            if (count == 0)
            {
                Helper.Alert(ConsoleColor.Red, $"{name} adda telebe {Name} qrupunda yoxdur");
            }
        }
    }
}
