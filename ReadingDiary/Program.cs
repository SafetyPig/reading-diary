using ReadingDiary.DB;
using Microsoft.EntityFrameworkCore;
using ReadingDiary.DB.RepositoryInterfaces;
using ReadingDiary.DB.Repositories;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;


builder.Services.AddControllers();

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

builder.Services.AddAuthentication().AddJwtBearer();

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