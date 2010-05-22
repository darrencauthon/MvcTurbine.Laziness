namespace MvcTurbine.Laziness
{
    public interface ILazy<T>
    {
        T Value { get; }
    }
}