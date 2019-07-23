using System;
using System.Linq;
using System.Reflection;
using Autofac;
using QuickStart.Shared.Abstractions.Core.Bus;
using Module = Autofac.Module;

namespace QuickStart.Web.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var coreAssembly = typeof(QuickStart.Core.PublicAPI).Assembly;
            var appAssembly = typeof(MediatorHandler).Assembly;
            var sharedAssembly = typeof(QuickStart.Shared.GuardClause.Guard).Assembly;

            var assembliesToRegister = new[] {coreAssembly, appAssembly, sharedAssembly};
            builder.RegisterAssemblyTypes(assembliesToRegister)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}