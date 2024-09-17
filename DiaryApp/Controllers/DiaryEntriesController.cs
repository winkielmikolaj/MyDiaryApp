using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers;

public class DiaryEntriesController : Controller
{
    private readonly ApplicationDbContext _db;

    public DiaryEntriesController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<DiaryEntry> entries = _db.DiaryEntries.ToList();

        return View(entries);
    }

    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Create(DiaryEntry obj)
    {

        if (obj != null & obj.Title.Length < 3)
        {
            ModelState.AddModelError("Title", "Title too short!");
        }
        if (ModelState.IsValid)
        {
            obj.Created = obj.Created.ToUniversalTime(); // Convert to UTC
            _db.DiaryEntries.Add(obj);//adds the new diary entry to the database
            _db.SaveChanges();//saves the changes to the database
            return RedirectToAction("Index");
        }
        return View(obj);


    }
}
