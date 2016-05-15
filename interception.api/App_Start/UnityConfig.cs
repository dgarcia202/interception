using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace interception.api
{
    using interception.api.Behaviors;
    using interception.api.Controllers;
    using interception.application;

    using Microsoft.Practices.Unity.InterceptionExtension;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddNewExtension<Interception>();

            var defaultInterception = new InjectionMember[]
                                          {
                                            new Interceptor<InterfaceInterceptor>(),
                                            new InterceptionBehavior<LoggingBehavior>()
                                          };

            container.RegisterType<IMessageService, MessageService>(defaultInterception);
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}