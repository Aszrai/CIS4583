using System.Collections.Generic;
using CIS4583.Model;

namespace CIS4583.IRepository
{
    public interface ICustomerRepository
    {
        Customer Customer_Select(Customer criteria);
        List<Customer> Customer_SelectList();
        bool Customer_Insert(Customer customer);
        bool Customer_Update(Customer customer);
        bool Customer_Delete(Customer customer);
    }
}
