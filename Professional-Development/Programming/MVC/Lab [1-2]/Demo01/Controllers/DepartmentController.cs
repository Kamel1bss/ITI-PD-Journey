using ITIEntities;
using ITIEntities.Data;
using ITIEntities.Migrations;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Demo01.Controllers;

[Authorize]
public class DepartmentController : Controller
{
    
    IUnitOfWork _unitOfWork;
    StudentCourseRepo _studentCourseRepo;
    public DepartmentController(IUnitOfWork unitOfWork,
                                StudentCourseRepo studentCourseRepo)
    {
        _unitOfWork = unitOfWork;
        _studentCourseRepo = studentCourseRepo;
    }
    
    //[Authorize]
    public IActionResult showCourses(int id)
    {
        var model = _unitOfWork._deptRepo.GetById(id);
        return View(model);
    }

    public IActionResult ManageDeptCourses(int id)
    {
        var model = _unitOfWork._deptRepo.GetById(id);
        var AllCourse = _unitOfWork._courseRepo.GetAll();
        var coursesNotInDept = AllCourse.Except(model.Courses).ToList();
        ViewBag.coursesNotInDept = coursesNotInDept;
        return View(model);
    }
    [HttpPost]
    public IActionResult ManageDeptCourses(int id, int[] coursesToRemove, int[] coursesToAdd)
    {
        var dept = _unitOfWork._deptRepo.GetById(id);
        foreach (var courseId in coursesToRemove)
        {
            Course course = dept.Courses.FirstOrDefault(c => c.CrsId == courseId);
            if (course == null)
                continue;
            dept.Courses.Remove(course);
        }

        foreach (var courseId in coursesToAdd)
        {
            Course course = _unitOfWork._courseRepo.GetById(courseId);
            dept.Courses.Add(course);
        }

        _unitOfWork._deptRepo.Update(dept);

        return RedirectToAction(nameof(showCourses), new { id = id });
    }
    public IActionResult Index()
    {
        var model = _unitOfWork._deptRepo.GetAll();
        return View(model);
    }

    public IActionResult Details(int? id)
    {
        if(id == null)
            return BadRequest();
        var model = _unitOfWork._deptRepo.GetById(id.Value);
        if(model == null)
            return NotFound();
        return View(model);
    }

    // Adding (showing the form)
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] // action selector
    public IActionResult Create(Department dept) // model binder
    {
        _unitOfWork._deptRepo.Add(dept);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
            return BadRequest();
        var model = _unitOfWork._deptRepo.GetById(id.Value);

        if (model == null)
            return NotFound();

        return View(model);

    }

    [HttpPost]
    public IActionResult Edit(Department department)
    {
        _unitOfWork._deptRepo.Update(department);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
            return BadRequest();
        var model = _unitOfWork._deptRepo.GetById(id.Value);

        if (model == null)
            return NotFound();

        return View(model);
    }


    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int? id)
    {
        if (id == null)
            return BadRequest();
        _unitOfWork._deptRepo.Delete(id.Value);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult CourseDegrees(int DeptId, int CrsId)
    {
        var students = _unitOfWork._studRepo.GetAll().Where(s => s.DeptNum == DeptId).ToList();
        List<StudentCourse> studentCourses = new List<StudentCourse>();
        foreach(var student in students)
        {
            StudentCourse stcours = _studentCourseRepo.GetByIds(student.Id, CrsId);
            if (stcours == null)
            {
                stcours = new StudentCourse()
                {
                    StudentId = student.Id,
                    Student = _unitOfWork._studRepo.GetById(student.Id),
                    CrsId = CrsId,
                    Course = _unitOfWork._courseRepo.GetById(CrsId)
                };
            }

            studentCourses.Add(stcours);    
        }
        var course = _unitOfWork._courseRepo.GetById(CrsId);
        ViewBag.Course = course;
        return View(studentCourses);
    }

    [HttpPost]
    public IActionResult CourseDegrees([FromQuery]int DeptId, [FromQuery]int CrsId, Dictionary<int,int>studCourse)
    {
        List<StudentCourse> degrees = new List<StudentCourse>();
        foreach (var p in studCourse)
        {
            var degree = new StudentCourse()
            {
                CrsId = CrsId,
                StudentId = p.Key,
                Degree = p.Value
            };
            degrees.Add(degree);
        }

        List<StudentCourse> degreesToAdd = new List<StudentCourse>();
        List<StudentCourse> degreesToUpdate = new List<StudentCourse>();
        foreach (var degree in degrees)
        {
            var deg = _studentCourseRepo.GetByIds(degree.StudentId, degree.CrsId);
            if (deg == null)
                degreesToAdd.Add(degree);
            else
            {
                deg.Degree = degree.Degree;
                degreesToUpdate.Add(deg);
            }

        }

        if (degreesToAdd.Count > 0)
            _studentCourseRepo.AddRange(degreesToAdd);
        if (degreesToUpdate.Count > 0)
            _studentCourseRepo.UpdateRange(degreesToUpdate);

        return RedirectToAction(nameof(showCourses), new {id = DeptId});
    }
}
