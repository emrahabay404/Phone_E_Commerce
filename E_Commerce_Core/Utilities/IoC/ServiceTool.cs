using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce_Core.Utilities.IoC
{
   public static class ServiceTool
   {
      public static IContainer AutofacServiceProvider { get; set; }

      public static IServiceProvider ServiceProvider { get; private set; }

      public static IServiceCollection Create(IServiceCollection services)
      {
         ServiceProvider = services.BuildServiceProvider();

         return services;
      }

      public static T GetInstance<T>()
      {
         using var scope = ServiceTool.AutofacServiceProvider
             .BeginLifetimeScope();

         return scope.Resolve<T>();
      }
   }
}
