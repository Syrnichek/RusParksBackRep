using Microsoft.Extensions.FileProviders;
using RusParksBack.Interfaces;
using RusParksBack.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserManageService, UserManageService>();
builder.Services.AddScoped<IParkManageService, ParkManageService>();
builder.Services.AddScoped<INewsManageService, NewsManageService>();
builder.Services.AddScoped<IAdminManageService, AdminManageService>();
builder.Services.AddScoped<IReviewManageService, ReviewManageService>();
builder.Services.AddDirectoryBrowser();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "StaticFiles")),
    RequestPath = "/StaticFiles",
    EnableDirectoryBrowsing = true
});

app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyOrigin());
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();