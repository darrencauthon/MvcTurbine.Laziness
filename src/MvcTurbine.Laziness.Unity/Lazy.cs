using System;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness.Unity
{
    public class UnityLazy<T> : ILazy<T> where T : class
    {
        private readonly IServiceLocator serviceLocator;

        public UnityLazy(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
            AssertThatTheServiceLocatorExists();
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
            return (T)serviceLocator.Resolve(typeof(T));
        }

        private void AssertThatTheServiceLocatorExists()
        {
            if (serviceLocator == null)
                throw new InvalidOperationException("Must set the service locator.");
        }
    }
}