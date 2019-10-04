using Autofac;
using Autofac.Features.ResolveAnything;
using Fourth.Automation.Framework.Core;
using Fourth.Automation.Framework.Mobile.Resolvers;
using Fourth.Automation.Framework.Reporting;
using SpecFlow.Autofac;

namespace LPHotels.Automation.Support
{
    public class ContainerConfig
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Artefacts>().As<IArtefacts>();

            DriverFactory.Resolvers.Add(new AndroidResolver());
            DriverFactory.Resolvers.Add(new IOSResolver());

            builder.RegisterInstance(DriverFactory.Create());

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            return builder;
        }
    }
}