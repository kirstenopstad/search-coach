using System.Collections.Generic;

namespace SearchCoach.Models
{
  public class Company
  {
    // properties, constructors, methods, etc. go here
    public int CompanyId { get; set; }
    public string Name { get; set; }
    // reference
    List<Application> Applications { get; set; }
  }
}
