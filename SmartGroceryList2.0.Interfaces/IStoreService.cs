using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Interfaces
{
    public interface IStoreService
    {
        bool CreateStore(StoreCreate model);

        IEnumerable<StoreListItem> GetStores();

        StoreDetail GetStoreById(int id);

        bool UpdateStore(StoreEdit storeEdit);

        bool DeleteStore(int id);
    }
}
