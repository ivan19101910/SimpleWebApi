using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleWebApi;
using SimpleWebApi.DAL;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DatabaseConection");

builder.Services.AddDbContext<ApiDBContext>(e => e.UseSqlServer(connection));
// Add services to the container.

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
