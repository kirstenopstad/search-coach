using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SearchCoach.Models
{
  public class Application
  {
    // properties, constructors, methods, etc. go here
    public int ApplicationId { get; set; }
    [Required(ErrorMessage = "The Role field can't be empty!")]
    public string Role { get; set; } //same as name
    public string ResumeURL { get; set; }
    public string CoverLetterURL { get; set; }
    public bool IsRemote { get; set; }
    public bool IsHybrid { get; set; }
    public int Salary { get; set; }
    // User Notes
    public string TechStack { get; set; }
    public string Network { get; set; }
    // reference
    public ApplicationUser User { get; set; }
    [Required(ErrorMessage = "The Company field can't be empty!")]
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; }
    [Range(typeof(DateTime), "1/1/2023", "12/31/2123", ErrorMessage = "Dates must be from 2023 or later.")]
    [Required(ErrorMessage = "The date field can't be empty!")]
    public DateTime Date { get; set; }
    
  }
}
