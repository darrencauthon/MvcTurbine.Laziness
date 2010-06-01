using System;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
{
    public class Lazy<T> : ILazy<T> where T : class
    {
        private readonly IServiceLocator serviceLocator;

        public Lazy(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public T Value
        {
            get
            {
                AssertThatTheServiceLocatorExists();
                return TheValueRetrievedFromTheServiceLocator();
            }
        }

        private T TheValueRetrievedFromTheServiceLocator()
        {
            return (T)serviceLocator.Resolve(typeof (T));
        }

        private void AssertThatTheServiceLocatorExists()
        {
            if (serviceLocator == null)
                throw new InvalidOperationException("Must set the service locator.");
        }
    }

    public class NinjectLazy<T> : ILazy<T> where T : class
    {
        private readonly Func<T> loader;

        public NinjectLazy(Func<T> loader)
        {
            this.loader = loader;
        }

        public T Value
        {
            get { return TheValueRetrievedFromTheServiceLocator(); }
        }

        private T TheValueRetrievedFromTheServiceLocator()
        {
            return loader();
        }
    }
}