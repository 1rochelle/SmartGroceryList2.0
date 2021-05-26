using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Interfaces
{
    public interface IProductService
    {
        bool CreateProduct(ProductCreate model);

        IEnumerable<ProductListItem> GetProducts();

        IEnumerable<ProductListItem> GetItemsToTrack();

        ProductDetail GetProductById(int id);

        bool UpdateProduct(ProductEdit productEdit);

        bool DeleteProduct(int id);
    }
}
