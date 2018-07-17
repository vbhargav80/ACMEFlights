using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using ACMEFlights.Core.Interfaces;
using ACMEFlights.Core.Services;
using ACMEFlights.Data;
using Autofac;
using Autofac.Integration.WebApi;

namespace ACMEFlights.API.App_Start
{
    public class AutofacWebapiConfig
    {

        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<MongoRepository>()
                .As<IRepository>();

            builder.RegisterType<FlightAvailabilityService>()
                .As<IFlightAvailabilityService>();

            Container = builder.Build();

            return Container;
        }

    }
}