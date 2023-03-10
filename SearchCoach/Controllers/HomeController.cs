using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SearchCoach.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace SearchCoach.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    private readonly SearchCoachContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(UserManager<ApplicationUser> userManager, SearchCoachContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<IActionResult> Index()
    {
      // get quote
      List<Quote> quote = Quote.GetQuote();
      ViewBag.Quote = quote;
      
      // get logged in user
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

      IQueryable<Application> userApps = _db.Applications.Where(entry => entry.User.Id == currentUser.Id);
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      Company[] companies = _db.Companies
                                      .Where(entry => entry.User.Id == currentUser.Id)
                                      .ToArray();
      Application[] applications = userApps.Include(model => model.Status).ToArray();
        
      model.Add("companies", companies);
      model.Add("applications", applications);
      if (userApps != null) { // get stats
        // get status
        // Stats!
        Dictionary<string, int> stats = new Dictionary<string, int>();
        // WeeklyAppAvg = total app count / total weeks
        // get total app count
        int AppCount = userApps.Count();
        double AppCountToDouble = System.Convert.ToDouble(AppCount); // get count of all apps 1
        // get total days count
        double dateNow = DateTime.Now.ToOADate(); // get current date 1/24/22

        int WeeklyAppAvg = 0; // initialize appAvg 
        if (applications.Length != 0) // if no first app, 
        {
          Application FirstApp = userApps.OrderByDescending(app => app.Date).First(); // get date of first app ever submitted 1/23/22 
          double dateOfFirstApp = FirstApp.Date.ToOADate(); // get date of first app ever submitted 1/23/22
          int elapsedDays = (int)(dateNow - dateOfFirstApp + 1); // get elapsed days + 1 to include the present day as a day
          int elapsedWeeks = (elapsedDays / 7); if ((elapsedDays % 7) > 0) {elapsedWeeks++;} // get elapsed weeks
          // TODO: add test for above
            // if elapsedDays == 0, then 0 wk
            // if elapsedDays == 2, then 1 wk
            // if elapsedDays == 21, then 3 wk
            // if elapsedDays == 23, then 4 wk
          double WeeklyAppAvgDouble = (AppCountToDouble / elapsedWeeks);
          WeeklyAppAvg = (int)WeeklyAppAvgDouble;

          stats.Add("WeeklyAppAvg", WeeklyAppAvg);
        }
        else
        {
          WeeklyAppAvg = 0;
          stats.Add("WeeklyAppAvg", WeeklyAppAvg);
        }

        // AllTimeAppCount = total app count
        int AllTimeAppCount = userApps.Count();

        stats.Add("AllTimeAppCount", AllTimeAppCount);

        // TODO: connect to companies related to a given user
        // AllTimeCompCount = total comp count
        int AllTimeCompCount = _db.Companies
                                          .Where(entry => entry.User.Id == currentUser.Id)
                                          .Count();

        stats.Add("AllTimeCompCount", AllTimeCompCount);

        // AllTimePhoneCount = total phone screen count
        int AllTimePhoneScreen = userApps
                                    .Include(model => model.Status)
                                    .Where(model => model.Status.PhoneScreen == true).Count();
                                    
        stats.Add("AllTimePhoneScreen", AllTimePhoneScreen);

        // AllTimeInterview = total interview count

        int AllTimeInterview1  = userApps
                                    .Include(model => model.Status)
                                    .Where(model => model.Status.Interview1 == true).Count();
        int AllTimeInterview2  = userApps
                                    .Include(model => model.Status)
                                    .Where(model => model.Status.Interview2 == true).Count();
                                  
        int AllTimeInterview = AllTimeInterview1 + AllTimeInterview2;
        stats.Add("AllTimeInterview", AllTimeInterview);
        ViewBag.Stats = stats;
      }
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