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

        private const string URL = "https://localhost:44317/api/values";

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

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "Uq1e4d7-d2ckB57m8OgzGk-lIZiBjG4gvAylHlIs6EVG3UBAMCB87nB0S047tFVJlcNFyuwk1pV27c8dCwJ_oNplQCFQoy0c7pFRG4i4O4K4uyuGpegnEEZ-mQ15KiTjJ1dL_xQfiw-7YGS-X_atj53jmLBcrnLfSKbzmUFeHSKdXPYCPJzTcJ5JpET6utFUbXYlBDql9pdSfZGIEN566pcAgqNPGMN9zfEH2PViJap67pbzIy0rOoilZgIqZGEuFhLmKW19nA6gKIsuIAZioIQ655KfKtAXNkuoTyWAVVB7MgTkmtOQDzke67W7FRjStBP29koWmjjKUeO1qvSTWd6RJERFreqqXMzl0D1vVPb2tLjBbf-Hv8nkiWEHHX-s9LydSGdaMak80z2mXBLSULTpgHwvDN1wSllGn9mrxT0vuzDgenc7hSqDuHnldrSM5HSnwFxQMDdnd9ZAj-k4jCt1vOVjyfJzcHWe_D4qoXWIkaJLB0sXu0eOYwk0QAUp");

            //client.DefaultRequestHeaders.Authorization =
            //new AuthenticationHeaderValue("Basic", authInfo);

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