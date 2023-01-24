using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SearchCoach.Models
{
  public class Company
  {
    // properties, constructors, methods, etc. go here
    public int CompanyId { get; set; }
    [Required]
    public string Name { get; set; }
    // reference
    public List<Application> Applications { get; set; }
  }
}
