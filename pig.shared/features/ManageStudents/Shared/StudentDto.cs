namespace pig.shared.features.ManageStudents.Shared;

public class StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int DepartmentId { get; set; }
    public ICollection<CourseStudent> CourseStudent { get; set; } = new List<CourseStudent>();    
}

public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }

    public class CourseStudent
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }