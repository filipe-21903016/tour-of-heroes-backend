using System.Net;

namespace TourOfHeroes.Models
{
    public class TeaPotMiddleware : IMiddleware
    {
        private readonly IConfiguration Configuration;
        public TeaPotMiddleware(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            //var teapot = Configuration["TeaPot"];
            var teapot = Configuration.GetValue<bool?>("TeaPot");

            if (teapot.HasValue && teapot.Value)
            {
                context.Response.StatusCode = 418;
                await context.Response.WriteAsync("");
                return;
            }

            await next(context);
        }
    }

    public static class TeaPotMiddlewareExtensions
    {
        public static IApplicationBuilder UseTeapotMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TeaPotMiddleware>();
        }
    }
}
