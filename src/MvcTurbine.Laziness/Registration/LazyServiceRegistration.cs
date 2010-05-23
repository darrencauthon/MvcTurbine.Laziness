using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
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