using MediatR;
using pig.shared.features.ManageDepartments.Shared;

namespace pig.shared.features.ManageDepartments.AddDepartment;

public record AddDepartmentRequest(DepartmentDto Department) : IRequest<AddDepartmentRequest.Response>
{
    public const string RouteTemplate = "/api/departments";
    public record Response(int DepartmentId);
}