using System;
using System.Collections.Generic;
using System.Linq;
using LinFu.DynamicProxy;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.Laziness
{
    public class ServiceLocatorInterceptor : IInvokeWrapper
    {
        private const string LazyId = "MvcTurbine.Laziness.ILazy";
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
            if (ACallToResolveIsBeingMade(info))
            {
                if (AttemptingToResolveAGeneric(info) && AttemptingToResolveALazy(info))
                    return CreateALazyWithTheGenericArgument(info);

                if (AnArgumentWasPassedToResolve(info))
                {
                    var type = GetTheTypeAttemptingToResolve(info);
                    if (ThisIsALazyType(type))
                        return CreateALazyWithTheNonGenericArgument(type);
                }
            }

            return InvokeTheMethodAsItNormallyWouldBeInvoked(info);
        }

        private static bool AttemptingToResolveALazy(InvocationInfo info)
        {
            return info.TypeArguments.Count() > 0 &&
                   info.TypeArguments.First().FullName.StartsWith(LazyId) &&
                   info.TypeArguments.First().GetGenericArguments().Count() > 0;
        }

        private object InvokeTheMethodAsItNormallyWouldBeInvoked(InvocationInfo info)
        {
            if (info.TargetMethod.ContainsGenericParameters)
            {
                var genericArguments = GetTheGenericArguments(info);

                return info.TargetMethod
                    .MakeGenericMethod(genericArguments.ToArray())
                    .Invoke(serviceLocator, info.Arguments);
            }

            return info.TargetMethod.Invoke(serviceLocator, info.Arguments);
        }

        private static IEnumerable<Type> GetTheGenericArguments(InvocationInfo info)
        {
            return from typeArgument in info.TypeArguments
                   where typeArgument.IsGenericType
                   group typeArgument by typeArgument
                   into g
                   select g.Key;
        }

        private object CreateALazyWithTheNonGenericArgument(Type type)
        {
            return Helpers.CreateLazy(serviceLocator, type.GetGenericArguments().First());
        }

        private static bool ThisIsALazyType(Type type)
        {
            return type.IsGenericType && type.FullName.StartsWith(LazyId);
        }

        private static Type GetTheTypeAttemptingToResolve(InvocationInfo info)
        {
            return ((Type)info.Arguments.First());
        }

        private static bool AnArgumentWasPassedToResolve(InvocationInfo info)
        {
            return info.Arguments.Count() > 0;
        }

        private object CreateALazyWithTheGenericArgument(InvocationInfo info)
        {
            return Helpers.CreateLazy(serviceLocator, info.TypeArguments.First().GetGenericArguments().First());
        }

        private static bool AttemptingToResolveAGeneric(InvocationInfo info)
        {
            return info.TargetMethod.ContainsGenericParameters;
        }

        private static bool ACallToResolveIsBeingMade(InvocationInfo info)
        {
            return info.TargetMethod.Name.StartsWith("Resolve");
        }

        public void AfterInvoke(InvocationInfo info, object returnValue)
        {
        }
    }
}