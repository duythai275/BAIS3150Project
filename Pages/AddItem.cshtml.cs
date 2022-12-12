using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3150Project.Domain;

namespace BAIS3150Project.Pages
{
    public class AddItemModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string ItemCode { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public decimal UnitPrice { get; set; }
        [BindProperty]
        public int Quantity { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (ItemCode == null)
            {
                ModelState.AddModelError("ItemCode", "Item Code is required");
            }
            else if (Description == null)
            {
                ModelState.AddModelError("Description", "Description is required");
            }
            else if (UnitPrice == 0)
            {
                ModelState.AddModelError("UnitPrice", "Unit Price is required");
            }
            else if (Quantity == 0)
            {
                ModelState.AddModelError("Quantity", "Quantity is required");
            }

            if (ModelState.IsValid)
            {
                bool Confirmation;
                Item AItem = new()
                {
                    ItemCode = ItemCode,
                    Description = Description,
                    UnitPrice = UnitPrice,
                    Quantity = Quantity
                };
                ABCPOS ABCHardware = new();
                Confirmation = ABCHardware.AddItem(AItem);

                if (Confirmation)
                {
                    Message = "Item was added successfully";
                }
                else
                {
                    Message = "Item was added unsuccessfully";
                }
            }
            else
            {
                Message = "*** Invalid Inputs ***";
            }
        }
    }
}
