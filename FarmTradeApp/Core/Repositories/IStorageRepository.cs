using System.Collections.Generic;
using FarmTradeApp.Core.Models;

namespace FarmTradeApp.Core.Repositories
{
    public interface IStorageRepository
    {
        void AddStorage(Storage storage);
        void RemoveStorage(Storage storage);
        Storage GetStorage(int storageId);
        IEnumerable<Storage> GetStorages();
        IEnumerable<Storage> GetStoragesWithLocation();
    }
}