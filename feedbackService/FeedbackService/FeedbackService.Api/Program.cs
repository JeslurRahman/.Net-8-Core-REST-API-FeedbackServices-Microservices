using FeedbackService.Api.Helper;
using FeedbackService.Api;
using NLog;
using NLog.Extensions.Logging;
using FeedbackService.Api.Middlewares;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using HealthChecks.UI.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Moved to SwaggerConfiguration.cs
/*
builder.Services.AddSwaggerGen();
*/

//Configuring SwaggerConfiguration.cs
builder.Services.ConfigureSwagger();

//Configureing ServiceExtention.cs which is used for other configuration separately
builder.Services.ConfigureCors();

//Configuring DependancyInjection.cs file which used for Dependancy Injection separatedly
builder.Services.ConfigureDependencyInjection(builder.Environment, builder.Configuration);

//Add AddNewtonsoftJason
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
});

//Set the Json Serializer options:
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

//Configuring KeyVaultCache.cs file which used for Dependancy Injection separatedly
builder.Services.ConfigureKeyVaultCache(builder.Environment, builder.Configuration);

//AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(MapperProfile));

//Routing Configuration to 
builder.Services.AddRouting(option => option.LowercaseUrls = true);

//Congiguring Health Ckeck
//Commented for deploy in Azure app service
/*builder.Services.ConfigureHealthChecks(builder.Configuration);*/

//configuration setup
//The code you provided is responsible for loading configuration settings based on the current environment.
string currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
IConfigurationBuilder configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, reloadOnChange: true) ;

if(currentEnvironment ?.Equals("Development", StringComparison.OrdinalIgnoreCase) == true)
{
    configBuilder.AddJsonFile($"appsettings.{currentEnvironment}.json", optional: false);
}

//Logger Configuration
IConfigurationRoot config = configBuilder.Build();
LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
Logger logger = LogManager.GetCurrentClassLogger();

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Moved to SwaggerConfiguration.cs
    /*
     app.UseSwagger();
     app.UseSwaggerUI();
    */
    
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHttpCodeAndLogMiddleware();
    app.UseHsts();
}

//Configure SwaggerConfiguration.cs
//app.ConfigureSwagger();
app.ConfigureSwagger(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//HealthCheck Middleware
//Commented for deploy in Azure app service
/*
app.MapHealthChecks("/api/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseHealthChecksUI(delegate (Options options) 
{
    options.UIPath = "/healthcheck-ui";
    options.AddCustomStylesheet("./HealthCheck/Custom.css");

});
*/
app.Run();
