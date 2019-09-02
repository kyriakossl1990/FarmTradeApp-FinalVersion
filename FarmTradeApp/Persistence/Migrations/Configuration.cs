namespace FarmTradeApp.Persistence.Migrations
{
    using FarmTradeApp.Core.Models;
    using FarmTradeApp.Core.Models.Market;
    using FarmTradeApp.Core.Models.Products;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FarmTradeApp.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Persistence\Migrations";
        }

        protected override void Seed(FarmTradeApp.Persistence.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var locations = new List<Location>
             {
                 new Location { City = "Αθήνα", PostalCode ="12345"},
                 new Location { City ="Κόρινθος", PostalCode ="54321"}
             };
            locations.ForEach(l => context.Locations.AddOrUpdate(i => i.PostalCode, l));
            context.SaveChanges();


            var storages = new List<Storage>
             {
                 new Storage { Name = "Αθήνα Α", LocationId = locations.Single( i => i.City == "Αθήνα").Id},
                 new Storage {Name = "Κόρινθος Α", LocationId = locations.Single( i => i.City == "Κόρινθος").Id},
                 new Storage { Name = "Αθήνα Β", LocationId = locations.Single( i => i.City == "Αθήνα").Id},
                 new Storage {Name = "Κόρινθος Β", LocationId = locations.Single( i => i.City == "Κόρινθος").Id},
             };
            storages.ForEach(s => context.Storages.AddOrUpdate(i => i.Name, s));
            context.SaveChanges();

            var productCategories = new List<ProductCategory>
            {
                new ProductCategory { Name = "Σιτηρά"},
                new ProductCategory {Name = "Οπωροκηπευτικά"},
                new ProductCategory {Name = "Εσπεριδοειδή"}
            };

            productCategories.ForEach(c => context.ProductCategories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var auctions = new List<Auction>
            {
                Auction.Initialize(new DateTime(2019, 08, 02))
            };

            auctions.ForEach(a => context.Auctions.AddOrUpdate(au => au.AuctionEndDate, a));
            context.SaveChanges();

            var products = new List<Product>
             {
                 new Product { Name = "Σιτάρι", CategoryId = productCategories.Single( i => i.Name =="Σιτηρά").Id},
                 new Product { Name = "Κριθάρι", CategoryId = productCategories.Single( i => i.Name =="Σιτηρά").Id},
                 new Product { Name = "Καλαμπόκι", CategoryId = productCategories.Single( i => i.Name =="Σιτηρά").Id},
                 new Product { Name = "Μανταρίνι", CategoryId = productCategories.Single( i => i.Name =="Εσπεριδοειδή").Id},
                 new Product { Name = "Πορτοκάλι", CategoryId = productCategories.Single( i => i.Name =="Εσπεριδοειδή").Id},
                 new Product { Name = "Λεμόνι", CategoryId = productCategories.Single( i => i.Name =="Εσπεριδοειδή").Id},
                 new Product { Name = "Ντομάτα", CategoryId = productCategories.Single( i => i.Name =="Οπωροκηπευτικά").Id},
                 new Product { Name = "Μαρούλι", CategoryId = productCategories.Single( i => i.Name =="Οπωροκηπευτικά").Id},
                 new Product { Name = "Αγγούρι", CategoryId = productCategories.Single( i => i.Name =="Οπωροκηπευτικά").Id},
                 new Product { Name = "Γκρέιπφρουτ", CategoryId = productCategories.Single( i => i.Name =="Εσπεριδοειδή").Id}
             };
            products.ForEach(p => context.Products.AddOrUpdate(i => i.Name, p));
            context.SaveChanges();
        }
    }
}
