using Demo01.Models.ViewModels;
using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers;
[Authorize]
public class CourseController : Controller
{
    IUnitOfWork _unitOfWork;
    public CourseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        var model = _unitOfWork._courseRepo.GetAll();
        return View(model);
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
            return BadRequest();
        var model = _unitOfWork._courseRepo.GetById(id.Value);
        if (model == null)
            return NotFound();
        return View(model);
    }

    // Adding (showing the form)
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.depts = _unitOfWork._deptRepo.GetAll();
        return View();
    }

    [HttpPost] // action selector
    public IActionResult Create(CourseVM course) // model binder
    {
        if (!ModelState.IsValid)
        {
            ViewBag.depts = _unitOfWork._deptRepo.GetAll();
            return View(course);
        }
        var depts = new List<Department>();
        foreach(var id in course.DepartmentIds)
        {
            depts.Add(_unitOfWork._deptRepo.GetById(id));
        }

        var cour = new Course()
        {
            CrsId = course.CrsId,
            CrsName = course.CrsName,
            Duration = course.Duration,
            Departments = depts
        };

        _unitOfWork._courseRepo.Add(cour);
        return RedirectToAction(nameof(Index));

    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
            return BadRequest();
        var course = _unitOfWork._courseRepo.GetById(id.Value);

        if (course == null)
            return NotFound();

        var deptIds = new List<int>();
        foreach(var dept in course.Departments)
        {
            deptIds.Add(dept.DeptId);
        }
        CourseVM model = new CourseVM()
        {
            CrsId = course.CrsId,
            CrsName = course.CrsName,
            Duration = course.Duration,
            DepartmentIds = deptIds
        };

        ViewBag.depts = _unitOfWork._deptRepo.GetAll();
        return View(model);

    }

    [HttpPost]
    public IActionResult Edit(CourseVM course)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.depts = _unitOfWork._deptRepo.GetAll();
            return View(course);
        }
        var cour = _unitOfWork._courseRepo.GetById(course.CrsId);
        cour.CrsName = course.CrsName;
        cour.Duration = course.Duration;
        var depts = new List<Department>();
        foreach (var dept in course.DepartmentIds)
        {
            depts.Add(_unitOfWork._deptRepo.GetById(dept));
        }
        cour.Departments = depts;

        _unitOfWork._courseRepo.Update(cour);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
            return BadRequest();
        var model = _unitOfWork._courseRepo.GetById(id.Value);

        if (model == null)
            return NotFound();

        return View(model);
    }


    [HttpPost]
    public IActionResult Delete(Course course)
    {
        _unitOfWork._courseRepo.Delete(course.CrsId);
        return RedirectToAction(nameof(Index));
    }

}
