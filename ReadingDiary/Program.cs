using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using ReadingDiary.DB;
using Microsoft.EntityFrameworkCore;
using ReadingDiary.DB.RepositoryInterfaces;
using ReadingDiary.DB.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

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
                      });
});


builder.Services.AddDbContext<ReadingDiaryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReadingDiary")));


builder.Services.AddScoped<IDiaryRepository, DiaryRepository>();

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

app.UseCors(allowedOrigins);

app.Run();