using System;
using System.Collections.Generic;

namespace ConsoleApp10
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public int Age;

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }

    public class School
    {
        public string Name;
        public List<Student> Students;

        public School(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public void PrintStudents()
        {
            if (Students.Count == 0)
                Console.WriteLine($"В школе {Name} нет учеников");
            else
            {
                Console.WriteLine("{0, -2} {1, -10} {2, -10} {3, -2}", "ID", "Имя", "Фамилия", "Возраст");
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine("{0, -2} {1, -10} {2, -10} {3, -2}", i + ".", Students[i].FirstName, Students[i].LastName, Students[i].Age);
                }
            }
        }

        public void AddNewStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine($"Студент {student.FirstName} {student.LastName} успешно добавлен в школу {Name}.");
        }

        internal void RemoveStudent(int choiseUser)
        {
            Console.WriteLine($"Студент {Students[choiseUser].FirstName} {Students[choiseUser].LastName} был удален.");
            Students.RemoveAt(choiseUser);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите название вашей школы");
            string schoolName = Console.ReadLine();
            School school = new School(schoolName);
            Console.WriteLine($"Школа {school.Name} успешна создана");

            while(true)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine($"1. Просмотр списка учеников школы {school.Name}. ");
                Console.WriteLine($"2. Добавление нового ученика в список учащихся школы {school.Name}.");
                Console.WriteLine($"3. Удаление ученика из списка учащихся школы {school.Name}.");
                int choiseUser = int.Parse(Console.ReadLine());

                if(choiseUser != 1 && choiseUser != 2 && choiseUser != 3)
                {
                    Console.WriteLine("Некорректный ввод символа! Напишите число от 1 до 3.");
                    continue;
                }
                else if(choiseUser == 1)
                {
                    school.PrintStudents();
                }
                else if(choiseUser == 2)
                {
                    Console.WriteLine("Введите имя ученика");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Введите фамилию ученика");
                    string lastName = Console.ReadLine();
                    bool isTrue;
                    int age = 0;
                    do
                    {
                        Console.WriteLine("Введите возраст ученика");
                        isTrue = int.TryParse(Console.ReadLine(), out age);
                        if (!isTrue)
                            Console.WriteLine("Введите число!");
                    }
                    while (!isTrue);

                    Student student = new Student(firstName, lastName, age);
                    school.AddNewStudent(student);
                }
                else if(choiseUser == 3)
                {
                    school.PrintStudents();
                    bool isTrue;

                    do
                    {
                        Console.WriteLine("Выберите ID ученика, которого хотите удалить");
                        isTrue = int.TryParse(Console.ReadLine(), out choiseUser);
                        if (!isTrue || choiseUser >= school.Students.Count || choiseUser < 0)
                            Console.WriteLine("Введите корректное число!");
                        else
                            school.RemoveStudent(choiseUser);
                    }
                    while (!isTrue);
                    
                }

            }

        }

    }

}
