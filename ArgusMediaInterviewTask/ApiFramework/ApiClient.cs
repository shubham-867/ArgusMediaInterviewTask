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
        public string ApiUrl { get; set; }
        public HttpContent RequestBody { get; set; }

        /// <summary>
        /// Method to execute Post Api calls
        /// </summary>       
        public ApiResponseWithHeaders PostAsyncRequest()
        {
            var httpClient = GetHttpClient();
            var response = httpClient.PutAsync(ApiUrl, RequestBody).Result;
            var responsMessage = response.Content.ReadAsStringAsync().Result.ToString();
            return new ApiResponseWithHeaders(response.StatusCode, responsMessage, response.Headers);
        }

        /// <summary>
        /// Method to execute Get Api calls
        /// </summary>
        public ApiResponseWithHeaders GetAsync()
        {
            var httpClient = GetHttpClient();
            var response = httpClient.GetAsync(ApiUrl).Result;
            var responsMessage = response.Content.ReadAsStringAsync().Result.ToString();
            return new ApiResponseWithHeaders(response.StatusCode, responsMessage, response.Headers);
        }
        public HttpClient GetHttpClient()
        {
            return new HttpClient();
        }

        public void AddRequestbody(string payload)
        {
            RequestBody = new StringContent(payload, Encoding.UTF8, "application/json");
        }



    }


}
