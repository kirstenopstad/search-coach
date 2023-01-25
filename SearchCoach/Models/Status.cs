using System.Collections.Generic;

namespace SearchCoach.Models
{
  public class Status
  {
    // properties, constructors, methods, etc. go here
    public int StatusId { get; set; }
    // Stage: where in the process you are
    // Saved / Applied / In Progress / Rejected / Offered 
    public string Stage { get; set; }
    public bool PhoneScreen { get; set; }
    public bool Interview1 { get; set; }
    public bool Interview2 { get; set; }
    public bool WhiteBoarding { get; set; }
    public bool Offer { get; set; }
    public string Notes { get; set; }
    public Application Application { get; set; } 
  }
}
