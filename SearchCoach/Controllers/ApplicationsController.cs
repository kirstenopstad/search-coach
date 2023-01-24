using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SearchCoach.Models;

namespace SearchCoach.Controllers
{
  public class ApplicationsController : Controller
  {
    private readonly SearchCoachContext _db;

    public ApplicationsController(SearchCoachContext db)
    {
      _db = db;
    }

    // Routes
    // CREATE GET
    public ActionResult Create()
    {
      return View();
    }

    // Create POST
    [HttpPost]
    public ActionResult Create(Application application)
    {
      // instantiate new default Status status
      Status status = new Status { Stage = "Saved" };
      _db.Statuses.Add(status);
      // add StatusId to application.StatusId
      _db.SaveChanges();
      application.StatusId = status.StatusId;
      _db.Applications.Add(application);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // READ ALL
    public ActionResult Index()
    {
      return View(_db.Applications.ToList());
    }
    // READ DETAILS
    public ActionResult Details(int id)
    {
      Application application = _db.Applications
                           .Include(comp => comp.Company)
                           .Include(comp => comp.Status)
                           .FirstOrDefault(comp => comp.ApplicationId == id);
      return View(application);
    }
    // UPDATE GET
    public ActionResult Edit(int id)
    {
      Application application = _db.Applications.FirstOrDefault(comp => comp.ApplicationId == id);
      return View(application);
    }
    // UPDATE POST
    [HttpPost]
    public ActionResult Edit(Application application)
    {
      _db.Applications.Update(application);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = application.ApplicationId});
    }
    //DELETE GET
    public ActionResult Delete(int id)
    {
      Application application = _db.Applications.FirstOrDefault(comp => comp.ApplicationId == id);
      return View(application);
    }
    //DELETE POST
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmation(int id)
    {
      Application application = _db.Applications.FirstOrDefault(comp => comp.ApplicationId == id);
      _db.Applications.Remove(application);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}