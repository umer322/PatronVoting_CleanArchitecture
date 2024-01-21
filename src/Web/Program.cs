using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

Dependencies.ConfigureDependencies(builder.Configuration, builder.Services);
builder.Services.AddCookieSettings();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    o.Cookie.SameSite = SameSiteMode.Lax;
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultUI()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddCoreServices();
builder.Services.AddWebServices();
builder.Services.AddRazorPages(o =>
{
    o.Conventions.AuthorizeAreaFolder("/Areas/Admin", "/Areas/Admin");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
