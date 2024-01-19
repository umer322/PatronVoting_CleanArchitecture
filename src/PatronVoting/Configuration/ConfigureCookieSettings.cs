namespace Web.Configuration
{
    public static class ConfigureCookieSettings
    {
        private const int CookieExpirationTime = 5;
        public const string IdentifierCookieName = "EshopIdentifier";
        public static IServiceCollection AddCookieSettings(this IServiceCollection services)
        {

            services.AddCookiePolicy(o =>
            {
                o.MinimumSameSitePolicy = SameSiteMode.Strict;
            });
            services.ConfigureApplicationCookie(o =>
            {
                o.AccessDeniedPath = "/Account/Login";
                o.LogoutPath = "/Account/Logout";
                o.LoginPath = "/Account/Login";
                o.Cookie.HttpOnly = true;
                o.ExpireTimeSpan = TimeSpan.FromMinutes(CookieExpirationTime);
                o.Cookie = new CookieBuilder
                {
                    Name = IdentifierCookieName,
                    IsEssential = true,
                };
            });
            return services;
        }
    }
}
