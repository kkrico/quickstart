using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using QuickStart.Web.Modules;

namespace QuickStart.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceProvider AsAutoFacServiceProvider(this IServiceCollection serviceCollection)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ApplicationModule>();
            containerBuilder.Populate(serviceCollection);
            IContainer container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}