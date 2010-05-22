using System;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
{
    public class Lazy<T> : ILazy<T> where T : class
    {
        private IServiceLocator serviceLocator;

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

        public IServiceLocator ServiceLocator
        {
            set { serviceLocator = value; }
        }
    }
}