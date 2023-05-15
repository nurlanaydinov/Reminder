using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sender.Application;
using Sender.Application.Common;
using Sender.Application.Email;
using Sender.Application.Exceptions;
using Sender.Application.Interfaces;
using Sender.Application.Telegram;
using Sender.Persistence;
using Sender.Persistence.Repositories;

namespace Sender.Api.Infrastructure.StartUpConfigurations
{
    public static class ServiceConfigurations
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddScoped<ISenderRepository, SenderRepository>();
            builder.Services.AddScoped<IValidator, Validator>();
            builder.Services.AddScoped<IReminderScheduler, ReminderScheduler>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.AddTransient<ITelegramMessageSender, TelegramMessageSender>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmailCommandHandler).Assembly));
            builder.Services.AddHangfire(x => x.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddHangfireServer();


            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sender API", Version = "v1" });
            });

            return builder;
        }
    }
}
