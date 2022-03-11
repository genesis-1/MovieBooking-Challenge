using ZymLabs.NSwag.FluentValidation;

namespace Skillsbox.Challenge.MovieBooking.API.Config
{
    public static class SwaggerConfig
    {
        /// <summary>
        ///     NSwag for swagger 
        /// </summary>
        /// <param name="services"></param>
        public static void SetupNSwag(this IServiceCollection services)
        {
            // Register the Swagger services
            services.AddOpenApiDocument((options, serviceProvider) =>
            {
                options.DocumentName = "v1";
                options.Title = "SkillsBox Movie Challenge Api v1";
                options.Version = "v1";

                //FluentValidationSchemaProcessor fluentValidationSchemaProcessor = serviceProvider.GetService<FluentValidationSchemaProcessor>();
                // Add the fluent validations schema processor
                //options.SchemaProcessors.Add(fluentValidationSchemaProcessor);

                // Add JWT token authorizatio

            });

            // Add the FluentValidationSchemaProcessor as a singleton
            //services.AddSingleton<FluentValidationSchemaProcessor>();
        }
    }
}
