using MvcTurbine.ComponentModel;
using MvcTurbine.Unity;

namespace MvcTurbine.Laziness.Unity
{
    public class UnityLazySetup : ILazySetup
    {
        public bool CanSetup(IServiceLocator serviceLocator)
        {
            return serviceLocator.GetType() == typeof (UnityServiceLocator);
        }

        public void Setup<T>(IServiceLocator serviceLocator) where T : class
        {
            var unityServiceLocator = (UnityServiceLocator)serviceLocator;
            var container = unityServiceLocator.Container;
            container.RegisterType(typeof (ILazy<>), typeof (UnityLazy<>));
        }
    }
}