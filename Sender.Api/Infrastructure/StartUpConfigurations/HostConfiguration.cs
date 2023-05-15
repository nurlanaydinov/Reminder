// Copyright (C) TBC Bank. All Rights Reserved.

using Serilog;

namespace Sender.Api.Infrastructure.StartUpConfigurations
{
    public static class HostConfiguration
    {
        public static WebApplicationBuilder ConfigureHost(this WebApplicationBuilder builder)
        {
            // We should store secrets in separate configuration file, appsecrets.json.
            // When deployed in Docker & K8s, appsecrets.json file content will be loaded from Key Vault (e.g. HashiCorp Vault, Azure Key Vault)
            // and appsecrets.json file with secrets will be mounted directly in docker container.
            // Dot not store appsecrets.json file in source control, because it contains sensitive information.
            builder.Configuration.AddJsonFile("appsecrets.json", optional: true, reloadOnChange: true);

            // Add fully-configured logger.
            //builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
            //    .ReadFrom.Configuration(hostingContext.Configuration)
            //    .Enrich.FromLogContext());

            return builder;
        }
    }
}
