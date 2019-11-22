using System;
using System.Configuration;
using System.Linq;
using Autofac;
using TechTalk.SpecFlow;
using Autofac.Features.ResolveAnything;
using SpecFlow.Autofac;
using DataSeeding.Infrastructure;

namespace DataSeeding
{
    public class ContainerConfig
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            // create container with the runtime dependencies
            var builder = new ContainerBuilder();

            builder
                .RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute)))
                .SingleInstance();

            var baseUrl = ConfigurationManager.AppSettings["BaseUrl"];

            builder.RegisterType<LpHotelsMainUnitOfWork>().As<ILpHotelsMainUnitOfWork>();
            builder.RegisterType<LpHotelsDbContext>().As<LpHotelsDbContext>();
            
            builder.RegisterType<AnyConcreteTypeNotAlreadyRegisteredSource>();

            return builder;
        }
    }
}
