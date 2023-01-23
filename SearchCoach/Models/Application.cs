using System.Collections.Generic;

namespace SearchCoach.Models
{
  public class Application
  {
    // properties, constructors, methods, etc. go here
    public int ApplicationId { get; set; }
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
    // public int ProfileId { get; set; }
    // public Profile Profile { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; } 
  }
}
