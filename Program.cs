using Booking_System.Models;
using Booking_System.Represent;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "";
builder.Services.AddControllers();
builder.Services.AddDbContext<BookingContext>(o=>o.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("BookingSystem")));
builder.Services.AddScoped<Room_context, Serviecs_Room>();
builder.Services.AddScoped<Branch_context, Serviecs_Branch>();
builder.Services.AddScoped<BooKing_Contexts, Booking_Services>();
builder.Services.AddScoped<Gust_Conext, Gust_Serviescs>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.MapControllers();

app.Run();
