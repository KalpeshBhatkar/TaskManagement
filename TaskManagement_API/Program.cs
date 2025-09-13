using Microsoft.EntityFrameworkCore;
using TaskManagement_API;
using TaskManagement_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnString = builder.Configuration.GetConnectionString("DefaultSQLConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnString));

builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile(new MappingConfig());
});

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
