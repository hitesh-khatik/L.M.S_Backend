using DatabaseManagement_Using_Linq.InterFace;
using DatabaseManagement_Using_Linq.Model;
using DatabaseManagement_Using_Linq.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidIssuer = builder.Configuration["Jwt : Issuer"],
          ValidAudience = builder.Configuration["Jwt : Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
     };
 });
builder.Services.AddDbContext<DataDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connSql")));

builder.Services.AddControllers();

builder.Services.AddTransient<IRegister , RegisterService>();
builder.Services.AddTransient<ILogin , LoginService>();
builder.Services.AddTransient<IBooksCategory, BooksCategoryService>();
builder.Services.AddTransient<IBooks, BooksService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
              builder.WithOrigins("http://localhost:3000")
             .AllowAnyMethod()
             .AllowAnyHeader();
        });
});
https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
