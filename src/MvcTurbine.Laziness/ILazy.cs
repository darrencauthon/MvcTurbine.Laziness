using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
{
    public interface ILazy<T> where T : class
    {
        T Value { get; }
    }

}