using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SearchCoach.Models
{
  public class Company
  {
    // properties, constructors, methods, etc. go here
    public int CompanyId { get; set; }
    [Required(ErrorMessage = "The company name can't be empty!")]
    public string Name { get; set; }
    // reference
    public List<Application> Applications { get; set; }
  }
}
