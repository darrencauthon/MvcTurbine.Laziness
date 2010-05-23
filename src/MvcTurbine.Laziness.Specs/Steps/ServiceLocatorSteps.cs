using System;
using System.Collections.Generic;
using LinFu.DynamicProxy;
using MvcTurbine.ComponentModel;
using Should;
using SpecFlowAssist;
using TechTalk.SpecFlow;

namespace MvcTurbine.Laziness.Specs.Steps
{
    [Binding]
    public class ServiceLocatorSteps
    {
        private ScenarioContext context
        {
            get { return ScenarioContext.Current; }
        }

        [Given(@"a class named TestClass exists")]
        public void GivenAClassNamedTestClassExists()
        {
            typeof (TestClass).Name.ShouldEqual("TestClass");
        }

        [Given(@"I have been set up to intercept calls to a service locator")]
        public void GivenIHaveBeenSetUpToInterceptCallsToAServiceLocator()
        {
            var factory = new ProxyFactory();
            var actualLocator = new TestServiceLocator();
            var interceptor = new ServiceLocatorInterceptor(actualLocator);
            var locator = factory.CreateProxy<IServiceLocator>(interceptor);

            context.Set(locator);
        }

        [When(@"Resolve<ILazy<TestClass>> is called")]
        public void WhenResolveILazyTestClassIsCalled()
        {
            var serviceLocator = context.Get<IServiceLocator>();
            var lazy = serviceLocator
                .Resolve<ILazy<TestClass>>();
            context.Set(lazy, "result");
        }

        [When(@"Resolve\(typeof\(ILazy<TestClass>\)\) is called")]
        public void WhenResolveTypeofTestClassIsCalled()
        {
            var serviceLocator = context.Get<IServiceLocator>();
            var lazy = serviceLocator
                .Resolve(typeof (ILazy<TestClass>));
            context.Set(lazy, "result");
        }

        [When(@"I resolve TestClass")]
        public void WhenIResolveTestClass()
        {
            var serviceLocator = context.Get<IServiceLocator>();
            var testClass = (TestClass)serviceLocator.Resolve(typeof (TestClass));
            context.Set(testClass);
        }

        [Then(@"the result should be an implementation of TestClasss")]
        public void ThenTheResultShouldBeAnImplementationOfTestClasss()
        {
            var result = context.Get<TestClass>();
            result.ShouldNotBeNull();
        }

        [Then(@"the result should be an implementation of Lazy<TestClass>")]
        public void ThenTheResultShouldBeAnImplementationOfLazyTestClass()
        {
            var result = context.Get<ILazy<TestClass>>("result");
            result.ShouldNotBeNull();
        }
    }

    public class TestServiceLocator : IServiceLocator
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
            if (type == typeof(TestClass))
                return new TestClass();
            return null;
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

    public class TestClass
    {
    }
}