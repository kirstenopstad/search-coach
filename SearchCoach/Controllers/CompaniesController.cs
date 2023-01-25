using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks; // to use async methods
using System.Security.Claims; // to use claim based authorization
using SearchCoach.Models;

namespace SearchCoach.Controllers
{
  [Authorize]
  public class CompaniesController : Controller
  {
    private readonly SearchCoachContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public CompaniesController(UserManager<ApplicationUser> userManager, SearchCoachContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    // Routes
    // Create GET
    public ActionResult Create()
    {
      return View();
    }

    // Create POST
    [HttpPost]
    public async Task<ActionResult> Create(Company company)
    {
      if (!ModelState.IsValid)
      {
        return View(company);
      }
      else
      {
        // Get user
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        // Associate currentUser with company's User property
        company.User = currentUser;
        _db.Companies.Add(company);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
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
      if (!ModelState.IsValid)
      {
        return View(company);
      }
      else
      {
        _db.Companies.Update(company);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = company.CompanyId});
      }
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