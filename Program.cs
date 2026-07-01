// using System;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using TmsCore;


// var sw = Stopwatch.StartNew();
// for (int i = 0; i < 5; i++)
// {
//     Thread.Sleep(300);
// }

// Console.WriteLine($"Blocking Sequtial:{sw.ElapsedMilliseconds}ElapsedMilliseconds");

// sw.Restart();


// //    
// for (int i = 0; i < 5; i++)
// {
//     await Task.Delay(300);
// }
// Console.WriteLine($"Async sequtial : {sw.ElapsedMilliseconds} ms");


// sw.Restart();
// var tasks = Enumerable.Range(0, 5).Select(_ => Task.Delay(300));
// await Task.WhenAll(tasks);
// Console.WriteLine($"Async Parallel: {sw.ElapsedMilliseconds} ms");

// sw.Restart();
// var student = await FetchStudentAsync("S1");
// Console.WriteLine($"Fetched student: {student.Id}, GPA: {student.GPA}");




// //   the second example 
// static async Task<Student> FetchStudentAsync(string id)
// {
//     Console.WriteLine($" Fetching {id}...");
//     await Task.Delay(300); // Simulate database latency
//     return new Student
//     {
//         StudentId = $"{id}",
//         Id = $"{id}",
//         studentName = $"Student-{id}",
//         StudentName = $"Student-{id}",
//         Age = 20,
//         GPA = id switch
//         {
//             "S1" => 3.8m,
//             "S2" => 2.4m,
//             "S3" => 3.5m,
//             "S4" => 1.9m,
//             "S5" => 3.2m,
//             _ => 2.5m
//         }
//     };
// }

// static async Task<Course> FetchCourseAsync(string code)
// {
//     Console.WriteLine($" Fetching {code}...");
//     await Task.Delay(300); // Simulate database latency
//     return new Course
//     {
//         Code = code,
//         StudentId = "S1",
//         Title = $"Course-{code}",
//         Capacity = 30
//     };
// }

// // the third method

// sw.Restart();
// // Start all fetches simultaneously students AND courses
// string[] studentIds = ["S1", "S2", "S3", "S4", "S5"];
// string[] courseCodes = ["CRS-101", "CRS-201", "CRS-301"];
// var studentTasks = studentIds.Select(id => FetchStudentAsync(id));
// var courseTasks = courseCodes.Select(code => FetchCourseAsync(code));
// // Both arrays load concurrently
// Student[] students = await Task.WhenAll(studentTasks);
// Course[] courses = await Task.WhenAll(courseTasks);
// Console.WriteLine($"\nLoaded {students.Length} students and {courses.Length} courses in {sw.ElapsedMilliseconds}ms");
// foreach (var s in students)
// {
//     Console.WriteLine($" {s.StudentName} GPA: {s.GPA}");
// }

// // Simple model classes used by the sample methods
// namespace TmsCore
// {
//     class Course
//     {
//         public required string Code { get; set; }
//         public required string StudentId { get; set; }
//         public required string Title { get; set; }
//         public int Capacity { get; set; }
//     }

//     public class Student
//     {
//         // Required members expected by other code
//         public required string StudentId { get; set; }
//         public required string studentName { get; set; }

//         // Legacy/alternate accessors
//         public string Id
//         {
//             get => StudentId;
//             set => StudentId = value;
//         }

//         public string StudentName
//         {
//             get => studentName;
//             set => studentName = value;
//         }

//         public int Age { get; set; }
//         // Renamed to avoid ambiguity with other 'Age' symbols in scope
//         public int StudentAge { get; set; }
//         public decimal GPA { get; set; }
//     }
// }

























namespace TmsCore
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Example invocation of the calculation methods
            int a = await Task.Run(() => Calculate1());
            int b = await Task.Run(() => Calculate2());
            int c = await Task.Run(() => Calculate3());

            Console.WriteLine($"Results: {a}, {b}, {c}");
        }

        public static int Calculate1()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Calculate one");
            return 100;
        }

        public static int Calculate2()
        {
            // ensure the delay actually runs
            Thread.Sleep(3000);
            Console.WriteLine("Calculate two");
            return 200;
        }

        public static int Calculate3()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Calculate three");
            return 50;
        }
    }
}