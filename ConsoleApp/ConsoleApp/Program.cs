using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[0];
            while (true)
            {
                Helper.Alert(ConsoleColor.Green, "Qrup elave edin-1;  Telebe elave edin-2;  Telebe siyahisi-3;" +
                "  Ada gore axtarish-4;  Proqramdan chixish-istenilen eded yazin: ");
                string res = Console.ReadLine();
                int menu;
                bool menuConvert = int.TryParse(res, out menu);
                if (menuConvert)
                {
                    if (menu > 4)
                    {
                        Helper.Alert(ConsoleColor.White, "Teshekkurler");
                        break;
                    }
                    switch (menu)
                    {
                        case (int)Menu.CreateGroup:
                            Helper.Alert(ConsoleColor.Gray, "Qrup adi daxil edin ve ya 'geri' yazaraq menuya qayidin:");
                            string groupName = Console.ReadLine();
                            if (groupName.ToLower() == "geri")
                            {
                                break;
                            }

                            bool hasGroup = false;
                            foreach (Group gr in groups)
                            {
                                if(gr.Name.ToLower()== groupName.ToLower())
                                {
                                    Helper.Alert(ConsoleColor.Red, $"{groupName} adli qrup movcuddur");
                                    hasGroup = true;
                                    break;
                                }
                            }
                            if (hasGroup) break;

                            Helper.Alert(ConsoleColor.Gray, "Qrupda maksimum telebe sayi daxil edin:");
                            int maxCount;
                            bool isNumber = int.TryParse(Console.ReadLine(), out maxCount);
                            if (isNumber)
                            {
                                Group group = new Group(groupName, maxCount);
                                Array.Resize(ref groups, groups.Length + 1);
                                groups[groups.Length - 1] = group;
                                Helper.Alert(ConsoleColor.Green, "Yeni qrup yaradildi");
                                break;
                            }
                            Helper.Alert(ConsoleColor.Red, "Eded daxil etmeliydiniz!!!");
                            break;
                        case (int)Menu.CreateStudent:
                            Helper.Alert(ConsoleColor.Gray, "Telebe adi daxil edin ve ya 'geri' yazaraq menuya qayidin:");
                            string name = Console.ReadLine();
                            if (name.ToLower() == "geri") break;
                            Helper.Alert(ConsoleColor.Gray, "Telebenin soyadini daxil edin:");
                            string surname = Console.ReadLine();

                            Helper.Alert(ConsoleColor.Cyan, "Movcud qruplarimiz:");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            foreach (Group gr in groups)
                            {
                                Console.WriteLine(gr);
                            }
                            Helper.Alert(ConsoleColor.Yellow, "Telebeni elave edeceyiniz qrupu sechin:");
                            string groupStr = Console.ReadLine().Trim(); 
                            bool HasGroup = false;
                            foreach (Group gr in groups)
                            {
                                if (gr.Name.ToLower() == groupStr.ToLower()&&!String.IsNullOrEmpty(groupStr))
                                {
                                    Student student = new Student(name, surname);
                                    gr.AddStudent(student);
                                    HasGroup = true;
                                    break;
                                }
                            }
                            if (!HasGroup)
                            {
                                Helper.Alert(ConsoleColor.Red, "Duzgun qrup sechmediniz!!!");
                            }
                            break;
                        case (int)Menu.StudentList:
                            Helper.Alert(ConsoleColor.Cyan, "Qruplarimiz ve Telebelerimiz:");
                            foreach (Group gr in groups)
                            {
                                Helper.Alert(ConsoleColor.DarkMagenta, $"{gr}");
                                gr.ShowAllStudent();
                            }
                            break;
                        default:
                            Helper.Alert(ConsoleColor.White, "Axtardiginiz Telebe Adini daxil edin:");
                            string searchName = Console.ReadLine().Trim();
                            Helper.Alert(ConsoleColor.Cyan, "Movcud qruplarimiz:");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            foreach (Group gr in groups)
                            {
                                Console.WriteLine(gr);
                            }

                            Helper.Alert(ConsoleColor.Yellow, "Telebeni axtardiginiz qrupu sechin:");
                            string groupNameStr = Console.ReadLine().Trim();
                            bool HasGroupSearch = false;
                            foreach (Group gr in groups)
                            {
                                if (gr.Name.ToLower() == groupNameStr.ToLower() && !String.IsNullOrEmpty(groupNameStr))
                                {
                                    gr.FindStudent(searchName);
                                    HasGroupSearch = true;
                                    break;
                                }
                            }
                            if (!HasGroupSearch)
                            {
                                Helper.Alert(ConsoleColor.Red, "Duzgun qrup sechmediniz!!!");
                            }
                            break;
                    }
                }
                else
                {
                    Helper.Alert(ConsoleColor.Red, "Dogru eded daxil edin!!!");
                }
            }
        }
    }
}
