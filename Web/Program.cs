using NLog.Web;
using VolkDiet.Core.Infrastructure;
using VolkDiet.WebCore.Infrastructure;



var builder = WebApplication.CreateBuilder(args);


//Calling configuration service routines
builder.Services.ConfigureServicesOnApp(builder);

//log with NLog
//https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-6
builder.Logging.ClearProviders();
builder.Host.UseNLog();

//Add services to the container.
//builder.Services.AddControllersWithViews();

var app = builder.Build();

app.ConfigurePipeline();
app.StartEngine();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
