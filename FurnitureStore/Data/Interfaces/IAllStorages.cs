using System;
using FurnitureStore.Data.Models;

namespace FurnitureStore.Data.Interfaces
{
    public interface IAllStorages
    {
        IEnumerable<Storage> Storages { get; }
        Storage GetStorage(int storageId);
    }
}

