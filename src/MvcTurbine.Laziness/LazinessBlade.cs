using MvcTurbine.Blades;
using MvcTurbine.Ninject;
using MvcTurbine.StructureMap;
using MvcTurbine.Unity;
using MvcTurbine.Windsor;
using Ninject;
using Ninject.Activation;

namespace MvcTurbine.Laziness
{
    public class LazinessBlade : Blade
    {
        public override void Spin(IRotorContext context)
        {
            //SetupUnity(context);

            //SetupStructureMap(context);

            //SetupNinject(context);

            //SetupWindsor(context);
        }

        //private void SetupWindsor(IRotorContext context)
        //{
        //    var serviceLocator = context.ServiceLocator as WindsorServiceLocator;
        //    if (serviceLocator != null)
        //    {
        //        var container = serviceLocator.Container;
        //        container.AddComponent("MvcTurbine.Laziness.ILazy<T>", typeof (ILazy<>), typeof (Lazy<>));
        //    }
        //}

        //private void SetupNinject(IRotorContext context)
        //{
        //    var serviceLocator = context.ServiceLocator as NinjectServiceLocator;
        //    if (serviceLocator != null)
        //    {
        //        var kernel = serviceLocator.Container;

        //        kernel.Bind(typeof (ILazy<>)).ToMethod(ctx =>
        //                                               (ctx.Kernel.Get(typeof (LazyProvider<>).MakeGenericType(ctx.GenericArguments)) as IProvider).Create(ctx));
        //    }
        //}

        //public class LazyProvider<T> : Provider<ILazy<T>> where T : class
        //{
        //    protected override ILazy<T> CreateInstance(IContext context)
        //    {
        //        return new NinjectLazy<T>(() => context.Kernel.Get<T>());
        //    }
        //}

        //private void SetupStructureMap(IRotorContext context)
        //{
        //    var serviceLocator = context.ServiceLocator as StructureMapServiceLocator;
        //    if (serviceLocator != null)
        //    {
        //        var container = serviceLocator.Container;
        //        container.Configure(x => { x.ForRequestedType(typeof (ILazy<>)).TheDefaultIsConcreteType(typeof (Lazy<>)); });
        //    }
        //}

        //private void SetupUnity(IRotorContext context)
        //{
        //    var serviceLocator = context.ServiceLocator as UnityServiceLocator;
        //    if (serviceLocator != null)
        //    {
        //        var container = serviceLocator.Container;
        //        container.RegisterType(typeof (ILazy<>), typeof (Lazy<>));
        //    }
        //}
    }
}