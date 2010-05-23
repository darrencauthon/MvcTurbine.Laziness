using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
{
    public interface IProxyCreator
    {
        IServiceLocator Create(IServiceLocator serviceLocator);
    }
}