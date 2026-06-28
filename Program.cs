
// using System.Runtime.Intrinsics.Arm;
// using Microsoft.VisualBasic;

// List<Student> students =
// [
// new Student { Id = "stu-01", studentName = "surafel Mengist", Email = "sura@gmail.com", Age = 34 },
//     new Student { Id = "stu-02", studentName = "Abel Yosef", Email = "Abel@gmail.com", Age = 23 },
//     new Student { Id = "stu-03", studentName = "Nahome yared", Email = "Nahome@gmail.com", Age = 14 },
//     new Student { Id = "stu-04", studentName = "Aster awoke", Email = "Aster@gmail.com", Age = 65 }
// ];


// // execute where, foreach, count, and other LINQ functions

// foreach (var stud in students)
// {
//     Console.WriteLine($"{stud.Id}, {stud.studentName}, {stud.Email}, {stud.Age}");
// }

// Console.WriteLine("=============");









// Console.WriteLine("=====forach======");
// foreach (var item in students)
// {
//     if (item.Age == 23)
//     {
//         Console.WriteLine($"You are {item.studentName} and you are {item.Age} Years old");
//     }
// }

// Console.WriteLine("========OrderByDescending=======");

// // orderbt asending
// var rank = students.OrderBy(s => s.GPA);
// System.Console.WriteLine(rank);



// var studentAges = students.Where(s => s.Age > 30);




// Minimal domain types required by this program
namespace TmsCore;

public class Student
{
    public required string Id { get; set; }
    public required string studentName { get; set; }
    public required string Email { get; set; }
    public int Age { get; set; }
    public decimal GPA { get; set; }
}

public class Course
{
    public required string Code { get; set; }
    public required string Title { get; set; }
    public int Capacity { get; set; }
    public int EnrolledCount { get; set; }
}

public class RegistrationResult
{
    public required string Student { get; set; }
    public required string Course { get; set; }
}

public class EnrollmentService
{
    public RegistrationResult ProcessRegistration(Student? student, Course course)
    {
        if (student == null) throw new ArgumentNullException(nameof(student));
        if (course == null) throw new ArgumentNullException(nameof(course));
        if (course.EnrolledCount >= course.Capacity) throw new InvalidOperationException("Course is full");

        // simulate enrollment
        course.EnrolledCount++;
        return new RegistrationResult { Student = student.Id ?? "N/A", Course = course.Code ?? "N/A" };
    }
}

public static class Program
{
    public static void Main()
    {
        var service = new EnrollmentService();

        // Test 1: Valid registration
        Student validStudent = new Student { Id = "S1", studentName = "Abeba", Email = "abeba@example.com", Age = 20, GPA = 3.8m };
        Course validCourse = new Course { Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
        RegistrationResult result = service.ProcessRegistration(validStudent, validCourse);

        // Print the returned values directly to avoid assuming they are complex objects.
        Console.WriteLine($"Enrolled: {result.Student ?? "N/A"} in {result.Course ?? "N/A"}");

        // Test 2: Null student should throw
        try
        {
            service.ProcessRegistration(null, validCourse);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Guard caught: {ex.ParamName}");
        }

        // Test 3: Full course should throw
        Course fullCourse = new Course { Code = "CS-402", Title = "Full Course", Capacity = 1 };
        fullCourse.EnrolledCount = 1;
        try
        {
            service.ProcessRegistration(validStudent, fullCourse);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Business rule: {ex.Message}");
        }
    }
}