using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface__StaticMember;

 

  

namespace Interface__StaticMembers
{
    public class Student : ICodeAcademy
    {
        private static int count = 0;
        private static Student[] students = new Student[4]; 
        private static int studentCount = 0; 

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string CodeEmail { get; private set; }

        public Student(string name, string surname)
        {
            if (CheckName(name) && CheckName(surname))
            {
                count++;
                Id = count;
                Name = Capitalize(name);
                Surname = Capitalize(surname);
                GenerateEmail();

              
                AddStudent(new Student(Name, Surname)); 
            }
            else
            {
                Console.WriteLine($"Invalid name or surname: {name} {surname}. Student not created.");
            }
        }

        private static void AddStudent(Student student)
        {
            if (studentCount >= students.Length)
            {
                Array.Resize(ref students, students.Length + 2); // Massiv ölçüsünü artır
            }

            students[studentCount] = student;
            studentCount++;
        }

        public static bool CheckName(string name)
        {
            if (name.Length < 3 || name.Length > 25)
            {
                return false;
            }

            if (!name.All(char.IsLetter))
            {
                return false;
            }

            return true;
        }

        public static string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        public void GenerateEmail()
        {
            CodeEmail = $"{Name.ToLower()}.{Surname.ToLower()}{Id}@code.edu.az";
        }

        public static void ShowStudents()
        {
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i] != null) 
                {
                    Console.WriteLine($"ID: {students[i].Id}, Name: {students[i].Name}, Surname: {students[i].Surname}, Email: {students[i].CodeEmail}");
                }
            }
        }
    }
}
