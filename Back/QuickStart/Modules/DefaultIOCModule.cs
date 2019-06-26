    using System;
using System.Collections.Generic;
using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Autofac;
    using MediatR;
    using MediatR.Pipeline;
    using QuickStart.Core.Services;
    using Module = Autofac.Module;

    namespace QuickStart.Web.Modules
{
    public class DefaultIocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Core.Services.DemoService).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(Web.Startup).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
