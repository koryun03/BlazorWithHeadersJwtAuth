using Microsoft.JSInterop;
using Web.Blazor1.ServiceInterfaces;

namespace Web.Blazor1.Services
{
    public class CookieService : ICookieService
    {
        private readonly IJSRuntime _jsRuntime;

        public CookieService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SetCookieAsync(string key, string value, int expireDays)
        {
            string script = $"document.cookie = '{key}={value}; path=/; expires=' + new Date(new Date().getTime() + {expireDays} * 24 * 60 * 60 * 1000).toUTCString();";
            await _jsRuntime.InvokeVoidAsync("eval", script);
        }

        public async Task<string> GetCookieAsync(string key)
        {
            string script = @"
            const cookieArr = document.cookie.split('; ');
            const cookie = cookieArr.find(c => c.startsWith('" + key + @"='));
            return cookie ? cookie.split('=')[1] : null;";
            return await _jsRuntime.InvokeAsync<string>("eval", script);
        }

        public async Task RemoveCookieAsync(string key)
        {
            string script = $"document.cookie = '{key}=; path=/; expires=Thu, 01 Jan 1970 00:00:00 UTC;'";
            await _jsRuntime.InvokeVoidAsync("eval", script);
        }
    }

}
