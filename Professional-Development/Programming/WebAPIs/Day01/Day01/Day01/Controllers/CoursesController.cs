using Day01.Data;
using Day01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day01.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(ITIDbContext context) : ControllerBase
{
    private readonly ITIDbContext _context = context;

    [HttpGet]
    public IActionResult Get()
    {
        var students = _context.Courses.ToList();
        return students != null && students.Count > 0
            ? Ok(students)
            : NotFound("No courses found");
    }

    [HttpDelete("{id}")]
    public IActionResult deleteCourse(int id)
    {
        var course = _context.Courses.Find(id);
        if (course == null)
            return NotFound($"Course with id {id} not found");
        
        _context.Courses.Remove(course);
        _context.SaveChanges();
        return Ok(_context.Courses.ToList());
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Course updatedCourse)
    {
        if (id != updatedCourse.Id)
            return BadRequest("Course ID mismatch");


        var course = _context.Courses.Find(id);
        if (course == null)
            return NotFound($"Course with id {id} not found");
        
        course.Crs_name = updatedCourse.Crs_name;
        course.Crs_desc = updatedCourse.Crs_desc;
        course.Duration = updatedCourse.Duration;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPost]
    public IActionResult Post(Course newCourse)
    {
        if(newCourse == null)
            return BadRequest("Course is null");

        _context.Courses.Add(newCourse);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = newCourse.Id }, newCourse);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var course = _context.Courses.Find(id);
        return course != null
            ? Ok(course)
            : NotFound($"Course with id {id} not found");
    }

    [HttpGet("byname/{name}")]
    public IActionResult CourseByName(string name) 
    {
        var course = _context.Courses.FirstOrDefault(c => c.Crs_name == name);
        return course != null
            ? Ok(course)
            : NotFound($"Course with name {name} not found");
    }

}
