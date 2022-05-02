using MediatR;
using pig.shared.features.ManageStudents.Shared;

namespace pig.shared.features.ManageStudents.AddStudent;

public record AddStudentRequest(StudentDto Student) : IRequest<AddStudentRequest.Response>
{
    public const string RouteTemplate = "/api/students";
    public record Response(int StudentId);
}

