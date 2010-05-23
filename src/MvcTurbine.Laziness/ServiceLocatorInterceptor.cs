using System;
using LinFu.DynamicProxy;
using System.Linq;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
{
    public class ServiceLocatorInterceptor : IInvokeWrapper
    {
        private readonly IServiceLocator serviceLocator;

        public ServiceLocatorInterceptor(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public void BeforeInvoke(InvocationInfo info)
        {
        }

        public object DoInvoke(InvocationInfo info)
        {

            if (info.TargetMethod.ContainsGenericParameters &&
                info.TypeArguments.Count() > 0 &&
                    info.TypeArguments.First().FullName.StartsWith("MvcTurbine.Laziness.ILazy") &&
                    info.TypeArguments.First().GetGenericArguments().Count() > 0)
                return Helpers.CreateLazy(serviceLocator, info.TypeArguments.First().GetGenericArguments().First());

            var genericType = ((Type)info.Arguments.First());
            if (genericType.IsGenericType && genericType.FullName.StartsWith("MvcTurbine.Laziness.ILazy"))
                return Helpers.CreateLazy(serviceLocator, genericType.GetGenericArguments().First());

            return info.TargetMethod.Invoke(serviceLocator, info.Arguments);
        }

        public void AfterInvoke(InvocationInfo info, object returnValue)
        {
        }

    }
}