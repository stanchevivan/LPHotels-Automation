using System;
using System.Configuration;
using System.Linq;
using Autofac;
using RestSharp;
using TechTalk.SpecFlow;
using SpecFlow.Autofac;
using Fourth.Automation.Messaging;
using Fourth.TH.Automation.RestDriver;
using Fourth.Orchestration.Storage;
using Fourth.Orchestration.Messaging;
using Fourth.Orchestration.Messaging.Azure;
using Fourth.Orchestration.Storage.Azure;
using Autofac.Features.ResolveAnything;
using Tests.API.Infrastructure;

namespace Tests.API.Setup
{
    public class ContainerConfig
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            // create container with the runtime dependencies
            var builder = new ContainerBuilder();
            builder.RegisterModule<MessagingModule>();

            builder
                .RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute)))
                .SingleInstance();

            if (ScenarioContext.Current != null)
            {
                builder.RegisterInstance(ScenarioContext.Current).AsSelf().As<SpecFlowContext>();
            }

            var baseUrl = ConfigurationManager.AppSettings["BaseUrl"];

            builder.RegisterInstance(new RestDriver(new RestClient(), baseUrl)).As<IRestDriver>();
            //builder.RegisterInstance(new LoginDataContext());
            //builder.RegisterType<LoginUnitOfWork>().As<ILoginUnitOfWork>();
            builder.RegisterType<LpHotelsMainUnitOfWork>().As<ILpHotelsMainUnitOfWork>();
            //builder.RegisterType<SqlContextFactory>().As<IContextFactory>();
            builder.RegisterType<AnyConcreteTypeNotAlreadyRegisteredSource>();
            builder.RegisterType<AzureMessageStore>().As<IMessageStore>().UsingConstructor();
            builder.RegisterType<AzureMessagingFactory>().As<IMessagingFactory>().UsingConstructor(typeof(IMessageStore));
           // builder.RegisterType<EventEmitter>().As<IEventEmitter>();

            return builder;
        }
    }
}
