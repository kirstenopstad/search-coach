using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SearchCoach.Models;
using System.Threading.Tasks; // to use async methods
using System.Security.Claims; // to use claim based authorization


namespace SearchCoach.Controllers
{
  [Authorize]
  public class ApplicationsController : Controller
  {
    private readonly SearchCoachContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationsController(UserManager<ApplicationUser> userManager, SearchCoachContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    // Routes
    // CREATE GET
    public ActionResult Create()
    {
      ViewBag.CompanyId = new SelectList(_db.Companies, "CompanyId", "Name");
      return View();
    }

    // Create POST
    [HttpPost]
    public async Task<ActionResult> Create(Application application)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.CompanyId = new SelectList(_db.Companies, "CompanyId", "Name");
        return View(application);
      }
      else
      {
        // Get user
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        // Associate currentUser with item's User property
        application.User = currentUser;
        // instantiate new default Status status
        Status status = new Status { Stage = "Saved" };
        _db.Statuses.Add(status);
        _db.SaveChanges();
        // add StatusId to application.StatusId
        application.StatusId = status.StatusId;
        // application.CompanyId = status.CompanyId;
        _db.Applications.Add(application);
        _db.SaveChanges();
        
        return RedirectToAction("Index");  
      }
    }

    // READ ALL
    public ActionResult Index()
    {
      List<Application> appList = _db.Applications
                                      .Include(model=> model.Company)
                                      .ToList();
      return View(appList);
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
      ViewBag.CompanyId = new SelectList(_db.Companies, "CompanyId", "Name");
      Application application = _db.Applications.FirstOrDefault(comp => comp.ApplicationId == id);
      return View(application);
    }

    // UPDATE POST
    [HttpPost]
    public ActionResult Edit(Application application)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.CompanyId = new SelectList(_db.Companies, "CompanyId", "Name");
        return View(application);
      }
      else
      {
        _db.Applications.Update(application);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = application.ApplicationId});
      }
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