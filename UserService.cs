using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PepsArts_Mobile
{
    public class UserService
    {
        private readonly HttpClient _httpclient;

        public UserService()
        {
            this._httpclient = new HttpClient(); ;

        }

        public async Task<T> GetExhibition<T>(string url)
        {


            //string url = "http://192.168.20.165:4000/api/users/63";

            _httpclient.BaseAddress = new Uri(url);

            HttpResponseMessage response = await _httpclient.GetAsync("");

            //var response = await _httpclient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonstring = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(jsonstring);
            }

            throw new HttpRequestException($"Request failed with status code {response.StatusCode}");

        }


        public async Task<T> CreateQoutation<T>(string url, HttpContent content)
        {


            //string url = "http://192.168.20.165:4000/api/users/63";

            _httpclient.BaseAddress = new Uri(url);

            HttpResponseMessage response = await _httpclient.PostAsync("", content);

            //var response = await _httpclient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonstring = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(jsonstring);
            }

            throw new HttpRequestException($"Request failed with status code {response.StatusCode}");

        }

        public async Task<T> ViewExhibitions<T>(string url)
        {


            //string url = "http://192.168.20.165:4000/api/users/63";

            _httpclient.BaseAddress = new Uri(url);

            HttpResponseMessage response = await _httpclient.GetAsync("");

            //var response = await _httpclient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonstring = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(jsonstring);
            }

            throw new HttpRequestException($"Request failed with status code {response.StatusCode}");

        }

        public async Task<T> GetArtPieces<T>(string url)
        {


            //string url = "http://192.168.20.165:4000/api/users/63";

            _httpclient.BaseAddress = new Uri(url);

            HttpResponseMessage response = await _httpclient.GetAsync("");

            //var response = await _httpclient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonstring = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(jsonstring);
            }

            throw new HttpRequestException($"Request failed with status code {response.StatusCode}");

        }

        public async Task<T> ExhibitionRegistration<T>(string url, HttpContent content)
        {


            //string url = "http://192.168.20.165:4000/api/users/63";

            _httpclient.BaseAddress = new Uri(url);

            HttpResponseMessage response = await _httpclient.PostAsync("", content);

            //var response = await _httpclient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonstring = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(jsonstring);
            }

            throw new HttpRequestException($"Request failed with status code {response.StatusCode}");

        }
        public async Task<T> GetAsync<T>(string url)
        {


            //string url = "http://192.168.20.165:4000/api/users/63";

            _httpclient.BaseAddress = new Uri(url);

            HttpResponseMessage response = await _httpclient.GetAsync("");

            //var response = await _httpclient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonstring = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(jsonstring);
            }

            throw new HttpRequestException($"Request failed with status code {response.StatusCode}");

        }

        public async Task<T>  Login<T>(string url, HttpContent content)
        {


            //string url = "http://192.168.20.165:4000/api/users/63";

           

            HttpResponseMessage response = await _httpclient.PostAsync(url, content);

            //var response = await _httpclient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonstring = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(jsonstring);
            }

            throw new HttpRequestException($"Request failed with status code {response.StatusCode}");

        }


    }
}
