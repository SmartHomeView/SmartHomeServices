using Microsoft.AspNetCore.Localization;
using Scalar.AspNetCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // 允许来自任何源的请求
              .AllowAnyMethod()  // 允许任何 HTTP 方法（GET、POST、PUT、DELETE 等）
              .AllowAnyHeader(); // 允许任何请求头
    });
});
var app = builder.Build();
var zh = new CultureInfo("zh-CN");
zh.DateTimeFormat.FullDateTimePattern = "yyyy-MM-dd HH:mm:ss";
zh.DateTimeFormat.LongDatePattern = "yyyy-MM-dd";
zh.DateTimeFormat.LongTimePattern = "HH:mm:ss";
zh.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
zh.DateTimeFormat.ShortTimePattern = "HH:mm:ss";
IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                zh,
            };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("zh-CN"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
