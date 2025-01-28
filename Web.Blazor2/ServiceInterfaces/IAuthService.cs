namespace Web.Blazor2.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<bool> Login(string username, string password);
        Task<bool> Register(string username, string password);
        Task<string> GetToken();
        Task Logout();
        Task<bool> AuthorizeTest();
    }
}
