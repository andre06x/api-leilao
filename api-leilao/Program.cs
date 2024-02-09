using api_leilao.Contracts;
using api_leilao.Filters;
using api_leilao.Repositories;
using api_leilao.Repositories.DataAcess;
using api_leilao.Services;
using api_leilao.UseCases.Leiloes.GetCurrent;
using api_leilao.UseCases.Offers.CreateOffer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT AUTH header using the Bearer scheme.
                        ENTER 'Bearer' [space] and then your token in the text input below.
                        Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"                 
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped < AuthenticationUserAttribute>();
builder.Services.AddScoped < LoggedUser>();
builder.Services.AddScoped < CreateOfferUseCase>();
builder.Services.AddScoped <GetCurrentLeiloesUseCase>();
builder.Services.AddScoped <IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped <IOfferRepository, OfferRepository>();
builder.Services.AddScoped <IUserRepository, UserRepository>();

builder.Services.AddDbContext<AuctionDbContext>(options =>
{
    options.UseSqlite("Data Source=C:\\Users\\andre\\Downloads\\leilaoDbNLW.db");
});
builder.Services.AddHttpContextAccessor();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
