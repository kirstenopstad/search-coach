using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SearchCoach.Models
{
  public class Quote
  {
    public int QuoteId { get; set; }
    public string Text { get; set; }

    public static List<Quote> GetQuote()
    {
      var apiCallTask = ApiHelper.GetRandom();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Quote> quote = JsonConvert.DeserializeObject<List<Quote>>(jsonResponse.ToString());

      return quote;
    }
  }
}