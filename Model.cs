public interface Model
{
      
}



public class Student {
    internal string? StudentName;

    public required string Id {get;set;}
      public required string StudentId{get;set;}
      public required string studentName {get;set;}
      public string? Email {get; set;}
      public int Age {get;set;}
      public decimal GPA {get; set;}
    public string? Name { get; internal set; }
    public int StudentAge { get; internal set; }
}






