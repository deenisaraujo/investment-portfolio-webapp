namespace Investment.Portfolio.WebApp.Configurations
{
    public static class WebAppConfig
    {
        public static void AddWebAppConfig(this IServiceCollection services, IConfiguration configuration, IWebHostBuilder builder, IWebHostEnvironment env)
        {
            services.AddMemoryCache();
            services.AddControllersWithViews();

            services.RegisterServices(configuration);

            services.AddMvc().AddRazorOptions(options =>
            {
                options.PageViewLocationFormats
                 .Add("/Views/shared/{0}.cshtml");
            });
        }

        public static void UseWebAppConfig(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
