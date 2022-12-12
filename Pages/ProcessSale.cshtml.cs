using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3150Project.Domain;
using System.Text.Json;

namespace BAIS3150Project.Pages
{
    public class ProcessSaleModel : PageModel
    {
        public string Message { get; set; }
        public List<Item> Items { get; set; }
        [BindProperty]
        public string CustomerId { get; set; }
        [BindProperty]
        public string SaleDate { get; set; }
        [BindProperty]
        public string SalePerson { get; set; }
        [BindProperty]
        public string SaleItems { get; set; }

        public Customer ACustomer { get; set; }
        public void OnGet()
        {
            ABCPOS ABCHardware = new();
            Items = ABCHardware.GetAllItems();

            ACustomer = new();
        }

        public void OnPostProcessSale()
        {
            ABCPOS ABCHardware = new();
            Items = ABCHardware.GetAllItems();

            
            // Document code-maze.com/introduction-system-text-json-examples
            List<SaleItem> SaleItemObjects = JsonSerializer.Deserialize<List<SaleItem>>(SaleItems, new JsonSerializerOptions { NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString });

            // Check Valid Sale
            bool isValid = true;

            // Set New Sale
            decimal subTotal = 0;
            decimal gst = 0;
            decimal saleTotal = 0;
            foreach( SaleItem obj in SaleItemObjects )
            {
                subTotal += obj.ItemTotal;
                int inventory = Items.Find(item => item.ItemCode == obj.AItem.ItemCode).Quantity;
                if ( inventory < obj.Quantity) isValid = false;
            }
            gst = subTotal * (decimal)0.05;
            saleTotal = subTotal + gst;

            if ( isValid )
            {
                Sale ASale = new()
                {
                    SaleDate = SaleDate,
                    SalePerson = SalePerson,
                    Customer = ABCHardware.GetCustomerById(CustomerId),
                    SaleItems = SaleItemObjects,
                    SubTotal = subTotal,
                    GST = gst,
                    Total = saleTotal
                };
                ABCHardware = new();
                int NewSaleNumber = ABCHardware.ProcessSale(ASale);

                // Reset
                ACustomer = new();
                CustomerId = "";
                SaleDate = "";
                SalePerson = "";
                SaleItems = "";

                // Testing
                // Message = ASale.SubTotal + "," + ASale.Total + "," + ASale.Customer.CustomerName + "," + ASale.SaleItems.ElementAt(0).AItem.ItemCode;
                Message = "Sale processed successfully - Sale Number: " + NewSaleNumber;
            }
            else
            {
                ACustomer = ABCHardware.GetCustomerById(CustomerId);
                Message = "Not enough items in inventory";
            }
        }

        public void OnPostSearchCustomer()
        {
            ABCPOS ABCHardware = new();
            Items = ABCHardware.GetAllItems();

            ACustomer = ABCHardware.GetCustomerById(CustomerId);


        }
    }
}
