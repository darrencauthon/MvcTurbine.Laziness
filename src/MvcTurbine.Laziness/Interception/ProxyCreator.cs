using LinFu.DynamicProxy;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
{
    public interface IProxyCreator
    {
        IServiceLocator Create(IServiceLocator serviceLocator);
    }

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