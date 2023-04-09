using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using q5_risk_api.Interfaces;
using q5_risk_api.Services;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["OAuth:Authority"];
        options.Audience = builder.Configuration["OAuth:Audience"];
        options.RequireHttpsMetadata = false;
    });

builder.Services.AddHttpClient();

// Register Dependency Containers - External Services
builder.Services.AddTransient<IExternalService, ExternalService>();

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Risk Analysis API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Risk Analysis API v1");
    c.RoutePrefix = "swagger";
});

app.MapControllers();
//
// app.MapGet("/api/risk-analysis/{parameter}", async (ExternalService externalService, string parameter, HttpContext httpContext) =>
// {
//     var url = "https://external-service.example.com"; // Replace with the URL of the external service.
//     var parameterName = "parameter"; // Replace with the actual parameter name expected by the external service.
//
//     var result = await externalService.PostAsync<dynamic>();
//     httpContext.Response.ContentType = "application/json";
//     await httpContext.Response.WriteAsync(result.ToString());
// });

app.Run();
