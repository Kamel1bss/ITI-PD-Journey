using AutoMapper;
using Day01.Contracts.Requests;
using Day01.Contracts.Responses;
using Day01.Models;
using Day01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day01.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController(IDepartmentService departmentService, IMapper mapper) : ControllerBase
{
    private readonly IDepartmentService _departmentService = departmentService;
    private readonly IMapper _mapper = mapper;

    [HttpGet("")]
    public async Task<IActionResult> GetAllDepartments(CancellationToken cancellationToken)
    {
        var departments = await _departmentService.GetAllDepartmentsAsync(cancellationToken);
        var departmentResponses = _mapper.Map<IEnumerable<DepartmentResponse>>(departments);
        return Ok(departmentResponses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartmentById(int id, CancellationToken cancellationToken)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id, cancellationToken);
        if (department == null)
        {
            return NotFound();
        }
        var departmentResponse = _mapper.Map<DepartmentResponse>(department);
        return Ok(departmentResponse);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddDepartment(DepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = _mapper.Map<Department>(request);
        var addedDepartment = await _departmentService.AddDepartmentAsync(department, cancellationToken);
        var departmentResponse = _mapper.Map<DepartmentResponse>(addedDepartment);
        return CreatedAtAction(nameof(GetDepartmentById), new { id = departmentResponse.DeptId }, departmentResponse);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartment(int id, DepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = _mapper.Map<Department>(request);
        department.DeptId = id;
        var isUpdated = await _departmentService.UpdateDepartmentAsync(id, department, cancellationToken);
        return isUpdated ? NoContent() : NotFound();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id, CancellationToken cancellationToken)
    {
        var isDeleted = await _departmentService.DeleteDepartmentAsync(id, cancellationToken);
        return isDeleted ? NoContent() : NotFound();

    }


}
