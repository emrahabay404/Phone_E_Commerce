using AutoMapper;
using Castle.Core.Resource;
using E_Commerce_Core.Entities.Concrete;
using E_Commerce_Core.Entities.DTOs;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;
using E_Commerce_Entity.DTOs.User;
using Version = E_Commerce_Entity.Concrete.Version;

namespace E_Commerce_Business.Mapping
{
   public class GeneralMapping : Profile
   {
      public GeneralMapping()
      {
         CreateMap<User, UserForRegisterDto>();
         CreateMap<UserForRegisterDto, User>();
         CreateMap<int, User>().ConvertUsing(_userID => new User { UserId = _userID });

         CreateMap<User, UserDto>();
         CreateMap<UserDto, User>();
         CreateMap<int, User>().ConvertUsing(_userID => new User { UserId = _userID });

         CreateMap<OrderDetail, OrderDetailDto>();
         CreateMap<OrderDetailDto, OrderDetail>();
         //CreateMap<int, OrderDetail>().ConvertUsing(_orderID => new OrderDetail { OrderID = _orderID });
         CreateMap<int, OrderDetail>().ConvertUsing(_orderDetailID => new OrderDetail { OrderDetailId = _orderDetailID });

         CreateMap<Order, OrderDto>();
         CreateMap<OrderDto, Order>();
         CreateMap<int, Order>().ConvertUsing(_orderID => new Order { OrderID = _orderID });
         //CreateMap<int, Order>().ConvertUsing(_CustomerID => new Order { CustomerID = _CustomerID });



         CreateMap<Version, VersionDto>();
         CreateMap<VersionDto, Version>();
         CreateMap<int, Version>().ConvertUsing(_versionID => new Version { VersionID = _versionID });

         CreateMap<Model, ModelDto>();
         CreateMap<ModelDto, Model>();
         CreateMap<int, Model>().ConvertUsing(_modelID => new Model { ModelID = _modelID });

         CreateMap<Brand, BrandDto>();
         CreateMap<BrandDto, Brand>();
         CreateMap<int, Brand>().ConvertUsing(_BrandID => new Brand { BrandID = _BrandID });

         CreateMap<Category, CategoryDto>();
         CreateMap<CategoryDto, Category>();
         CreateMap<int, Category>().ConvertUsing(_CategoryId => new Category { CategoryId = _CategoryId });

         CreateMap<Product, ProductDto>();
         CreateMap<ProductDto, Product>();
         //Id ye silme göre silme için Dependency Injection
         CreateMap<int, Product>().ConvertUsing(_ProductId => new Product { ProductId = _ProductId });
      }
   }
}
