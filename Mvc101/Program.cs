using Mvc101.Models;
using Mvc101.Services.EmailService;
using Mvc101.Services.SmsService;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISmsService, WissenSmsService>();
//builder.Services.AddSendGrid(options =>
//{
//    options.ApiKey = "123123123123serviceapi123123123123";
//});
builder.Services.AddScoped<IEmailService, OutlookEmailService>();
builder.Services.AddControllersWithViews();



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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();