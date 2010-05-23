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

        [Given(@"a class named TestGenericClass<T> exists")]
        public void GivenAClassNamedTestGenericClassTExists()
        {
            typeof(TestGenericClass<>).Name.ShouldEqual("TestGenericClass`1");
        }

        [Given(@"a class named ITestGenericClass<T> exists")]
        public void GivenAClassNamedITestGenericClassTExists()
        {
            typeof(ITestGenericClass<>).Name.ShouldEqual("ITestGenericClass`1");
        }

        [When(@"I call Release")]
        public void WhenICallRelease()
        {
            var serviceLocator = context.Get<IServiceLocator>();
            
            var testingObject = new TestingObject();
            serviceLocator.Release(testingObject);

            context.Set(testingObject);
        }

        [When(@"Resolve<ILazy<TestClass>> is called")]
        public void WhenResolveILazyTestClassIsCalled()
        {
            var serviceLocator = context.Get<IServiceLocator>();
            var lazy = serviceLocator
                .Resolve<ILazy<TestClass>>();
            context.Set(lazy, "result");
        }

        [When(@"I resolve TestGenericClass<string>")]
        public void WhenIResolveTestGenericClassTExists()
        {
            var serviceLocator = context.Get<IServiceLocator>();
            var result = serviceLocator
                .Resolve<TestGenericClass<string>>();
            context.Set(result, "result");
        }

        [When(@"I resolve ITestGenericClass<string>")]
        public void WhenIResolveITestGenericClassTExists()
        {
            var serviceLocator = context.Get<IServiceLocator>();
            var result = serviceLocator
                .Resolve<ITestGenericClass<string>>();
            context.Set(result, "result");
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

        [Then(@"the result should be an implementation of TestClass from the service locator")]
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

        [Then(@"the result should be an implementation of TestGenericClass<string> from the service locator")]
        public void ThenTheResultShouldBeAnImplementationOfTestGenericClassFromTheServiceLocator()
        {
            var result = context.Get<TestGenericClass<string>>("result");
            result.ShouldNotBeNull();
        }

        [Then(@"the result should be an implementation of ITestGenericClass<string> from the service locator")]
        public void ThenTheResultShouldBeAnImplementationOfITestGenericClassStringFromTheServiceLocator()
        {
            var result = context.Get<ITestGenericClass<string>>("result");
            result.ShouldNotBeNull();
        }

        [Then(@"the Release call should be invoked")]
        public void ThenTheReleaseCallShouldBeInvoked()
        {
            var testingObject = context.Get<TestingObject>();
            testingObject.Hit.ShouldBeTrue();
        }
    }

    public class TestingObject
    {
        public bool Hit { get; set; }
    }

    public interface ITestGenericClass<T>
    {
    }

    public class TestGenericClass<T> : ITestGenericClass<T>
    {
    }

    public class TestServiceLocator : IServiceLocator
    {
        public object Resolve(Type type)
        {
            if (type == typeof(TestClass))
                return new TestClass();
            if (type == typeof(TestGenericClass<string>))
                return new TestGenericClass<string>();
            if (type == typeof(ITestGenericClass<string>))
                return new TestGenericClass<string>();
            return null;
        }

        public T Resolve<T>() where T : class
        {
            if (typeof(T) == typeof(TestClass))
                return new TestClass() as T;
            if (typeof(T) == typeof(TestGenericClass<string>))
                return new TestGenericClass<string>() as T;
            if (typeof(T) == typeof(ITestGenericClass<string>))
                return new TestGenericClass<string>() as T;
            return null;
        }

        public void Release(object instance)
        {
            (instance as TestingObject).Hit = true;
        }


        #region Implementation of IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IServiceLocator



        public T Resolve<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(Type type) where T : class
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


        public bool ReleaseWasCalled { get; set; }

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