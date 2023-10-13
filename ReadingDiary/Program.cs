using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using ReadingDiary.DB;
using Microsoft.EntityFrameworkCore;
using ReadingDiary.DB.RepositoryInterfaces;
using ReadingDiary.DB.Repositories;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

// Adds Microsoft Identity platform (AAD v2.0) support to protect this Api
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
    {
        builder.Configuration.Bind("AzureAdB2C", options);
    },
    options => { builder.Configuration.Bind("AzureAdB2C", options); });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allowedOrigins = "allowedOrigins";

var hosts = builder.Configuration["AllowedHosts"] ?? "";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
                      policy =>
                      {
                          policy.WithOrigins(hosts);
                          policy.WithHeaders("Authorization", "Content-Type");
                          policy.AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<ReadingDiaryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReadingDiary"))
    .EnableSensitiveDataLogging(true)
    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())));

builder.Services.AddScoped<IDiaryRepository, DiaryRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors(allowedOrigins);

app.Run();