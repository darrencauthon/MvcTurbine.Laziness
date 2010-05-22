using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
{
    public interface ILazy<T> : INeedAServiceLocator
    {
        T Value { get; }
    }

    public interface INeedAServiceLocator
    {
        IServiceLocator ServiceLocator { set; }
    }
}