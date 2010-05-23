using MvcTurbine.ComponentModel;
using MvcTurbine.Laziness.Interception;

namespace MvcTurbine.Laziness.Registration
{
    public class LazyServiceRegistration : IServiceRegistration
    {
        private readonly IProxyCreator proxyCreator;

        public LazyServiceRegistration(IProxyCreator proxyCreator)
        {
            this.proxyCreator = proxyCreator;
        }

        public void Register(IServiceLocator locator)
        {
            locator.Register(proxyCreator.Create(locator));
        }
    }
}