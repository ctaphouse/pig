namespace pig.shared.features.ManageCourses.Shared;

public class CourseDto
{
    public string Name { get; set; } = default!;
    public ICollection<Student> Students { get; set; } = new List<Student>();

    public class Student
    {
        public int StudentId { get; set; }
    }
}