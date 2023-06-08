using System.Threading.Tasks;
using RestSharp;
using ARatsLifeClient.ViewModels;

namespace ARatsLifeClient.Models
{
  public class ApiHelper
  {

    private const string HOSTNAME = "http://localhost:5102/";
    public static async Task<string> GetAllRats()
    {
      var client = new RestClient(HOSTNAME);
      var request = new RestRequest($"api/rats", Method.Get);
      var response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetRat(int id)
    {
      RestClient client = new RestClient(HOSTNAME);
      RestRequest request = new RestRequest($"api/rats/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
    //--------------------------- 
    // for application users

    public static async Task RegisterAsync(RegisterViewModel newApplicationUser)
    {
      using var httpClient = new HttpClient();
      var path = HOSTNAME + "api/accounts";
      var resp = await httpClient.PostAsJsonAsync<RegisterViewModel>(path, newApplicationUser);

      if (resp.IsSuccessStatusCode) {
        // return resp.Content
        return;
      }

      var returnedMsg = await resp.Content.ReadAsStringAsync();
      throw new KylesCustomException(returnedMsg);
      // var client = new RestClient(HOSTNAME);
      // var request = new RestRequest($"api/accounts", Method.Post);
      // request.AddHeader("Content-Type", "application/json");
      // request.AddJsonBody(newApplicationUser);

      // await client.PostAsync(request);
      // Console.WriteLine("Hummus");
    }

    public static async Task<string> Login(string userInfo)
    {
      RestClient client = new RestClient(HOSTNAME);
      RestRequest request = new RestRequest($"api/accounts/login", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(userInfo);
      RestResponse response = await client.PostAsync(request);
      return response.Content;
    }
  }
}