using Hangfire;

namespace Sender.Api.Infrastructure.StartUpConfigurations
{
    public static class MiddlewareConfiguration
    {
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.MapControllers();

            app.UseHangfireServer();

            app.UseHangfireDashboard();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sender API V1");
            });

            return app;
        }
    }
}
