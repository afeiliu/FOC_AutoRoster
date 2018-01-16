using Demo.WpfApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Demo.WpfApp.Common
{
    public class HttpClientUtility
    {
        private readonly string _baseAddress = ConfigurationManager.AppSettings["ApiBaseAddress"];
        private HttpClient _client = new HttpClient();

        public HttpClientUtility()
        {
            _client.BaseAddress = new Uri(_baseAddress);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient GetHttpClient(string token)
        {
            _client.DefaultRequestHeaders.Remove("Authorization");
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            return _client;
        }

        public async Task<ResponseToken> GetToken(string userName, string password)
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            Dictionary<string, string> contentBody = new Dictionary<string, string>
            {
                {"grant_type","password"},
                {"username",userName},
                {"password",password}
            };

            try
            {
                HttpResponseMessage response = await _client.PostAsync("/token", new FormUrlEncodedContent(contentBody));
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                ResponseToken result = JsonConvert.DeserializeObject<ResponseToken>(content);

                return result;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseToken> GetRefreshToken(string refreshToken)
        {
            _client.DefaultRequestHeaders.Accept.Remove(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            Dictionary<string, string> contentBody = new Dictionary<string, string>
            {
                {"grant_type","refresh_token"},
                {"refresh_token",refreshToken}
            };

            try
            {
                HttpResponseMessage response = await _client.PostAsync("/token", new FormUrlEncodedContent(contentBody));
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                ResponseToken result = JsonConvert.DeserializeObject<ResponseToken>(content);

                return result;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
