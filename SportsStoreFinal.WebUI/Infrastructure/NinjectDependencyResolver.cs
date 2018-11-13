using Moq;
using Ninject;
using SportsStoreFinal.Domain.Abstract;
using SportsStoreFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStoreFinal.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
                {
                    new Product { Category = "Cat 1" , Description = "Desc 1", Name = "Name 1", Price = 1, ProductId = 1},
                    new Product { Category = "Cat 2" , Description = "Desc 2", Name = "Name 2", Price = 2, ProductId = 2},
                    new Product { Category = "Cat 2" , Description = "Desc 3", Name = "Name 3", Price = 3, ProductId = 3},
                    new Product { Category = "Cat 3" , Description = "Desc 4", Name = "Name 4", Price = 4, ProductId = 4},
                    new Product { Category = "Cat 3" , Description = "Desc 5", Name = "Name 5", Price = 5, ProductId = 5}
                });
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}