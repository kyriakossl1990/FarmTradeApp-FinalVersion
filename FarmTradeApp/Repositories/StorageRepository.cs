using FarmTradeApp.DAL;
using FarmTradeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Repositories
{
    public class StorageRepository
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

        public void AddStorage(Storage storage)
        {
            _context.Storages.Add(storage);
        }
    }
}