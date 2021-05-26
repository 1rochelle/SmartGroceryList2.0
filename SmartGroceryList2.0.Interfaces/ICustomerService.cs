using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Interfaces
{
    public interface ICustomerService
    {
        bool CreateCustomer(CustomerCreate model);

        IEnumerable<CustomerListItem> GetCustomers();

        CustomerDetail GetCustomerById(int id);

        bool UpdateCustomer(CustomerEdit customerEdit);

        bool DeleteCustomer(int id);
    }
}
