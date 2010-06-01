//using System;
//using System.Collections.Generic;
//using MvcTurbine.ComponentModel;
//using NUnit.Framework;
//using Should;

//namespace MvcTurbine.Laziness.Ninject.Tests
//{
//    [TestFixture]
//    public class NinjectLazyTests
//    {
//        [Test]
//        public void Throws_an_invalid_operation_exception_when_called_without_setting_the_service_locator()
//        {
//            var correctExceptionThrown = false;
//            try
//            {
//                var lazy = new Lazy<TestClass>(null);
//            }
//            catch (InvalidOperationException exception)
//            {
//                if (exception.Message == "Must set the service locator.")
//                    correctExceptionThrown = true;
//            }

//            correctExceptionThrown.ShouldBeTrue();
//        }

//        [Test]
//        public void Does_not_throw_an_invalid_operation_exception_if_the_service_locator_is_set()
//        {
//            var lazy = new Lazy<TestClass>(new TestServiceLocator());
//            var value = lazy.Value;
//        }

//        [Test]
//        public void Returns_the_resolved_value_from_the_service_locator()
//        {
//            var expectedTestClass = new TestClass();

//            var serviceLocator = new TestServiceLocator();
//            serviceLocator.SetServiceLocatorToReturnThisWhenResolvingTestClass(expectedTestClass);

//            var lazy = new Lazy<TestClass>(serviceLocator);

//            lazy.Value.ShouldBeSameAs(expectedTestClass);
//        }
//    }

//    public class TestClass
//    {
//    }

//    public class TestServiceLocator : IServiceLocator
//    {
//        private TestClass testClass;

//        public void SetServiceLocatorToReturnThisWhenResolvingTestClass(TestClass testClass)
//        {
//            this.testClass = testClass;
//        }

//        #region Implementation of IDisposable

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }

//        #endregion

//        #region Implementation of IServiceLocator

//        public T Resolve<T>() where T : class
//        {
//            throw new NotImplementedException();
//        }

//        public T Resolve<T>(string key) where T : class
//        {
//            throw new NotImplementedException();
//        }

//        public T Resolve<T>(Type type) where T : class
//        {
//            throw new NotImplementedException();
//        }

//        public object Resolve(Type type)
//        {
//            if (type == typeof(TestClass))
//                return testClass;
//            return null;
//        }

//        public IList<T> ResolveServices<T>() where T : class
//        {
//            throw new NotImplementedException();
//        }

//        public IServiceRegistrar Batch()
//        {
//            throw new NotImplementedException();
//        }

//        public void Register<Interface>(Type implType) where Interface : class
//        {
//            throw new NotImplementedException();
//        }

//        public void Register<Interface, Implementation>() where Implementation : class, Interface
//        {
//            throw new NotImplementedException();
//        }

//        public void Register<Interface, Implementation>(string key) where Implementation : class, Interface
//        {
//            throw new NotImplementedException();
//        }

//        public void Register(string key, Type type)
//        {
//            throw new NotImplementedException();
//        }

//        public void Register(Type serviceType, Type implType)
//        {
//            throw new NotImplementedException();
//        }

//        public void Register<Interface>(Interface instance) where Interface : class
//        {
//            throw new NotImplementedException();
//        }

//        public void Release(object instance)
//        {
//            throw new NotImplementedException();
//        }

//        public void Reset()
//        {
//            throw new NotImplementedException();
//        }

//        public TService Inject<TService>(TService instance) where TService : class
//        {
//            throw new NotImplementedException();
//        }

//        public void TearDown<TService>(TService instance) where TService : class
//        {
//            throw new NotImplementedException();
//        }

//        #endregion
//    }
//}