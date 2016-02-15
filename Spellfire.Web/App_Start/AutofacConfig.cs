using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Spellfire.BLL;
using Spellfire.Common.Extensions;
using Spellfire.Dal;
using Spellfire.Web.Controllers;
using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
//using Autofac.Integration.WebApi;

namespace Spellfire.Web
{
    /// <summary>
    /// Configuration for the IoC container
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        /// Registers an Autofac Container for use with ASP.NET MVC and Web API
        /// </summary>
        /// <param name="config">the web app configuration</param>
        /// <returns>An Autofac container</returns>
        public static IContainer Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            RegisterDependencies(builder);

            var container = builder.Build();
            //var webApiResolver = new AutofacWebApiDependencyResolver(container);
            var mvcResolver = new AutofacDependencyResolver(container);

            //config.DependencyResolver = webApiResolver;       // Web API
            DependencyResolver.SetResolver(mvcResolver);        // MVC

            return container;
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            // register API and MVC controllers with Autofac
            //builder.RegisterApiControllers(executingAssembly);
            builder.RegisterControllers(executingAssembly).OnActivating(OnControllerActivating);
            builder.RegisterFilterProvider();

            RegisterDal(builder);
            RegisterBll(builder);

            // register HttpContextBase
            builder.Register(c => new HttpContextWrapper(HttpContext.Current)).As<HttpContextBase>().InstancePerRequest();
        }

        private static void RegisterBll(ContainerBuilder builder)
        {
            builder.RegisterType<CardService>().As<ICardService>().InstancePerRequest();
        }

        private static void RegisterDal(ContainerBuilder builder)
        {
            // EF context
            builder.Register(c => new SpellfireContext())
                   .AsSelf()
                   .As<IUnitOfWork>()
                   .InstancePerRequest();

            // Repository Implementations
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .Where(t => t.ImplementsOpenGenericInterface(typeof(IRepository<>)))
                   .AsImplementedInterfaces()
                   .PreserveExistingDefaults()
                   .InstancePerRequest();

            // DAL Gateway
            builder.RegisterType<Spellfire.Dal.DataAccess>()
                   .As<Spellfire.Dal.IDataAccess>()
                   .InstancePerRequest()
                   .PropertiesAutowired();
        }

        /// <summary>
        /// Event handler fired when new MVC controllers are created by the <c>AutoFac</c> container
        /// </summary>
        /// <param name="args">event arguments</param>
        private static void OnControllerActivating(IActivatingEventArgs<object> args)
        {
            // perform property injection/auto-wiring for implementors of BaseController
            if (args.Instance.GetType().IsSubclassOf(typeof(BaseController)))
            {
                args.Context.InjectUnsetProperties(args.Instance);
            }
        }

        private static ILifetimeScope GetAutofacContainer()
        {
            return ((AutofacDependencyResolver)DependencyResolver.Current).ApplicationContainer;
        }

        /// <summary>
        /// Registers a factory method (<c>Func&lt;TKey,TService&gt;</c>) that resolves objects of type
        /// <typeparamref name="TService"/> using a key of type <typeparamref name="TKey"/>
        /// </summary>
        public static IRegistrationBuilder<Func<TKey, TService>, SimpleActivatorData, SingleRegistrationStyle> RegisterFactoryMethod<TKey, TService>(this ContainerBuilder builder)
            where TService : class
        {
            return
                builder.Register<Func<TKey, TService>>(
                    c =>
                    {
                        var ctx = c.Resolve<IComponentContext>();
                        return key => ctx.ResolveOptionalKeyed<TService>(key);
                    });
        }
    }
}
