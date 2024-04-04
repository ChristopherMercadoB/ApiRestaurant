using ApiRestaurant.Core.Application.ViewModels.Dish;
using ApiRestaurant.Core.Application.ViewModels.Ingredient;
using ApiRestaurant.Core.Application.ViewModels.Order;
using ApiRestaurant.Core.Application.ViewModels.Table;
using ApiRestaurant.Core.Domain.Entities;
using AutoMapper;


namespace ApiRestaurant.Core.Application.Mapping
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            #region DishMapping

            CreateMap<Dish, DishViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<Dish, DishSaveViewModel>()
                .ForMember(dest => dest.IngredientsIds, obj => obj.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            #endregion

            #region IngredientMapping

            CreateMap<Ingredient, IngredientViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<Ingredient, IngredientSaveViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());
            #endregion

            #region TableMapping
            CreateMap<Table, TableViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<Table, TableSaveViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());
            #endregion

            #region OrderMapping
            CreateMap<Order, OrderViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());

            CreateMap<Order, OrderSaveViewModel>()
                .ForMember(dest=>dest.DishesIds, obj => obj.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.CreatedDate, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedBy, obj => obj.Ignore())
                .ForMember(dest => dest.UpdatedDate, obj => obj.Ignore());
            #endregion
        }
    }
}
