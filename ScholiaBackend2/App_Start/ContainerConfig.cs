using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Scholia.Services;
using Scholia.Services.MockDB;
using Scholia.Models.Interfaces;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Scholia.Services.Data;

namespace ScholiaBackend2 {
    public class ContainerConfig {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration) {
            var builder = new ContainerBuilder();


            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterType<SQLAnnotationData>()
                .As<IAnnotationData> ()
                .InstancePerRequest();

            builder.RegisterType<SQLBookData>()
                .As<IBookData>()
                .InstancePerRequest();

            builder.RegisterType<GutenBookData>()
                .As<IBookFetcher>();

            builder.RegisterDecorator<CombinedBookData, IBookFetcher>();


            builder.RegisterType<ScholiaDbContext>().InstancePerRequest();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}