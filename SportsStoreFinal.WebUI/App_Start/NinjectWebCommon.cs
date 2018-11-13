using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStoreFinal.WebUI.App_Start
{
    public class NinjectWebCommon
    {
        public static void RegisterServices(IKernel kernel)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new SportsStoreFinal.WebUI.Infrastructure.NinjectDependencyResolver(kernel));
        }
    }
}