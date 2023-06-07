using System.Threading.Tasks;
using RestSharp;

namespace ARatsLifeClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAllRats()
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/rats", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetRat(int id)
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/rats/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
    //--------------------------- 
    // for application users

    public static async void Register(string newApplicationUser)
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/accounts", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newApplicationUser);
      await client.PostAsync(request);
    }
    public static async Task<string> Login(string userInfo)
    {
      RestClient client = new RestClient("http://localhost:5102/");
      RestRequest request = new RestRequest($"api/accounts/login", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(userInfo);
      RestResponse response = await client.PostAsync(request);
      return response.Content;
    }
  }
}