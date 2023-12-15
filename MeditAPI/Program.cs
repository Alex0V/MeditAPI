using Medit.BLL.Interfaces.Services;
using Medit.BLL.Services;
using Medit.DAL.Context;
using Medit.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MeditAPI.UtilityService;
using System.Text;
using WebAPI.Services;
using Medit.DAL.Repositories;
using Medit.DAL.Interfaces.Repositories.Base;
using Medit.DAL.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder => builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MeditDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Add Repositories DI
builder.Services.AddScoped<IMeditationRepository, MeditationRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ICompletedSessionRepository, CompletedSessionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add AutoMapper DI
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add Services DI
builder.Services.AddScoped<IMeditationService, MeditationService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<ICompletedSessionService, CompletedSessionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IRecommendationService, RecommendationService>();
builder.Services.AddScoped<IEmailService, EmailService>();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryverysecret.....")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
