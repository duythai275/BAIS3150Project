using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3150Project.TechnicalService;

namespace BAIS3150Project.Domain
{
    public class ABCPOS
    {
        public List<Item> GetAllItems()
        {
            Items ItemManager = new();
            return ItemManager.GetItems();
        }

        public bool AddItem(Item AItem)
        {
            Items ItemManager = new();
            return ItemManager.AddItem(AItem);
        }

        public bool UpdateItem(Item AItem)
        {
            Items ItemManager = new();
            return ItemManager.UpdateItem(AItem);
        }

        public bool DeleteItem(string ItemCode)
        {
            Items ItemManager = new();
            return ItemManager.DeleteItem(ItemCode);
        }

        public Item GetItemByCode(string ItemCode)
        {
            Items ItemManager = new();
            return ItemManager.GetItemByCode(ItemCode);
        }

        public List<Customer> GetAllCustomers()
        {
            Customers CustomerManager = new();
            return CustomerManager.GetCustomers();
        }

        public bool AddCustomer(Customer ACustomer)
        {
            Customers CustomerManager = new();
            return CustomerManager.AddCustomer(ACustomer);
        }

        public bool UpdateCustomer(Customer ACustomer)
        {
            Customers CustomerManager = new();
            return CustomerManager.UpdateCustomer(ACustomer);
        }

        public bool DeleteCustomer(string CustomerId)
        {
            Customers CustomerManager = new();
            return CustomerManager.DeleteCustomer(CustomerId);
        }

        public Customer GetCustomerById(string CustomerId)
        {
            Customers CustomerManager = new();
            return CustomerManager.GetCustomerById(CustomerId);
        }

        public List<Sale> GetAllSales()
        {
            Sales SaleManager = new();
            return SaleManager.GetAllSales();
        }

        public int ProcessSale(Sale ASale) {
            Sales SaleManager = new();
            return SaleManager.AddSale(ASale);
        }
    }
}
