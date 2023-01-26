using System.Threading.Tasks;
using RestSharp;

namespace SearchCoach.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetRandom()
    {
      RestClient client = new RestClient("https://localhost:7264/");
      RestRequest request = new RestRequest($"api/Quotes?random=true", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
  }
}