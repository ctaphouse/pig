using MediatR;
using pig.shared.features.ManageCourses.Shared;

namespace pig.shared.features.ManageCourses.AddCourse;

public record AddCourseRequest(CourseDto Course) : IRequest<AddCourseRequest.Response>
{
    public const string RouteTemplate = "/api/courses";
    
    public record Response(int CourseId);
}