using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lexov.Models
{
    class ServiceRequestHandler
    {
        public static async Task<T> MakeServiceCall<T>(ServiceRequest req, object body = null, Dictionary<string, string> urlParams = null) where T : BaseResponse, new()
        {
            HttpClient client = new HttpClient();

            using (var request = CreateHttpRequest(req, body, urlParams))
            {
                try
                {
                    var response = await client.SendAsync(request);
                    var content = await response.Content.ReadAsStringAsync();

                    if(response.IsSuccessStatusCode)
                    {
                        try
                        {
                            T obj = JsonConvert.DeserializeObject<T>(content);
                            if(obj == null)
                            {
                                obj = new T();
                            }

                            return obj;
                        }

                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return new T()
                            {
                                ErrorTextAdditional = "Malformed response: " + e.Message
                            };
                        }
                    }

                    else
                    {
                        try
                        {
                            T obj = JsonConvert.DeserializeObject<T>(content);
                            obj.ErrorTextAdditional = "An error occurred: " + response.ReasonPhrase + ", Status Code: " + (int)response.StatusCode;
                            return obj;
                        }

                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);

                    T obj = new T();
                    obj.ErrorTextAdditional = "An error occurred: " + e.Message;
                    return obj;
                }

                return default;
            }
        }

        public static HttpRequestMessage CreateHttpRequest(ServiceRequest req, object body = null, Dictionary<string, string> urlParams = null)
        {
            var url = req.Url;
            var method = req.Method;
            var customHeaders = req.Headers;

            url = AddURLParams(url, urlParams);

            var request = new HttpRequestMessage(method, url);

            if(customHeaders != null)
            {
                foreach(KeyValuePair<string, string> entry in customHeaders)
                {
                    request.Headers.Add(entry.Key, entry.Value);
                }
            }

            if (body != null)
            {
                var bodyJson = JsonConvert.SerializeObject(body);

                var requestBody = new StringContent(bodyJson, Encoding.UTF8, "application/json");
                request.Content = requestBody;
            }

            return request;
        }

        public static string AddURLParams(string url, Dictionary<string, string> urlParams)
        {
            if(urlParams != null)
            {
                url += "?";
                foreach(KeyValuePair<string, string> entry in urlParams)
                {
                    url += $"{entry.Key}={HttpUtility.UrlEncode(entry.Value)}&";
                }
                url = url.TrimEnd('&');
            }

            return url;
        }
    }
}
