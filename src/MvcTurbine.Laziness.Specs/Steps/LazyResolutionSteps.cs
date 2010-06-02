using System;
using Moq;
using MvcTurbine.ComponentModel;
using MvcTurbine.Laziness.Ninject;
using MvcTurbine.Laziness.StructureMap;
using MvcTurbine.Laziness.Unity;
using MvcTurbine.Laziness.Windsor;
using MvcTurbine.Ninject;
using MvcTurbine.StructureMap;
using MvcTurbine.Unity;
using MvcTurbine.Windsor;
using Should;
using SpecFlowAssist;
using TechTalk.SpecFlow;

namespace MvcTurbine.Laziness.Specs.Steps
{
    [Binding]
    public class LazyResolutionSteps
    {
        public ScenarioContext context
        {
            get { return ScenarioContext.Current; }
        }

        [Given(@"I have a UnityServiceLocator")]
        public void GivenIHaveAUnityContainer()
        {
            IServiceLocator serviceLocator = new UnityServiceLocator();
            UseThisServiceLocator(serviceLocator);
        }

        [Given(@"I have spun the Laziness blade")]
        public void GivenIHaveSpunTheLazinessBlade()
        {
            var blade = new LazinessBlade();

            var rotorContext = CreateRotorContextFake();

            blade.Spin(rotorContext.Object);
        }

        [Given(@"I have a NinjectServiceLocator")]
        public void GivenIHaveANinjectServiceLocator()
        {
            IServiceLocator serviceLocator = new NinjectServiceLocator();
            UseThisServiceLocator(serviceLocator);
        }

        [Given(@"I have a StructureMapServiceLocator")]
        public void GivenIHaveAStructureMapServiceLocator()
        {
            IServiceLocator serviceLocator = new StructureMapServiceLocator();
            UseThisServiceLocator(serviceLocator);
        }

        [Given(@"I have a WindsorServiceLocator")]
        public void GivenIHaveAWindsorServiceLocator()
        {
            IServiceLocator serviceLocator = new WindsorServiceLocator();
            UseThisServiceLocator(serviceLocator);
        }

        [Given(@"all lazy setup has been done")]
        public void GivenAllLazySetupHasBeenDone()
        {
            var registrationList = new AutoRegistrationList();
            (new LazinessBlade()).AddRegistrations(registrationList);

            var serviceLocator = context.Get<IServiceLocator>();
            IAutoRegistrator registrator = new TestingAutoRegistrator(serviceLocator);
            using (serviceLocator.Batch())
            {
                foreach (var registration in registrationList)
                    registrator.AutoRegister(registration);
            }
        }

        private void UseThisServiceLocator(IServiceLocator serviceLocator)
        {
            using (serviceLocator.Batch())
            {
                serviceLocator.Register(serviceLocator);
                context.Set(serviceLocator);
            }
        }

        [When(@"I resolve an ILazy<Repository>")]
        public void WhenIResolveAnILazyAccount()
        {
            var serviceLocator = context.Get<IServiceLocator>();

            var repository = serviceLocator.Resolve<ILazy<TestRepository>>();

            context.Set(repository);
        }

        [Then(@"I should get an ILazy<Repository>")]
        public void ThenIShouldGetAnILazyAccount()
        {
            context.Get<ILazy<TestRepository>>().ShouldNotBeNull();
        }

        private Mock<IRotorContext> CreateRotorContextFake()
        {
            var rotorContext = new Mock<IRotorContext>();
            rotorContext.Setup(x => x.ServiceLocator)
                .Returns(context.Get<IServiceLocator>());
            return rotorContext;
        }

        public class TestRepository
        {
        }
    }

    public class TestingAutoRegistrator : IAutoRegistrator
    {
        private readonly IServiceLocator serviceLocator;

        public TestingAutoRegistrator(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public void AutoRegister(ServiceRegistration serviceRegistration)
        {
            if (serviceRegistration.ServiceType == typeof (ILazySetup))
            {
                serviceLocator.Register<ILazySetup, StructureMapLazySetup>("StructureMap");
                serviceLocator.Register<ILazySetup, UnityLazySetup>("Unity");
                serviceLocator.Register<ILazySetup, NinjectLazySetup>("Ninject");
                serviceLocator.Register<ILazySetup, WindsorLazySetup>("Windsor");
            }
        }

        public AssemblyFilter Filter
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}