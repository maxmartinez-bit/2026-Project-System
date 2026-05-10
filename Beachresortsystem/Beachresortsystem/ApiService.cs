using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;


namespace Beachresortsystem
{
    public static class ApiService
    {
        static HttpClient client = new HttpClient();

        // API URL
        static string baseUrl = "http://localhost:5158/api/";

        // GET
        public static async Task<string> Get(string endpoint)
        {
            HttpResponseMessage response =
                await client.GetAsync(baseUrl + endpoint);

            return await response.Content.ReadAsStringAsync();
        }

        // POST
        public static async Task<string> Post(string endpoint, object data)
        {
            string json =
                JsonConvert.SerializeObject(data);

            StringContent content =
                new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response =
                await client.PostAsync(baseUrl + endpoint, content);

            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> Put(
            string endpoint,
            object data)
        {
            string json =
                JsonConvert.SerializeObject(data);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json"
                );

            HttpResponseMessage response =
                await client.PutAsync(
                    baseUrl + endpoint,
                    content
                );

            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> Delete(
            string endpoint)
        {
            HttpResponseMessage response =
                await client.DeleteAsync(baseUrl + endpoint);

            return await response.Content.ReadAsStringAsync();
        }

    }
}
