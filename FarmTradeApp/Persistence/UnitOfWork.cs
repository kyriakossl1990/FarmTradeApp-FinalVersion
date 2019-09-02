using FarmTradeApp.Core.Repositories;
using FarmTradeApp.Persistence.Repositories;
using FarmTradeApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IMarketEntryRepository MarketEntries { get; private set; }
        public IFinalProductRepository FinalProducts { get; private set; }
        public IAuctionRepository Auctions { get; private set; }
        public IStorageRepository Storages { get; private set; }
        public ILocationRepository Locations { get; private set; }
        public IProductRepository Products { get; private set; }
        public IProductCategoryRepository ProductCategories { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IProductQualityRepository ProductQualities { get; private set; }
        public IUserNotificationRepository UserNotifications { get; private set; }
        public INotificationRepository Notifications { get; private set; }
        public IUserRepository Users { get; private set; }
        public IContactFormRepository ContactForms { get; private set; }
        public ITradeMatchRepository TradeMatches { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            MarketEntries = new MarketEntryRepository(context);
            FinalProducts = new FinalProductRepository(context);
            Auctions = new AuctionRepository(context);
            Storages = new StorageRepository(context);
            Locations = new LocationRepository(context);
            Products = new ProductRepository(context);
            ProductCategories = new ProductCategoryRepository(context);
            Roles = new RoleRepository(context);
            ProductQualities = new ProductQualityRepository(context);
            UserNotifications = new UserNotificationRepository(context);
            Notifications = new NotificationRepository(context);
            Users = new UserRepository(context);
            ContactForms = new ContactFormRepository(context);
            TradeMatches = new TradeMatchRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}