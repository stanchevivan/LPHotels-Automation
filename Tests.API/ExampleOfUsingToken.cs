using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Infrastructure.Security;

namespace Tests.API
{
    //TODO Remove me
    public class ExampleOfUsingToken
    {
        public async Task Test()
        {
            var token = TokenGenerator.Get("lpfh_automationqa", 14019);


            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await
                client.GetAsync($"http://schedulingapiqa.teamhours.com:60473/locations/2/departments/2/from/2019-09-09/to/2019-09-12/labour-demand");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

        }
    }
}
