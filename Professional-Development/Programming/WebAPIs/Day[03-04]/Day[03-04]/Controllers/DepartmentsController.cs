using AutoMapper;
using Day01.Contracts.Requests;
using Day01.Contracts.Responses;
using Day01.Models;
using Day01.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day01.Controllers;

[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
[ApiController]
public class DepartmentsController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    [HttpGet("")]
    public async Task<IActionResult> GetAllDepartments(CancellationToken cancellationToken)
    {
        var departments = await _unitOfWork.Departments.GetAllAsync(cancellationToken);
        var departmentResponses = _mapper.Map<IEnumerable<DepartmentResponse>>(departments);
        return Ok(departmentResponses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartmentById(int id, CancellationToken cancellationToken)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id, cancellationToken);
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
        var addedDepartment = await _unitOfWork.Departments.AddAsync(department, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
        var departmentResponse = _mapper.Map<DepartmentResponse>(addedDepartment);
        return CreatedAtAction(nameof(GetDepartmentById), new { id = departmentResponse.DeptId }, departmentResponse);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartment(int id, DepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = _mapper.Map<Department>(request);
        department.DeptId = id;
        var isUpdated = await _unitOfWork.Departments.UpdateAsync(id, department, cancellationToken);
        if (isUpdated)
        {
            await _unitOfWork.SaveAsync(cancellationToken);
        }
        return isUpdated ? NoContent() : NotFound();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id, CancellationToken cancellationToken)
    {
        var isDeleted = await _unitOfWork.Departments.DeleteAsync(id, cancellationToken);
        if (isDeleted)
        {
            await _unitOfWork.SaveAsync(cancellationToken);
        }
        return isDeleted ? NoContent() : NotFound();

    }


}
