using HouseCostMonitor.Application.Extensions;
using HouseCostMonitor.Infrastructure.Extensions;

namespace HouseCostMonitor.API;

using System.Text.Json.Serialization;
using HouseCostMonitor.API.Middlewares;
using Microsoft.OpenApi.Models;
using Serilog;

public static class DependencyInjection
{
    public static void RegisterDependencyInjection(this WebApplicationBuilder builder, IConfiguration config)
    {
        builder.Services.AddAuthentication();
        builder.Services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        
        builder.Services.AddScoped<TimeLoggingMiddleware>();
        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference() { Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
                    },
                    []
                }
            });
        });
        builder.Services.AddHttpContextAccessor();
        
        builder.Services.AddInfrastructure(config);
        builder.Services.AddApplication();
        builder.Host.UseSerilog((context, cfg) => cfg.ReadFrom.Configuration(context.Configuration));
    }

    public static void AddSwagger(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "HouseCostMonitor API V1");
        });
    }
}