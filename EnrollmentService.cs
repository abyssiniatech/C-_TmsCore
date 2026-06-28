using System;

public class EnrollmentService
{
	public EnrollmentRecord ProcessRegistration(object? student, object? course)
	{
		// Guard clauses
		if (student is null) throw new ArgumentNullException(nameof(student));
		if (course is null) throw new ArgumentNullException(nameof(course));

		// Determine course capacity via reflection (Course shape may vary)
		var capacityProp = course.GetType().GetProperty("Capacity");
		if (capacityProp is null)
			throw new InvalidOperationException("Course capacity not found.");

		var capacityObj = capacityProp.GetValue(course);
		if (capacityObj is null || Convert.ToInt32(capacityObj) <= 0)
			throw new InvalidOperationException("Course has no available capacity.");

		// Classify academic standing using switch expression
		// Get GPA via reflection
		var gpaProp = student.GetType().GetProperty("GPA");
		if (gpaProp is null) throw new InvalidOperationException("Student GPA not found.");
		var gpaObj = gpaProp.GetValue(student);
		decimal gpa = gpaObj is null ? 0M : Convert.ToDecimal(gpaObj);

		string standing = gpa switch
		{
			>= 3.5M => "Honors",
			>= 2.5M => "Good Standing",
			_ => "Academic Warning"
		};

		// Obtain student name via reflection to avoid compile-time dependency on a specific Student shape
		var studentName = student.GetType().GetProperty("Name")?.GetValue(student)
			?? student.GetType().GetProperty("FullName")?.GetValue(student)
			?? student.GetType().GetProperty("Id")?.GetValue(student);
		Console.WriteLine($"{studentName} is in {standing}.");

		// Obtain course code via reflection to avoid compile-time dependency on a specific Course shape
		var code = course.GetType().GetProperty("Code")?.GetValue(course)
			   ?? throw new InvalidOperationException("Course code not found.");

		// Return enrollment record
		// Obtain student id via reflection
		var idProp = student.GetType().GetProperty("Id") ?? student.GetType().GetProperty("StudentId");
		if (idProp is null) throw new InvalidOperationException("Student id not found.");
		var idObj = idProp.GetValue(student)?.ToString() ?? throw new InvalidOperationException("Student id is null.");

		return new EnrollmentRecord(idObj, code, DateTime.UtcNow);
	}
}

public class EnrollmentRecord
{
    private string id;
    private object code;
    private DateTime utcNow;

    public EnrollmentRecord(string id, object code, DateTime utcNow)
    {
        this.id = id;
        this.code = code;
        this.utcNow = utcNow;
    }

    public string? Student { get; internal set; }
}