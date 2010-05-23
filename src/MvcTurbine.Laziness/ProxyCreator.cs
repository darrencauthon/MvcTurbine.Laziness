using LinFu.DynamicProxy;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
{
    public class ProxyCreator : IProxyCreator
    {
        public IServiceLocator Create(IServiceLocator serviceLocator)
        {
            var factory = new ProxyFactory();
            var interceptor = new ServiceLocatorInterceptor(serviceLocator);
            return factory.CreateProxy<IServiceLocator>(interceptor);
        }
    }
}