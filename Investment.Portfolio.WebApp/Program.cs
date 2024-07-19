using Investment.Portfolio.WebApp.Configurations;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebAppConfig(builder.Configuration, builder.WebHost, builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseWebAppConfig();

if (Debugger.IsAttached)
    app.Run();
else
    app.Run("http://0.0.0.0:5050");

