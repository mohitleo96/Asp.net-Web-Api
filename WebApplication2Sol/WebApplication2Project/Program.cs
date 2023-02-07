using Microsoft.EntityFrameworkCore;
using WebApplication2Project.Data;
using WebApplication2Project.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency injection Registring dependency in service contanier
builder.Services.AddDbContext<NZWalksDBContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnection"));
    });
//Whenever I ask for the IRegioRrepository interface,
//give me the implementation for the RegionRepository.

builder.Services.AddScoped<IRegionRepository, RegionRepository>();
//It checks the all files where automapper is used.
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
