using MediatR;
using System.Reflection;

namespace Skillsbox.Challenge.MovieBooking.API.Config
{
    public static class MediatrConfig
    {
        public static void SetupMediatr(this IServiceCollection services)
        {
            // MediatR, this will scan and register everything that inherits IRequest
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Register MediatR pipeline behaviors, in the same order the behaviors should be called.
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Infrastructure.Behaviours.ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Infrastructure.Behaviours.UnhandledExceptionBehaviour<,>));
        }
    }
}
