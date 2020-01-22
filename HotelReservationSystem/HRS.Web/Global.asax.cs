using Autofac;
using Autofac.Integration.Mvc;
using HRS.Business.Abstract;
using HRS.Business.Concrete;
using HRS.Data.Abstract;
using HRS.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HRS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ReservationService>().As<IReservationService>();
            builder.RegisterType<EfReservationDal>().As<IReservationDal>();
            builder.RegisterType<EfPricingDal>().As<IPricingDal>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }
    }
}
