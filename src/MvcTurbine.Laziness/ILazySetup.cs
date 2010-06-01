using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
{
    public interface ILazySetup
    {
        bool CanSetup(IServiceLocator serviceLocator);
        void Setup<T>(IServiceLocator serviceLocator) where T : class;
    }
}