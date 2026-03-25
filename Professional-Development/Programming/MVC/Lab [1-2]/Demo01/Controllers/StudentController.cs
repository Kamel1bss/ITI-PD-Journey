using Demo01.Models.ViewModels;
using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Demo01.Controllers;

[Authorize]
public class StudentController : Controller
{
    IUnitOfWork _unitOfWork;
    public StudentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        var model = _unitOfWork._studRepo.GetAll();
        return View(model);
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
            return BadRequest();
        var model = _unitOfWork._studRepo.GetById(id.Value);
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
    public IActionResult Create(StudentVM student) // model binder
    {
        if (!ModelState.IsValid)
        {
            ViewBag.depts = _unitOfWork._deptRepo.GetAll();
            return View(student);
        }
        var stud = new Student()
        {
            Name = student.Name,
            Age = student.Age,
            Email = student.Email,
            DeptNum = student.DeptNum,
        };

        _unitOfWork._studRepo.Add(stud);
        return RedirectToAction(nameof(Index));

    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
            return BadRequest();
        var student = _unitOfWork._studRepo.GetById(id.Value);

        if (student == null)
            return NotFound();

        StudentVM model = new StudentVM()
        {
            Id = student.Id,
            Name = student.Name,
            Age = student.Age,
            Email = student.Email,
            DeptNum = student.DeptNum
        };

        ViewBag.depts = _unitOfWork._deptRepo.GetAll();
        return View(model);

    }

    [HttpPost]
    public IActionResult Edit(StudentVM student)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.depts = _unitOfWork._deptRepo.GetAll();
            return View(student);
        }
        var stud = _unitOfWork._studRepo.GetById(student.Id);
        stud.Name = student.Name;
        stud.Age = student.Age;
        stud.DeptNum = student.DeptNum;


        _unitOfWork._studRepo.Update(stud);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
            return BadRequest();
        var model = _unitOfWork._studRepo.GetById(id.Value);

        if (model == null)
            return NotFound();

        return View(model);
    }


    [HttpPost]
    public IActionResult Delete(Student student)
    {
        _unitOfWork._studRepo.Delete(student.Id);
        return RedirectToAction(nameof(Index));
    }

    //update logic
    public IActionResult CheckEmail(string email, int? id)
    {
        var std = _unitOfWork._studRepo.FindAll(s=>s.Email == email)?.FirstOrDefault();
        if (std == null || std?.Id == id)
            return Json(true);
        return Json($"Email: {email} is aleready exists");
    }
}
