using SmartGroceryList2._0.Data;
using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Services
{
    public class StoreService
    {
        private readonly Guid _userId;

        public StoreService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStore(StoreCreate model)
        {
            var entity =
                new Store()
                {
                    OwnerId = _userId,
                    StoreName = model.StoreName,
                    StoreAddressNumber = model.StoreAddressNumber,
                    StoreStreetName = model.StoreStreetName,
                    StoreTownOrCity = model.StoreTownOrCity,
                    StoreZIP = model.StoreZIP
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stores.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StoreListItem> GetStores()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Stores
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new StoreListItem
                            {
                                StoreId = e.StoreId,
                                StoreName = e.StoreName
                            }
                        );
                return query.ToArray();
            }
        }

        public StoreDetail GetStoreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var store =
                    ctx
                        .Stores
                        .Where(s => s.OwnerId == _userId)
                        .SingleOrDefault(s => s.StoreId == id);

                return new StoreDetail
                {
                    StoreId = store.StoreId,
                    StoreName = store.StoreName,
                    StoreAddressNumber = store.StoreAddressNumber,
                    StoreStreetName = store.StoreStreetName,
                    StoreTownOrCity = store.StoreTownOrCity,
                    StoreState = store.StoreState,
                    StoreZIP = store.StoreZIP
                };
            }
        }

        public bool UpdateStore(StoreEdit storeEdit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var store =
                    ctx
                        .Stores
                        .Where(s => s.OwnerId == _userId)
                        .SingleOrDefault(s => s.StoreId == storeEdit.StoreId);
                if (store == null)
                {
                    return false;
                }

                store.StoreId = storeEdit.StoreId;
                store.StoreName = storeEdit.StoreName;
                store.StoreAddressNumber = storeEdit.StoreAddressNumber;
                store.StoreStreetName = storeEdit.StoreStreetName;
                store.StoreTownOrCity = storeEdit.StoreTownOrCity;
                store.StoreState = storeEdit.StoreState;
                store.StoreZIP = storeEdit.StoreZIP;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStore(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var store =
                    ctx
                        .Stores
                        .Where(s => s.OwnerId == _userId)
                        .SingleOrDefault(s => s.StoreId == id);
                if (store == null)
                {
                    return false;
                }

                ctx.Stores.Remove(store);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
