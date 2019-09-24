using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
     class Program
    {

    private const string URL = "https://localhost:44385/api/values";

    static void Main(string[] args)
    {
        // GET REQUEST
        HttpClient client = new HttpClient();

        client.BaseAddress = new Uri(URL);

        // Add an Accept header for JSON format.
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));


            string authInfo = "itay:1234";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));

            //httpClient.DefaultRequestHeaders.Authorization =
            //new AuthenticationHeaderValue("Bearer", "Your Oauth token");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", authInfo);

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
        if (response.IsSuccessStatusCode)
        {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                return;
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }


        //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
        client.Dispose();
    }
}
}
