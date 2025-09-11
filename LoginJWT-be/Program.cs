using LoginJWT_be;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LoginJWT_DbContext>(options => 
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.WebHost.UseUrls("https://0.0.0.0:7061", "http://192.168.1.71:5089");

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLoginJWT",
        builder => builder.WithOrigins("http://192.168.1.71:5173", "http://localhost:5173")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLoginJWT");

app.UseAuthorization();

app.MapControllers();

app.Run();
