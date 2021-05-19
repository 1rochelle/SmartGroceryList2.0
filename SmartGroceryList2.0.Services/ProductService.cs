using SmartGroceryList2._0.Data;
using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    OwnerId = _userId,
                    StoreId = model.StoreId,
                    ItemName = model.ItemName,
                    DepartmentType = model.DepartmentType,
                    ItemType = model.ItemType,
                    ItemCount = model.ItemCount,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ProductListItem
                                {
                                    Id = e.Id,
                                    ItemName = e.ItemName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var product =
                    ctx
                        .Products
                        .Where(p => p.OwnerId == _userId)
                        .SingleOrDefault(p => p.Id == id);

                return new ProductDetail
                {
                    Id = product.Id,
                    ItemName = product.ItemName,
                    DepartmentType = product.DepartmentType,
                    ItemType = product.ItemType,
                    CreatedUtc = product.CreatedUtc,
                    StoreId = product.StoreId,
                    PurchasedAtMultipleStores = product.PurchasedAtMultipleStores,
                    ItemCount = product.ItemCount
                };
            }
        }

        public bool UpdateProduct(ProductEdit productEdit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var product =
                    ctx
                        .Products
                        .Where(p => p.OwnerId == _userId)
                        .SingleOrDefault(p => p.Id == productEdit.Id);
                if (product == null)
                {
                    return false;
                }

                product.Id = productEdit.Id;
                product.ItemName = productEdit.ItemName;
                product.DepartmentType = productEdit.DepartmentType;
                product.ItemType = productEdit.ItemType;
                product.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var product =
                    ctx
                        .Products
                        .Where(p => p.OwnerId == _userId)
                        .SingleOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return false;
                }

                ctx.Products.Remove(product);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
