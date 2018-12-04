using Newtonsoft.Json;
using RunpathCodingTest.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RunpathCodingTest.Config
{
    public class ApiConnection
    {
        public string BaseUrl { get; set; }

        public double TimeoutInSeconds { get; set; }


        public async Task<IValueJsonResponse<T>> GetAsync<T>(string url, params object[] parameters)
        {
            var fullUrl = string.Format(url, parameters);
            return await Execute<ValueJsonResponse<T>>(HttpMethod.Get.ToString(), fullUrl).ConfigureAwait(false);
        }

//        private async Task<TResponse> Execute<TResponse>(HttpMethod method, string url, object value = null)
//where TResponse : IVoidJsonResponse, new()
//        {
//            return await Execute<TResponse>(method, url, value);
//        }

        private async Task<TResponse> Execute<TResponse>(string method, string url, object value = null)
     where TResponse : IVoidJsonResponse, new()
        {
            var result = new TResponse();

            using (var client = new HttpClient())
            {

                client.Timeout = TimeSpan.FromSeconds(this.TimeoutInSeconds);
                client.BaseAddress = new Uri(this.BaseUrl);



                HttpResponseMessage response = null;

                if (method == HttpMethod.Get.Method)
                {
                    response = await client.GetAsync(url);
                }
                else if (method == HttpMethod.Delete.Method)
                {
                    response = await client.DeleteAsync(url);
                }
                else
                {
                    HttpContent content = null;

                    if (value != null && value.GetType() == typeof(MultipartFormDataContent))
                    {
                        content = value as MultipartFormDataContent;
                    }
                    else
                    {
                        // Need to use JsonConvert to serialize NodaTime types
                        content = new StringContent(JsonConvert.SerializeObject(value));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    }

                    if (method == HttpMethod.Post.Method)
                    {
                        response = await client.PostAsync(url, content);
                    }
                    else if (method == HttpMethod.Put.Method)
                    {
                        response = await client.PutAsync(url, content);
                    }
                    else if (method == "PATCH")
                    {
                        response = await client.PatchAsync(url, content);
                    }
                }

                var responseString = await response.Content.ReadAsStringAsync();
                try
                {
                    result.DeserialiseResponse(response, responseString);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return result;
        }
    }
}
