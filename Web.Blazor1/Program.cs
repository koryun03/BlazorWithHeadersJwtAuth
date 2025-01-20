using System.Net.Http.Headers;
using Web.Blazor1.Components;
using Web.Blazor1.ServiceInterfaces;
using Web.Blazor1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7235/") });
builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped(async sp =>
{
    var authService = sp.GetRequiredService<IAuthService>();
    var token = await authService.GetToken();

    var client = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7235")
    };

    if (!string.IsNullOrEmpty(token))
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    return client;
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICookieService, CookieService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseAuthentication();?????????
//app.UseAuthorization();?????????

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
