using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace SmartHomeServices.Helper
{
    public class HomeAssistantHelper
    {
        /// <summary>
        /// 发送get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postString"></param>
        /// <returns></returns>
        public HomeAssistantResponse GetHomeAssistantResponse(string HomeAssistantUrl, string HomeAssistantToken)
        {
            HomeAssistantResponse Response = new HomeAssistantResponse();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", HomeAssistantToken);
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            try
            {
                var response = client.GetAsync(HomeAssistantUrl).Result;
                Response.StatusCode = (int)response.StatusCode;
                string result = response.Content.ReadAsStringAsync().Result;
                Response.Response = result;
                return Response;
            }
            catch (Exception e)
            {
                Response.Response = e.Message;
            }
            return Response;
        }

        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postString"></param>
        /// <returns></returns>
        public HomeAssistantResponse PostHomeAssistantResponse(string HomeAssistantUrl, string HomeAssistantToken, string data)
        {
            HomeAssistantResponse Response = new HomeAssistantResponse();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", HomeAssistantToken);
            client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            var buffer = Encoding.UTF8.GetBytes(data);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                var response = client.PostAsync(HomeAssistantUrl, byteContent).Result;
                Response.StatusCode = (int)response.StatusCode;
                string result = response.Content.ReadAsStringAsync().Result;
                return Response;
            }
            catch (Exception e)
            {
                Response.Response = e.Message;
            }
            return Response;
        }


        public class HomeAssistantResponse
        {
            public int StatusCode { get; set; }
            public string? Response { get; set; }
        }
    }
}
