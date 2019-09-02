using AutoMapper;
using FarmTradeApp.Core.Dtos;
using FarmTradeApp.Core.Models;
using FarmTradeApp.Core.Models.Market;
using FarmTradeApp.Core.Models.Notifications;
using FarmTradeApp.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, LocationDto>();

            CreateMap<Storage, StorageDto>();
            CreateMap<StorageDto, Storage>();

            CreateMap<Product, ProductDto>();

            CreateMap<ProductCategory, ProductCategoryDto>();

            CreateMap<ProductQuality, ProductQualityDto>();

            CreateMap<FinalProduct, FinalProductDto>();

            CreateMap<Auction, AuctionDto>();

            CreateMap<MarketEntry, MarketEntryDto>()
                .ForMember(e => e.TableId, opt => opt.Ignore());
            CreateMap<MarketEntryDto, MarketEntry>();

            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<Notification, NotificationDto>();
            CreateMap<TradeMatch, TradeMatchDto>();
        }
    }
}