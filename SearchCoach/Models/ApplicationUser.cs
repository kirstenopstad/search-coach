using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SearchCoach.Models
{
    public class ApplicationUser : IdentityUser
    {
      [Required]
      [RegularExpression("^[a-zA-Z .]+$", ErrorMessage = "Invalid Name")]
      public string FirstName {get;set;}
      [Required]
      [RegularExpression("^[a-zA-Z .]+$", ErrorMessage = "Invalid Name")]
      public string LastName {get;set;}
      // Stats!
      public int WeeklyAppAvg {get;set;}
      public int AllTimeAppCount {get;set;}
      public int AllTimeCompCount {get;set;}
      public int AllTimePhoneScreen {get;set;}
      public int AllTimeInterview {get;set;}
    }
}
