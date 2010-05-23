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

            if (info.TargetMethod.Name.StartsWith("Resolve"))
            {
                if (info.TargetMethod.ContainsGenericParameters &&
                    info.TypeArguments.Count() > 0 &&
                        info.TypeArguments.First().FullName.StartsWith("MvcTurbine.Laziness.ILazy") &&
                        info.TypeArguments.First().GetGenericArguments().Count() > 0)
                    return Helpers.CreateLazy(serviceLocator, info.TypeArguments.First().GetGenericArguments().First());

                if (info.Arguments.Count() > 0)
                {
                    var genericType = ((Type)info.Arguments.First());
                    if (genericType.IsGenericType && genericType.FullName.StartsWith("MvcTurbine.Laziness.ILazy"))
                        return Helpers.CreateLazy(serviceLocator, genericType.GetGenericArguments().First());
                }
            }

            if (info.TargetMethod.ContainsGenericParameters)
            {
                var genericArguments = from typeArgument in info.TypeArguments
                                       where typeArgument.IsGenericType
                                       group typeArgument by typeArgument
                                           into g
                                           select g.Key;

                return info.TargetMethod
                    .MakeGenericMethod(genericArguments.ToArray())
                    .Invoke(serviceLocator, info.Arguments);
            }

            return info.TargetMethod.Invoke(serviceLocator, info.Arguments);
        }

        public void AfterInvoke(InvocationInfo info, object returnValue)
        {
        }

    }
}