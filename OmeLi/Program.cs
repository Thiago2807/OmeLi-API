using Microsoft.EntityFrameworkCore;
using OmeLi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string stringConnection = builder.Configuration.GetConnectionString("ConexaoLocal");
//string stringConnection = builder.Configuration.GetConnectionString("ConexaoNuvem");

builder.Services.AddDbContext<BDContext>(options => options.UseSqlServer(stringConnection));

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
