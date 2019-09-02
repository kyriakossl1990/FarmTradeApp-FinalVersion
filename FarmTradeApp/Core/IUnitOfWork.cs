using FarmTradeApp.Core.Repositories;

namespace FarmTradeApp.Persistence
{
    public interface IUnitOfWork
    {
        IAuctionRepository Auctions { get; }
        IFinalProductRepository FinalProducts { get; }
        ILocationRepository Locations { get; }
        IMarketEntryRepository MarketEntries { get; }
        IProductCategoryRepository ProductCategories { get; }
        IProductQualityRepository ProductQualities { get; }
        IProductRepository Products { get; }
        IRoleRepository Roles { get; }
        IStorageRepository Storages { get; }
        IUserNotificationRepository UserNotifications { get; }
        INotificationRepository Notifications { get; }
        IUserRepository Users { get; }
        IContactFormRepository ContactForms { get; }
        ITradeMatchRepository TradeMatches { get; }

        void Complete();
    }
}