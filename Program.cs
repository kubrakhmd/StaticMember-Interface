using Interface__StaticMember;


namespace Interface__StaticMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {


    
       
            
                // Create groups
                var group1 = new Group("Group BP216");
                var group2 = new Group("Group BP217");

                group1.AddStudent(new Student("Alice", "Smith"));
                group1.AddStudent(new Student("Bob", "Johnson"));
                group1.AddStudent(new Student("Charlie", "Brown"));
                group1.AddStudent(new Student("Diana", "King"));

                // Create students and add to Group B
                group2.AddStudent(new Student("Eve", "Davis"));
                group2.AddStudent(new Student("Frank", "Clark"));
                group2.AddStudent(new Student("Grace", "Lee"));
                group2.AddStudent(new Student("Hank", "Miller"));

                // Show all groups and their students
                Console.WriteLine("All Groups and Students:");
                Group.ShowAllGroups();
           
            }
        }
    }

        

      
    


