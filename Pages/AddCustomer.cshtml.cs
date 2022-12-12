using BAIS3150Project.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150Project.Pages
{
    public class AddCustomerModel : PageModel
    {
        public string Message { get; set; }
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
        
        public void OnPost()
        {
            if (CustomerId == null)
            {
                ModelState.AddModelError("CustomerId", "Customer Id is required");
            }
            else if (CustomerName == null)
            {
                ModelState.AddModelError("CustomerName", "Customer Name is required");
            }
            else if (Address == null)
            {
                ModelState.AddModelError("Address", "Address is required");
            }
            else if (City == null)
            {
                ModelState.AddModelError("City", "City is required");
            }
            else if (Province == null)
            {
                ModelState.AddModelError("Province", "Province is required");
            }
            else if (PostalCode == null)
            {
                ModelState.AddModelError("PostalCode", "Postal Code is required");
            }

            if (ModelState.IsValid)
            {
                bool Confirmation;
                Customer ACustomer = new()
                {
                    CustomerId = CustomerId,
                    CustomerName = CustomerName,
                    Address = Address,
                    City = City,
                    Province = Province,
                    PostalCode = PostalCode
                };
                ABCPOS ABCHardware = new();
                Confirmation = ABCHardware.AddCustomer(ACustomer);

                if (Confirmation)
                {
                    Message = "Customer was added successfully";
                }
                else
                {
                    Message = "Customer was added unsuccessfully";
                }
            }
            else
            {
                Message = "*** Invalid Inputs ***";
            }
        }
    }
}
