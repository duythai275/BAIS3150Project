using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3150Project.Domain;

namespace BAIS3150Project.Pages
{
    public class CustomersModel : PageModel
    {
        public List<Customer> Customers { get; set; }
        public void OnGet()
        {
            ABCPOS ABCHardware = new();
            Customers = ABCHardware.GetAllCustomers();
        }

        public IActionResult OnPost(string action)
        {
            return action == "Add" ? RedirectToPage("AddCustomer") :
                    action == "Update" ? RedirectToPage("UpdateCustomer")
                    : RedirectToPage("DeleteCustomer");
        }
    }
}
