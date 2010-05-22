namespace MvcTurbine.Laziness
{
    public class Lazy<T> : ILazy<T>
    {
        public T Value { get; set; }
    }
}