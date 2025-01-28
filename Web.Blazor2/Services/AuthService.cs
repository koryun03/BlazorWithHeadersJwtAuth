using System.Net.Http.Headers;
using Web.Blazor2.ServiceInterfaces;

namespace Web.Blazor2.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        //private readonly ICookieService _cookieService;
        IHttpContextAccessor _httpContextAccessor;
        public AuthService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Login(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("api/User/Login", new { id = 0, login = username, password });

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                //var content = await response.Content.ReadFromJsonAsync<JwtResponse>();

                //    _httpContextAccessor.HttpContext.Response.Cookies.Append("testttcoookie", token);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                //var handler = new HttpClientHandler();
                ////handler.CookieContainer = new CookieContainer();
                //handler.CookieContainer.Add(new Uri("http://yourapi.com"), new Cookie("auth_token", token));

                return true;
            }

            return false;
        }

        public async Task<bool> Register(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("api/User/Register", new { login = username, password });

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }



        public async Task<string> GetToken()
        {
            //return await _cookieService.GetCookieAsync("testttcoookie");
            return "";
        }

        public async Task Logout()
        {
            //await _cookieService.RemoveCookieAsync("testttcoookie");
        }

        public async Task<bool> AuthorizeTest()
        {
            var response = await _httpClient.GetAsync("api/User/TestAuthorize");

            if (response.IsSuccessStatusCode)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }

    public class JwtResponse
    {
        public string Token { get; set; }
    }
}
