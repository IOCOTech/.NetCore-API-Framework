using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace APIFramework.API.Helpers.Swagger
{
    public class SwaggerOptionsConfiguration : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider Provider;

        public SwaggerOptionsConfiguration(IApiVersionDescriptionProvider provider)
        {
            Provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in Provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "APIFramework API",
                Version = description.ApiVersion.ToString(),
                Description = "The API to securely access APIFramework data",
                Contact = new OpenApiContact() { Name = "APIFramework", Email = "Weeva@unknown.com" },
                TermsOfService = new System.Uri("https://www.APIFramework.org"),
                License = new OpenApiLicense() { Name = "MIT", Url = new System.Uri("https://opensource.org/licenses/MIT") }
            };
            if (description.IsDeprecated)
            {
                info.Description += "<span style=\"color:red\"> This API version has been deprecated.</span>";
            }

            return info;
        }
    }
}