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
[Authorize]
[ApiController]
public class StudentsController(IStudentRepo studentRepo, IMapper mapper) : ControllerBase
{
    private readonly IStudentRepo _studentRepo = studentRepo;
    private readonly IMapper _mapper = mapper;

    [HttpGet("all")]
    public async Task<IActionResult> GetAllStudents(CancellationToken cancellationToken)
    {
        var students = await _studentRepo.UnitOfWork.Students.GetAllAsync(cancellationToken);
        var studentResponses = _mapper.Map<IEnumerable<StudentResponse>>(students);
        return Ok(studentResponses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(int id, CancellationToken cancellationToken)
    {
        var student = await _studentRepo.UnitOfWork.Students.GetByIdAsync(id, cancellationToken);
        if (student == null)
        {
            return NotFound();
        }
        var studentResponse = _mapper.Map<StudentResponse>(student);
        return Ok(studentResponse);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddStudent(StudentRequest request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<Student>(request);
        var addedStudent = await _studentRepo.UnitOfWork.Students.AddAsync(student, cancellationToken);
        await _studentRepo.UnitOfWork.SaveAsync(cancellationToken);
        var studentResponse = _mapper.Map<StudentResponse>(addedStudent);
        return CreatedAtAction(nameof(GetStudentById), new { id = studentResponse.StId }, studentResponse);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, StudentRequest request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<Student>(request);
        student.StId = id;
        var isUpdated = await _studentRepo.UnitOfWork.Students.UpdateAsync(id, student, cancellationToken);
        if (isUpdated)
        {
            await _studentRepo.UnitOfWork.SaveAsync(cancellationToken);
        }
        return isUpdated ? NoContent() : NotFound();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id, CancellationToken cancellationToken)
    {
        var isDeleted = await _studentRepo.UnitOfWork.Students.DeleteAsync(id, cancellationToken);
        if (isDeleted)
        {
            await _studentRepo.UnitOfWork.SaveAsync(cancellationToken);
        }
        return isDeleted ? NoContent() : NotFound();

    }


    [HttpGet("")]
    public async Task<IActionResult> GetAllStudents(
    [FromQuery] StudentQueryRequest query,
    CancellationToken cancellationToken)
    {
        var students = await _studentRepo
            .GetAllStudentsAsync(query, cancellationToken);

        var studentResponses = _mapper.Map<IEnumerable<StudentResponse>>(students);

        return Ok(new PaginatedResponse<StudentResponse>
        {
            Data = studentResponses,
            PageNumber = query.PageNumber,
            PageSize = query.PageSize
        });

    }

}