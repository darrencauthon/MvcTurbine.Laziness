using MvcTurbine.ComponentModel;
using MvcTurbine.Ninject;
using Ninject;
using Ninject.Activation;

namespace MvcTurbine.Laziness.Ninject
{
    public class NinjectLazySetup : ILazySetup
    {
        public bool CanSetup(IServiceLocator serviceLocator)
        {
            return serviceLocator.GetType() == typeof (NinjectServiceLocator);
        }

        public void Setup<T>(IServiceLocator serviceLocator) where T : class
        {
            var ninjectServiceLocator = (NinjectServiceLocator)serviceLocator;
            var kernel = ninjectServiceLocator.Container;
            kernel.Bind(typeof (ILazy<>)).ToMethod(ctx =>
                                                   (ctx.Kernel.Get(typeof (LazyProvider<>).MakeGenericType(ctx.GenericArguments)) as IProvider).Create(ctx));
        }

        public class LazyProvider<T> : Provider<ILazy<T>> where T : class
        {
            protected override ILazy<T> CreateInstance(IContext context)
            {
                return new NinjectLazy<T>(() => context.Kernel.Get<T>());
            }
        }
    }
}