using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using pig.api.persistence;
using pig.api.persistence.entities;
using pig.shared.features.ManageCourses.AddCourse;

namespace pig.api.features.ManageCourses.AddCourse;

public class AddCourseEndpoint : EndpointBaseAsync.WithRequest<AddCourseRequest>.WithActionResult<int>
{
    private readonly PigContext _context;

    public AddCourseEndpoint(PigContext context)
    {
        _context = context;
    }
    
    [HttpPost(AddCourseRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddCourseRequest request, CancellationToken cancellationToken = default)
    {
        var course = new Course
        {
            Name = request.Course.Name
        };

        await _context.AddAsync(course);

        var students = request.Course.Students.Select(s => new CourseStudent
        {
            StudentId = s.StudentId,
            Course = course
        });

        await _context.AddRangeAsync(students);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(course.Id);
    }
}