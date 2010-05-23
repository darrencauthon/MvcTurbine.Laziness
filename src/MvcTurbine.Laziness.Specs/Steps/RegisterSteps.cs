using System;
using System.Collections.Generic;
using MvcTurbine.ComponentModel;
using MvcTurbine.Laziness.Interception;
using MvcTurbine.Laziness.Registration;
using Should;
using SpecFlowAssist;
using TechTalk.SpecFlow;

namespace MvcTurbine.Laziness.Specs.Steps
{
    [Binding]
    internal class RegisterSteps
    {
        private ScenarioContext context
        {
            get { return ScenarioContext.Current; }
        }

        [Given(@"a service locator proxy creator that will create X")]
        public void GivenAServiceLocatorProxyCreatorThatWillCreateX()
        {
            var serviceLocator = new TestRegistrationServiceLocator();
            var expectedLocator = new TestRegistrationServiceLocator();

            var proxyCreator = context.GetMock<IProxyCreator>();
            proxyCreator.Setup(x => x.Create(serviceLocator))
                .Returns(expectedLocator);

            context.Set(serviceLocator, "serviceLocator");
            context.Set(expectedLocator, "expectedLocator");
        }

        [When(@"I have a chance to register things in the service locator")]
        public void WhenIHaveAChanceToRegisterThingsInTheServiceLocator()
        {
            var serviceLocator = context.Get<IServiceLocator>("serviceLocator");
            var lazyServiceRegistration = context.Resolve<LazyServiceRegistration>();
            lazyServiceRegistration.ProxyCreator = context.GetMock<IProxyCreator>().Object;
            lazyServiceRegistration.Register(serviceLocator);
        }

        [Then(@"I should register the X instance with the service locator")]
        public void ThenIShouldRegisterTheXInstanceWithTheServiceLocator()
        {
            var serviceLocator = context.Get<IServiceLocator>("serviceLocator") as TestRegistrationServiceLocator;
            var expectedLocator = context.Get<IServiceLocator>("expectedLocator");
            serviceLocator.RegisteredServiceLocator.ShouldBeSameAs(expectedLocator);
        }
    }

    public class TestRegistrationServiceLocator : IServiceLocator
    {

        public void Register<Interface>(Interface instance) where Interface : class
        {
            if (typeof(Interface) == typeof(IServiceLocator))
                RegisteredServiceLocator = (IServiceLocator)instance;
        }

        public IServiceLocator RegisteredServiceLocator { get; set; }

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

        #endregion
    }
}