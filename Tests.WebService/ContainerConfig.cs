using Autofac;
using Autofac.Features.ResolveAnything;
using DataSeeding.Infrastructure;
using Fourth.Automation.Framework.RestApi;
using Fourth.Automation.SpecFlow.Extensions;
using SpecFlow.Autofac;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Tests.WebService
{
    public class ContainerConfig
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(
                typeof(RestModule).Assembly,
                typeof(SpecFlowModule).Assembly);

            builder.RegisterType<LpHotelsMainUnitOfWork>().As<ILpHotelsMainUnitOfWork>();

            builder.RegisterTypes(typeof(ContainerConfig).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());           

            return builder;
        }
    }
}