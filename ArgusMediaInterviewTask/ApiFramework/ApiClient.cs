using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ArgusMediaInterviewTask.ApiFramework
{
    public class ApiClient
    {
        public string apiUrl { get; set; }
        public HttpContent requestBody { get; set; }
        
        public ApiResponseWithHeaders PostAsync()
        {
            var httpClient = GetHttpClient();
            var response = httpClient.PutAsync(apiUrl, requestBody).Result;
            var responsMessage = response.Content.ReadAsStringAsync().Result.ToString();
            return new ApiResponseWithHeaders(response.StatusCode, responsMessage, response.Headers);
        }

        public HttpClient GetHttpClient()
        {
            return new HttpClient();
        }

        public void AddRequestbody(string payload)
        {
            requestBody = new StringContent(payload);
        }

    }


}
