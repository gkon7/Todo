using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Todo.Common.Dto;
using Todo.Common.Types;

namespace Todo.Presentation
{
    public sealed class ApiRequester
    {
        public static string _apiUrl = "http://localhost:50818/api/";

        public static Response Call<T>(string requestUri, string method, object postData = null)
        {
            using (var _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = _apiUrl + requestUri;
                var response = new HttpResponseMessage();

                switch (method)
                {
                    case "GET":
                        response = _client.GetAsync(url).Result;
                        break;
                    case "POST":
                        response = _client.PostAsJsonAsync(url, postData).Result;
                        break;
                }

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    var responseObject = responseContent.ReadAsAsync<T>().Result;

                    return Response.Success(data: responseObject);
                }

                return Response.Error(response.StatusCode.ToString());
            }

        }
    }
}
