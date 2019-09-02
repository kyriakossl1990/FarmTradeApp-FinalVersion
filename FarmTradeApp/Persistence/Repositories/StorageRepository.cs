using FarmTradeApp.Persistence;
using FarmTradeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmTradeApp.Core.Repositories;
using System.Data.Entity;

namespace FarmTradeApp.Repositories
{
    public class StorageRepository : IStorageRepository
    {
        private readonly ApplicationDbContext _context;

        public StorageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Storage GetStorage(int storageId)
        {
            return _context.Storages.SingleOrDefault(s => s.Id == storageId);
        }

        public IEnumerable<Storage> GetStorages()
        {
            return _context.Storages.ToList();
        }

        public IEnumerable<Storage> GetStoragesWithLocation()
        {
            return _context.Storages
                .Include(s => s.Location)
                .ToList();
        }

        public void AddStorage(Storage storage)
        {
            _context.Storages.Add(storage);
        }

        public void RemoveStorage(Storage storage)
        {
            _context.Storages.Remove(storage);
        }
    }
}