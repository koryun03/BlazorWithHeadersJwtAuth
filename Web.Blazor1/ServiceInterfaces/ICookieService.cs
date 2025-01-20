namespace Web.Blazor1.ServiceInterfaces
{
    public interface ICookieService
    {
        Task SetCookieAsync(string key, string value, int expireDays);
        Task<string> GetCookieAsync(string key);
        Task RemoveCookieAsync(string key);
    }
}
