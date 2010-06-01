using System;
using System.Collections.Generic;
using MvcTurbine.ComponentModel;
using MvcTurbine.Ninject;
using NUnit.Framework;
using Should;

namespace MvcTurbine.Laziness.Ninject.Tests
{
    [TestFixture]
    public class NinjectLazySetupTests
    {
        [Test]
        public void Cannot_setup_if_the_service_locator_is_not_a_NinjectServiceLocator()
        {
            var setup = new NinjectLazySetup();
            var result = setup.CanSetup(new SetupServiceLocator());
            result.ShouldBeFalse();
        }

        [Test]
        public void Can_setup_if_the_service_locator_is_a_NinjectServiceLocator()
        {
            var setup = new NinjectLazySetup();
            var result = setup.CanSetup(new NinjectServiceLocator());
            result.ShouldBeTrue();
        }
    }

    public class SetupServiceLocator : IServiceLocator
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public IList<T> ResolveServices<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public IServiceRegistrar Batch()
        {
            throw new NotImplementedException();
        }

        public void Register<Interface, Implementation>() where Implementation : class, Interface
        {
            throw new NotImplementedException();
        }

        public void Register<Interface, Implementation>(string key) where Implementation : class, Interface
        {
            throw new NotImplementedException();
        }

        public void Register<Interface>(Interface instance) where Interface : class
        {
            throw new NotImplementedException();
        }

        public void Release(object instance)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public TService Inject<TService>(TService instance) where TService : class
        {
            throw new NotImplementedException();
        }

        public void TearDown<TService>(TService instance) where TService : class
        {
            throw new NotImplementedException();
        }

        public void Register(Type serviceType, Type implType)
        {
            throw new NotImplementedException();
        }

        public void Register(string key, Type type)
        {
            throw new NotImplementedException();
        }

        public void Register<Interface>(Type implType) where Interface : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(Type type) where T : class
        {
            throw new NotImplementedException();
        }
    }
}