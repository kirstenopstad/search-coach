using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SearchCoach.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace SearchCoach.Controllers
{
  public class HomeController : Controller
  {
    private readonly SearchCoachContext _db;
    // private readonly UserManager<ApplicationUser> _userManager;

     public HomeController(SearchCoachContext db)
      {
        _db = db;
      }
    public ActionResult Index()
    {
      // 
      // Stats!
      Dictionary<string, int> stats = new Dictionary<string, int>();

      // WeeklyAppAvg = total app count / total weeks
      DateTime dateNow = DateTime.Now;
      int WeeklyAppAvg = (_db.Applications.Count() / ((dateNow - _db.Applications.Date)/7));

      stats.Add("WeeklyAppAvg", WeeklyAppAvg);

      // AllTimeAppCount = total app count
      int AllTimeAppCount = _db.Applications.Count();

      stats.Add("AllTimeAppCount", AllTimeAppCount);

      // AllTimeCompCount = total comp count
      int AllTimeCompCount = _db.Companies.Count();

      stats.Add("AllTimeCompCount", AllTimeCompCount);

      // AllTimePhoneCount = total phone screen count
      int AllTimePhoneScreen = _db.Applications
                                  .Include(model => model.Status)
                                  .Where(model => model.Status.PhoneScreen == true).Count();
                                  
      stats.Add("AllTimePhoneScreen", AllTimePhoneScreen);

      // AllTimeInterview = total interview count
      int AllTimeInterview  = _db.Applications
                                  .Include(model => model.Status)
                                  .Where(model => model.Status.Interview1 == true).Count();
                                  //Need to include Interview2 count
                                  
      stats.Add("AllTimeInterview", AllTimeInterview);

      Company[] companies = _db.Companies.ToArray();
      Application[] applications = _db.Applications.Include(model => model.Status).ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("companies", companies);
      model.Add("applications", applications);
      ViewBag.Stats = stats;
      return View(model);
    }

    public ActionResult Search(string query)
    {
      Dictionary<string,object[]> model = new Dictionary<string, object[]>();
      Application[] applications = _db.Applications.Where(application => application.Role.Contains(query)).ToArray();
      model.Add("applications", applications);
      Company[] companies = _db.Companies.Where(company => company.Name.Contains(query)).ToArray();
      model.Add("companies", companies);
      return View(model);
    }

  }
}