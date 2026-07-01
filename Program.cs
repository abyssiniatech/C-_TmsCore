namespace Students
{
    public class Program
    {
        public static void Main(string[] args)
        {

            List<Student> students = new List<Student>
            {
                new Student {
                 Id = 1,
                Name = "Alice",
                Age = 20,
                Email = "alice@example.com" },

                new Student {
                    Id = 2,
                    Name = "Bob",
                    Age = 22,
                    Email = "bob@example.com"
                      },
                new Student {
                 Id = 3,
                 Name = "Charlie",
                 Age = 19,
                Email = "charlie@example.com"
                 },
                new Student {
                    Id = 4,
                    Name = "David",
                     Age = 21,
                    Email = "David@gmail.com" }
            };

  
        //   excute by using linq query
        
            var query = from student in students
                        where student.Age > 20
                        orderby student.Name
                        select student;

            Console.WriteLine("Students older than 20:");
            foreach (var student in query)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, Email: {student.Email}");
            }
            // for each loop to display all students
            var studentList = students.Where(s => s.Age > 20).OrderBy(s => s.Name).ToList();
          Console.WriteLine("All students older than 20:");
            foreach (var student in studentList)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, Email: {student.Email}");
            }

            // where and orderby method syntax
            Console.WriteLine("All students older than 20:");
            studentList = students.Where(s => s.Age > 20).OrderBy(s => s.Name).ToList();



            foreach(var student in studentList){
                
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, Email: {student.Email}");
            }


            string[] backend =["Next js","PHP","Node js","Python","Java"];
            string[] frontend = ["React js","Angular","Vue js","Svelte","Ember js"];
           Console.WriteLine(string.Join(", ", backend));
           Console.WriteLine(string.Join(", ", frontend));

            string[] allTechnologies = backend.Concat(frontend).ToArray();
            Console.WriteLine("All Technologies:");
            foreach (var tech in allTechnologies)
            {
                Console.WriteLine(tech);
            }
            //  dictionary to store student data
            Dictionary<int, Student> studentDictionary = new Dictionary<int, Student>();
            foreach (var student in students)
            {
                studentDictionary.Add(student.Id, student);
            }
        }
    }
    }