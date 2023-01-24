using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchCoach.Models;
using System.Collections.Generic;
using System.Linq; 
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SearchCoach.Controllers
{
  public class StatusesController : Controller
  {
    private readonly SearchCoachContext _db;

    public StatusesController(SearchCoachContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Status> model = _db.Statuses
                              .Include(status => status.Applications)
                              .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Status status)
    {
      _db.Statuses.Add(status);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Status thisStatus = _db.Statuses
                                  .Include(status => status.Applications)
                                  .FirstOrDefault(status => status.StatusId == id);
      return View(thisStatus);
    }

    public ActionResult Edit(int id)
    {
      Status thisStatus = _db.Statuses.FirstOrDefault(status => status.StatusId == id);
      ViewBag.PageTitle = "Edit status";
      return View(thisStatus);
    }

    [HttpPost]
    public ActionResult Edit(Status status)
    {
        _db.Statuses.Update(status);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}