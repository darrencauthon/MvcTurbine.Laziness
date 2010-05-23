using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMoq;
using MvcTurbine.ComponentModel;
using NUnit.Framework;
using Should;

namespace MvcTurbine.Laziness.Tests
{
    [TestFixture]
    public class ProxyCreatorTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void TestSetup()
        {
            mocker = new AutoMoqer();
        }

        [Test]
        public void Returns_a_proxy_instance()
        {
            var proxyCreator = mocker.Resolve<ProxyCreator>();
            var proxy = proxyCreator.Create(new TestProxyServiceLocator());
            proxy.GetType().Name.ShouldNotBeNull();
            proxy.GetType().Name.ShouldNotEqual(typeof (TestProxyServiceLocator).Name);
        }
    }

    public class TestProxyServiceLocator : IServiceLocator
    {
        #region Implementation of IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IServiceLocator

        public T Resolve<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(Type type) where T : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
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

        public void Register<Interface>(Type implType) where Interface : class
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

        public void Register(string key, Type type)
        {
            throw new NotImplementedException();
        }

        public void Register(Type serviceType, Type implType)
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

        #endregion
    }
}
