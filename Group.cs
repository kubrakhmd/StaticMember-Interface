using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface__StaticMembers
{
    internal class Group
    {

        private static Group[] groups = new Group[4];
        private static int groupCount = 0;

        public int GroupId { get; private set; }
        public string GroupName { get; private set; }
        private Student[] groupStudents = new Student[4];
        private int studentCount = 0;

        public Group(string groupName)
        {
            GroupName = groupName;
            GroupId = ++groupCount;

           
            AddGroup(GroupName, GroupId);
        }

        private static void AddGroup(string groupName, int groupId)
        {
            if (groupCount >= groups.Length)
            {
                Array.Resize(ref groups, groups.Length + 2);
            }

            groups[groupCount - 1] = new Group(groupName) { GroupId = groupId };
        }
        public void RemoveStudent(int id)
        {
            for (int i = 0; i < studentCount; i++)
            {
                if (groupStudents[i]?.Id == id)
                {
                    
                    for (int j = i; j < studentCount - 1; j++)
                    {
                        groupStudents[j] = groupStudents[j + 1]; 
                    }

                    groupStudents[studentCount - 1] = null; 
                    studentCount--;
                    Console.WriteLine($"Student with ID {id} has been removed.");
                    return;
                }
            }

            Console.WriteLine($"Student with ID {id} not found in this group.");
        }

        public void AddStudent(Student student)
        {
            if (studentCount >= groupStudents.Length)
            {
                Array.Resize(ref groupStudents, groupStudents.Length + 2);
            }

            groupStudents[studentCount] = student;
            studentCount++;
        }

               public string GetGroupInfo()
        {
            string info = $"Group ID: {GroupId}, Group Name: {GroupName}, Student Count: {studentCount}\n";
            info += "Students:";

            for (int i = 0; i < studentCount; i++)
            {
                if (groupStudents[i] != null)
                {
                    info += $" - ID: {groupStudents[i].Id}, Name: {groupStudents[i].Name}, Surname: {groupStudents[i].Surname}";
                }
            }
            return info;
        }

        public static void ShowAllGroups()
        {
            foreach (var group in groups.Take(groupCount))
            {
                if (group != null)
                {
                    group.GetGroupInfo();
                }
            }
        }

        public static void RemoveGroup(int groupId)
        {
            for (int i = 0; i < groupCount; i++)
            {
                if (groups[i]?.GroupId == groupId)
                {
                    for (int j = i; j < groupCount - 1; j++)
                    {
                        groups[j] = groups[j + 1];
                    }

                    groups[groupCount - 1] = null;
                    groupCount--;
                    Console.WriteLine($"Group with ID {groupId} has been removed.");
                    return;
                }
            }

            Console.WriteLine($"Group with ID {groupId} not found.");
        }
    }
}
        
