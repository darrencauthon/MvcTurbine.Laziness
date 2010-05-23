using MvcTurbine.ComponentModel;
using MvcTurbine.Laziness.Interception;

namespace MvcTurbine.Laziness.Registration
{
    public class LazyServiceRegistration : IServiceRegistration
    {
        private IProxyCreator proxyCreator;

        public LazyServiceRegistration()
        {
            proxyCreator = new ProxyCreator();
        }

        public IProxyCreator ProxyCreator
        {
            set { proxyCreator = value; }
        }

        public void Register(IServiceLocator locator)
        {
            locator.Register(proxyCreator.Create(locator));
        }
    }
}