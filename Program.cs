using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TmsCore;


var sw = Stopwatch.StartNew();
for (int i = 0; i < 5; i++)
{
    Thread.Sleep(300);
}

Console.WriteLine($"Blocking Sequtial:{sw.ElapsedMilliseconds}ElapsedMilliseconds");

sw.Restart();


//    
for (int i = 0; i < 5; i++)
{
    await Task.Delay(300);
}
Console.WriteLine($"Async sequtial : {sw.ElapsedMilliseconds} ms");


sw.Restart();
var tasks = Enumerable.Range(0, 5).Select(_ => Task.Delay(300));
await Task.WhenAll(tasks);
Console.WriteLine($"Async Parallel: {sw.ElapsedMilliseconds} ms");

sw.Restart();
var student = await FetchStudentAsync("S1");
Console.WriteLine($"Fetched student: {student.Id}, GPA: {student.GPA}");




//   the second example 
static async Task<Student> FetchStudentAsync(string id)
{
    Console.WriteLine($" Fetching {id}...");
    await Task.Delay(300); // Simulate database latency
    return new Student
    {
        StudentId = $"{id}",
        Id = $"{id}",
        studentName = $"Student-{id}",
        StudentName = $"Student-{id}",
        Age = 20,
        GPA = id switch
        {
            "S1" => 3.8m,
            "S2" => 2.4m,
            "S3" => 3.5m,
            "S4" => 1.9m,
            "S5" => 3.2m,
            _ => 2.5m
        }
    };
}

// Simple model classes used by the sample methods
namespace TmsCore
{
    class Course
    {
        public required string Code { get; set; }
        public required string StudentId { get; set; }
        public required string Title { get; set; }
        public int Capacity { get; set; }
    }

    public class Student
    {
        // Required members expected by other code
        public required string StudentId { get; set; }
        public required string studentName { get; set; }

        // Legacy/alternate accessors
        public string Id
        {
            get => StudentId;
            set => StudentId = value;
        }

        public string StudentName
        {
            get => studentName;
            set => studentName = value;
        }

        public int Age { get; set; }
        // Renamed to avoid ambiguity with other 'Age' symbols in scope
        public int StudentAge { get; set; }
        public decimal GPA { get; set; }
    }
}