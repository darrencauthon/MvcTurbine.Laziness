using System;
using MvcTurbine.ComponentModel;
using MvcTurbine.Windsor;

namespace MvcTurbine.Laziness.Windsor
{
    public class WindsorLazySetup : ILazySetup
    {
        public bool CanSetup(IServiceLocator serviceLocator)
        {
            return serviceLocator.GetType() == typeof (WindsorServiceLocator);
        }

        public void Setup<T>(IServiceLocator serviceLocator) where T : class
        {
            var windsorServiceLocator = (WindsorServiceLocator)serviceLocator;
            var container = windsorServiceLocator.Container;
            container.AddComponent("MvcTurbine.Laziness.ILazy<T>", typeof(ILazy<>), typeof(WindsorLazy<>));
        }
    }
}