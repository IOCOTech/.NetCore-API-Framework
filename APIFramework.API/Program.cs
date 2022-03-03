using APIFramework.API.Configuration.Startup;
using APIFramework.API.Helpers;
using APIFramework.API.Helpers.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();

builder.Services.AddHttpClient();

var corsOriginsAllowed = builder.Configuration.GetValue<string>("corsOriginsAllowed");
builder.Services.AddCors(options =>
{
    string[] methods = { "GET", "POST", "PUT", "DELETE", "PATCH", "OPTIONS" };
    options.AddPolicy("AllowFrontend", builder => builder.WithOrigins("*").AllowAnyHeader().WithMethods(methods));
});

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptionsConfiguration>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.OperationFilter<SwaggerDefaultValues>();
    c.ResolveConflictingActions(c => c.First());
});

builder.Services.ConfigureDependencyInjection();

var test = builder.Environment.IsDevelopment();

builder.Services.AddApiVersioning(options =>
{
    // reporting api versions will return the headers "api-supported-versions"
    // and "api-deprecated-versions"
    options.ReportApiVersions = true;
    //Only version [ApiController] defaults to true in 3.1+
    options.UseApiBehavior = true;


    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(2, 0);

    //This sets the default svc? api-version = 2.0 and svc?v = 2.0
    options.ApiVersionReader = ApiVersionReader.Combine(new QueryStringApiVersionReader(), new HeaderApiVersionReader("api-version"));
});

builder.Services.AddVersionedApiExplorer(
           options =>
           {
               // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
               // note: the specified format code will format the version as "'v' major[.minor][-status]"
               options.GroupNameFormat = "'v'VVV";
               // note: this option is only necessary when versioning by URL segment. the SubstitutionFormat
               // can also be used to control the format of the API version in route templates
               options.SubstituteApiVersionInUrl = true;
           });
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.OperationFilter<SwaggerDefaultValues>();
    c.ResolveConflictingActions(c => c.First());
});

if (builder.Environment.IsDevelopment())
{

    Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions aiOptions = new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions();
    aiOptions.DeveloperMode = true;
    builder.Services.AddApplicationInsightsTelemetry(aiOptions);
}
else
{
    builder.Services.AddApplicationInsightsTelemetry();
}

var app = builder.Build();

ApplicationLogging.LoggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

using (var scope = app.Services.CreateScope())
{
    var versionProvider = scope.ServiceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FullSwaggerSupport v1"));
    app.UseSwaggerUI(
        options =>
        {
            // build a swagger endpoint for each discovered API version
            foreach (var description in versionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
            }
        });
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.ConfigureExceptionHandler();

// If you need to seed data in your application on startup add it here
// app.SeedData();

app.Run();













//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
