using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Course_WPF.Tools
{
    public class HttpTool
    {
        static HttpClient client = new HttpClient();
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
            PropertyNameCaseInsensitive = true
        };

        static string host = "https://localhost:7077/api/";
        public static async Task<(HttpStatusCode, string)> PostAsyncs(string controller, object body, string method = null)
        {

            string url = host + controller;
            if (!string.IsNullOrEmpty(method))
                url += "/" + method;
            HttpContent bodyRequest;
            if (body != null)
            {
                string json = JsonSerializer.Serialize(body, body.GetType(), options);
                bodyRequest = new StringContent(json, Encoding.UTF8, "application/json");
            }
            else
            {
                bodyRequest = new StringContent("", Encoding.UTF8, "application/json");
            }

            var responce = await client.PostAsync(url, bodyRequest);
            var code = responce.StatusCode;
            var jsonResult = await responce.Content.ReadAsStringAsync();
            return (code, jsonResult);
        }

        public static T Deserialize<T>(string json)
        {
            return (T)JsonSerializer.Deserialize(json, typeof(T), options);
        }
    }
}
