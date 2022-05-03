using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using pig.api.persistence;
using pig.api.persistence.entities;
using pig.shared.features.ManageDepartments.AddDepartment;

namespace pig.api.features.ManageDepartments.AddDepartment;

public class AddDepartmentEndpoint : EndpointBaseAsync.WithRequest<AddDepartmentRequest>.WithActionResult<int>
{
    private readonly PigContext _context;

    public AddDepartmentEndpoint(PigContext context)
    {
        _context = context;
    }
    [HttpPost(AddDepartmentRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddDepartmentRequest request, CancellationToken cancellationToken = default)
    {
        var department = new Department
        {
            Name = request.Department.Name
        };

        await _context.AddAsync(department);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(department.Id);
    }
}
