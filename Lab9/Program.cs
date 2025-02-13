using Lab9.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ������ ���� ������������ ��� ������� �� �����
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// �������� HttpClient ��� WeatherService
builder.Services.AddHttpClient<WeatherService>();

// �������� ������������ �� WeatherService
builder.Services.AddTransient<WeatherService>(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    var apiKey = configuration["OpenWeatherMap:ApiKey"]; // ��������� ����� � ������������
    return new WeatherService(httpClient, apiKey);
});
var app = builder.Build();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Weather}/{action=Index}/{id?}");

app.Run();
