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
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }


        DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

        if (diaryEntry == null)
        {
            return NotFound();
        }

        return View(_db.DiaryEntries.Find(id));
    }

    [HttpPost]
    public IActionResult Edit(DiaryEntry obj)
    {

        if (obj != null & obj.Title.Length < 3)
        {
            ModelState.AddModelError("Title", "Title too short!");
        }
        if (ModelState.IsValid)
        {
            obj.Created = obj.Created.ToUniversalTime(); // Convert to UTC
            _db.DiaryEntries.Update(obj);//update the diary entry to the database
            _db.SaveChanges();//saves the changes to the database
            return RedirectToAction("Index");
        }
        return View(obj);


    }


    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }


        DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

        if (diaryEntry == null)
        {
            return NotFound();
        }

        return View(_db.DiaryEntries.Find(id));
    }

    [HttpPost]
    public IActionResult Delete(DiaryEntry obj)
    {

        if (obj != null & obj.Title.Length < 3)
        {
            ModelState.AddModelError("Title", "Title too short!");
        }
        if (ModelState.IsValid)
        {
            obj.Created = obj.Created.ToUniversalTime(); // Convert to UTC
            _db.DiaryEntries.Remove(obj);//remove the diary entry to the database
            _db.SaveChanges();//saves the changes to the database
            return RedirectToAction("Index");
        }
        return View(obj);


    }
}
