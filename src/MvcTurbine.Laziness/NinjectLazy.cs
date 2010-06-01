using System;

namespace MvcTurbine.Laziness
{
    public class NinjectLazy<T> : ILazy<T> where T : class
    {
        private readonly Func<T> loader;

        public NinjectLazy(Func<T> loader)
        {
            this.loader = loader;
        }

        public T Value
        {
            get { return TheValueRetrievedFromTheServiceLocator(); }
        }

        private T TheValueRetrievedFromTheServiceLocator()
        {
            return loader();
        }
    }
}