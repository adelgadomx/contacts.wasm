using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using repositories;

var builder = WebApplication.CreateBuilder(args);

// CORS
string MyPolicy = "MyPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyPolicy,
        policy =>
        {
            // policy.WithOrigins("http://localhost").WithMethods("PUT", "DELETE", "GET");
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

 // Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependencies 
builder.Services.AddScoped<IDbConnection>( (sp) => new SqlConnection(builder.Configuration.GetConnectionString("ContactsDB")));
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors(MyPolicy);

app.UseAuthorization();

app.Run();