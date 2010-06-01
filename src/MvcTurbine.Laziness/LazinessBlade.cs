using MvcTurbine.Blades;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
{
    public class LazinessBlade : Blade, ISupportAutoRegistration
    {
        public override void Spin(IRotorContext context)
        {
            var serviceLocator = context.ServiceLocator;
            serviceLocator.ResolveServices<ILazySetup>()
                .ForEach(x =>
                             {
                                 if (x.CanSetup(serviceLocator))
                                     x.Setup(serviceLocator);
                             });
        }

        public void AddRegistrations(AutoRegistrationList registrationList)
        {
            registrationList.Add(
                Registration.Custom<ILazySetup>(RegistrationFilters.DefaultFilter,
                                                (locator, type) => locator.Register<ILazySetup>(type)));
        }
    }
}