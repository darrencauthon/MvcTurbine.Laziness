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

    public static class Helpers
    {
        public static object CreateLazy(IServiceLocator serviceLocator, Type type)
        {
            var lazyType = typeof (Lazy<>);

            var genericType = lazyType.MakeGenericType(new[]{type});

            var lazy = Activator.CreateInstance(genericType) as INeedAServiceLocator;
            lazy.ServiceLocator = serviceLocator;
            return lazy;
        }
    }
}