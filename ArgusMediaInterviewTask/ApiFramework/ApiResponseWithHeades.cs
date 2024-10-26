using System.Net;
using System.Net.Http.Headers;

namespace ArgusMediaInterviewTask.ApiFramework
{
    public class ApiResponseWithHeaders
    {
        public ApiResponseWithHeaders(HttpStatusCode status, string content, HttpResponseHeaders headers)
        {
            StatusCode = status;
            Headers = headers;
            Content = content;
        }

        public HttpStatusCode StatusCode { get; private set; }
        public HttpResponseHeaders Headers { get; private set; }
        public string Content { get; set; }
    }
}