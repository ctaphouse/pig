using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using pig.api.persistence;
using pig.api.persistence.entities;
using pig.shared.features.ManageStudents.AddStudent;

namespace pig.api.features.ManageStudents.AddStudent;

public class AddStudentEndpoint : EndpointBaseAsync.WithRequest<AddStudentRequest>.WithActionResult<AddStudentRequest.Response>
{
    private readonly PigContext _context;

    public AddStudentEndpoint(PigContext context)
    {
        _context = context;
    }

    [HttpPost(AddStudentRequest.RouteTemplate)]
    public override async Task<ActionResult<AddStudentRequest.Response>> HandleAsync(AddStudentRequest request, CancellationToken cancellationToken = default)
    {
        var student = new Student
        {
            Id = request.Student.Id,
            FirstName = request.Student.FirstName,
            LastName = request.Student.LastName,
            DepartmentId = request.Student.DepartmentId,            
        };

        await _context.AddAsync(student);

        var courseStudents = request.Student.CourseStudent.Select(j => new CourseStudent
        {
            CourseId = j.CourseId,
            Student = student
        });

        await _context.AddRangeAsync(courseStudents);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(student.Id);
    }
}
