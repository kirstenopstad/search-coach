using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SearchCoach.Models;

namespace SearchCoach.Controllers
{
  public class CompaniesController : Controller
  {
    private readonly SearchCoachContext _db;

    public CompaniesController(SearchCoachContext db)
    {
      _db = db;
    }

    // Routes
    // Create GET
    public ActionResult Create()
    {
      ViewBag.CompanyIId = new SelectList(_db.Companies, "CompanyId", "Name");
      ViewBag.StatusIId = new SelectList(_db.Statuses, "StatusId", "Name");
      return View();
    }

    // Create POST
    [HttpPost]
    public ActionResult Create(Company company)
    {
      _db.Companies.Add(company);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    // Read All
    public ActionResult Index()
    {
      return View(_db.Companies.ToList());
    }

    // Read Details
    public ActionResult Details(int id)
    {
      Company company = _db.Companies
                           .Include(comp => comp.Applications)
                           .FirstOrDefault(comp => comp.CompanyId == id);
      return View(company);
    }
    
    // Update GET 
    public ActionResult Edit(int id)
    {
      Company company = _db.Companies.FirstOrDefault(comp => comp.CompanyId == id);
      return View(company);
    }
    
    // Update POST 
    [HttpPost]
    public ActionResult Edit(Company company)
    {
      _db.Companies.Update(company);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = company.CompanyId});
    }

    // Delete GET
    public ActionResult Delete(int id)
    {
      Company company = _db.Companies.FirstOrDefault(comp => comp.CompanyId == id);
      return View(company);
    }

    // Delete
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmation(int id)
    {
      Company company = _db.Companies.FirstOrDefault(comp => comp.CompanyId == id);
      _db.Companies.Remove(company);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}