using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyShop.Customers.DataAccess.Ef;
using OpenIddict.Validation.AspNetCore;
using Qurl.AspNetCore;
using Qurl.SwaggerDefinitions;
using Shared.Auth;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<SessionInfoActionFilter>();
})
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    })
    .AddControllersAsServices();
    //.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<CommandValidator>()); ;

builder.Services.AddDbContext<CustomersContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Customers"),
        o => o.MigrationsHistoryTable("__EFMigrationsHistory", CustomersContext.DbSchema)));

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
});

builder.Services.AddOpenIddict()
    .AddValidation(options =>
    {
        options.SetIssuer(builder.Configuration["Auth:ServerUrl"]);
        options.AddAudiences(builder.Configuration["Auth:ClientId"]);

        options.UseIntrospection()
               .SetClientId(builder.Configuration["Auth:ClientId"])
               .SetClientSecret(builder.Configuration["Auth:ClientSecret"]);

        options.UseSystemNetHttp();

        options.UseAspNetCore();
    });

builder.Services.AddSingleton<ISessionInfo, SessionInfo>();
builder.Services.AddSingleton<SessionInfo>();

builder.Services.AddCors();

builder.Services.AddMediatR(typeof(CustomersContext));

builder.Services.AddQurlModelBinder();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.AddQurlDefinitions());

builder.Services.AddHostedService<InitData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
