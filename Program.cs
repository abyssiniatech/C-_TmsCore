// string? region=null;

// string? upperRegion = region?.ToUpper();
// Console.WriteLine($"Region (conditional): {upperRegion}");


// string? upperRegions = region?.ToUpper();
// Console.WriteLine($"Region (conditional): {upperRegions}");



// string? region1="Addis ababa";
// region1.ToUpper();
// Console.WriteLine($"my region is= {region1}");


// // datatypes in c# basic 
// int age=12;
// string FullName="Surafel mengist";
// decimal tem=16.7m;
// decimal money =23.5m;
// DateTime date=DateTime.Now;
// System.Console.WriteLine($"my name is {FullName} and i'm {age} years old and i have {money} and the weather condition for addis ababa is {tem} and today is :{date}");



// Legacy implementation — the bug that caused the audit failure
// double grantPerStudent = 1999.99;
// double totalAllocation = grantPerStudent * 100_000;
// Console.WriteLine($"Total allocated (double): {totalAllocation}");


// // Fixed implementation — exact financial math
// decimal grantPerStudents = 1999.99m;
// decimal totalAllocations = grantPerStudents * 100_000m;
// Console.WriteLine($"Total allocated (decimal): {totalAllocation}");
// Console.WriteLine($"Total allocated (formatted): {totalAllocation:F2}");





// record in c# 


     var enrollment = new EnrollmentRecord("STU-001", "CS-401", DateTime.UtcNow);
    Console.WriteLine(enrollment);

   var corrected = enrollment with { CourseCode = "CS-402" };
    Console.WriteLine(corrected);

    // student record in c#
    var studentInfo = new StudentRecord(12,"surafel Mengist",DateTime.Now);
    Console.WriteLine(studentInfo);





    var course = new Course { Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");
// Invalid capacity — should throw
try
{
course.Capacity = -5;
}
catch (ArgumentOutOfRangeException ex)
{
Console.WriteLine($"Caught: {ex.Message}");
}
// Invalid title — should throw
try
{
course.Title = "";
}
catch (ArgumentException ex)
{
Console.WriteLine($"Caught: {ex.Message}");
// these is the best are youbready to learn these journy tebgdtrebdhd
}




// student model
// var s = new Student { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m };
// Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
// These should throw — try each one:
var students = new List<Student>
{
    new Student { Id = "S2", Name = "", Age = 20, GPA = 3.0m },
    new Student { Id = "S3", Name = "Test", Age = 12, GPA = 3.0m },
    new Student { Id = "S4", Name = "Test", Age = 18, GPA = 3.8m }
};

// run and execute the Student List
students.ForEach(s => Console.WriteLine($"Student Information:StudentName = {s.Name},Age: {s.Age}, GPA: {s.GPA}"));