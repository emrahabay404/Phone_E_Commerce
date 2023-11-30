
using Autofac;
using DataAccess.Abstract;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Concrete;
using E_Commerce_Core.Utilities.IoC;
using E_Commerce_Core.Utilities.Security.JWT;
using E_Commerce_DataAccess.Abstract;
using E_Commerce_DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce_Business.DependencyResolvers.Autofac
{
   public class AutoFacBusiness : Module
   {

      protected override void Load(ContainerBuilder builder)
      {

         builder.RegisterType<RedisCacheService>().As<ICacheService>();


         builder.RegisterType<UserManager>().As<IUserService>();
         builder.RegisterType<EfUserDal>().As<IUserDal>();

         builder.RegisterType<AuthManager>().As<IAuthService>();
         builder.RegisterType<JwtHelper>().As<ITokenHelper>();

         builder.RegisterType<CategoryManager>().As<ICategoryService>();
         builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

         builder.RegisterType<ProductManager>().As<IProductService>();
         builder.RegisterType<EfProductDal>().As<IProductDal>();

         builder.RegisterType<BrandManager>().As<IBrandService>();
         builder.RegisterType<EfBrandDal>().As<IBrandDal>();

         builder.RegisterType<ModelManager>().As<IModelService>();
         builder.RegisterType<EfModelDal>().As<IModelDal>();

         builder.RegisterType<VersionManager>().As<IVersionService>();
         builder.RegisterType<EfVersionDal>().As<IVersionDal>();

         builder.RegisterType<OrderManager>().As<IOrderService>();
         builder.RegisterType<EfOrderDal>().As<IOrderDal>();

         builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();
         builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>();

      }

   }
}
