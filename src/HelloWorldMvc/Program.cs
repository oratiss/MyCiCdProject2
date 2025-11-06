using HelloWorldMvc.Configurations;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Photo App API",
        Version = "v1",
        Description = "API endpoints for Photo App API combined with MVC."
    });
});

builder.Services.Configure<ApiRelativeUrlConfig>(builder.Configuration.GetSection("ApiRelativeUrls"));

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri($"{builder.Configuration["ApiBaseUrl"]}");
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApp API v1");
    options.RoutePrefix = "swagger"; // available at /swagger
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // for /api routes

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HiBye}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
