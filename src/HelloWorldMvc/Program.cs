using HelloWorldMvc.Configurations;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


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

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HiBye}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
