using BAIS3150Project.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150Project.Pages
{
    public class DeleteCustomerModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string SearchCustomerId { get; set; }
        [BindProperty]
        public string CustomerId { get; set; }
        [BindProperty]
        public string CustomerName { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string City { get; set; }
        [BindProperty]
        public string Province { get; set; }
        [BindProperty]
        public string PostalCode { get; set; }
        public void OnGet()
        {
        }

        public void OnPostSearch()
        {
            CustomerId = null;
            CustomerName = null;
            Address = null;
            City = null;
            Province = null;
            PostalCode = null;

            if (SearchCustomerId == null)
            {
                ModelState.AddModelError("SearchCustomerId", "Please Enter Customer Id");
            }

            if (ModelState.IsValid)
            {
                ABCPOS ABCHardware = new();
                Customer FoundCustomer = ABCHardware.GetCustomerById(SearchCustomerId);

                if (FoundCustomer.CustomerId == null)
                {
                    ModelState.AddModelError("SearchCustomerId", "Not Found");
                }
                else
                {
                    CustomerId = FoundCustomer.CustomerId;
                    CustomerName = FoundCustomer.CustomerName;
                    Address = FoundCustomer.Address;
                    City = FoundCustomer.City;
                    Province = FoundCustomer.Province;
                    PostalCode = FoundCustomer.PostalCode;
                }
            }
        }

        public void OnPostDelete()
        {
            if (CustomerId == null)
            {
                ModelState.AddModelError("CustomerId", "Customer Id is required");
            }
            if (CustomerName == null)
            {
                ModelState.AddModelError("CustomerName", "Customer Name is required");
            }
            if (Address == null)
            {
                ModelState.AddModelError("Address", "Address is required");
            }
            if (City == null)
            {
                ModelState.AddModelError("City", "City is required");
            }
            if (Province == null)
            {
                ModelState.AddModelError("Province", "Province is required");
            }
            if (PostalCode == null)
            {
                ModelState.AddModelError("PostalCode", "Postal Code is required");
            }

            if (ModelState.IsValid)
            {
                bool Confirmation;
                ABCPOS ABCHardware = new();
                Confirmation = ABCHardware.DeleteCustomer(CustomerId);

                if (Confirmation)
                {
                    Message = "Customer was deleted successfully";
                    CustomerId = null;
                    CustomerName = null;
                    Address = null;
                    City = null;
                    Province = null;
                    PostalCode = null;
                }
                else
                {
                    Message = "Customer was not deleted successfully";
                }
            }
            else
            {
                Message = "*** Invalid Inputs ***";
            }
        }
    }
}
