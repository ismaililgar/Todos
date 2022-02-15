using Microsoft.EntityFrameworkCore;
using Serilog;
using ShoppingApi.Data.Abstract;
using ShoppingApi.Data.Concrete;
using ShoppingApi.DataAccess;
using ShoppingApi.Models;
using Todos.Repository.Abstract;
using Todos.Repository.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Host.UseSerilog((hostingContext, LoggerConfiguration) =>
{
    LoggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
    LoggerConfiguration.WriteTo.Seq("http://localhost:5341/");
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

