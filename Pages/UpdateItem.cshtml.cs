using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3150Project.Domain;
using BAIS3150Project.TechnicalService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150Project.Pages
{
    public class UpdateItemModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string SearchItemCode { get; set; }
        [BindProperty]
        public string ItemCode { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string UnitPrice { get; set; }
        [BindProperty]
        public string Quantity { get; set; }
        public void OnGet()
        {
        }

        public void OnPostSearch()
        {
            ItemCode = null;
            Description = null;
            UnitPrice = null;
            Quantity = null;

            if (SearchItemCode == null)
            {
                ModelState.AddModelError("SearchItemCode", "Please Enter Item Code");
            }

            if (ModelState.IsValid)
            {
                ABCPOS ABCHardware = new();
                Item FoundItem = ABCHardware.GetItemByCode(SearchItemCode);

                if (FoundItem.ItemCode == null)
                {
                    ModelState.AddModelError("SearchItemCode", "Not Found");
                }
                else
                {
                    ItemCode = FoundItem.ItemCode;
                    Description = FoundItem.Description;
                    UnitPrice = FoundItem.UnitPrice.ToString();
                    Quantity = FoundItem.Quantity.ToString();
                }
            }
        }

        public void OnPostUpdate()
        {
            if (ItemCode == null)
            {
                ModelState.AddModelError("ItemCode", "Item Code is required");
            }
            if (Description == null)
            {
                ModelState.AddModelError("Description", "Description is required");
            }
            if (UnitPrice == null)
            {
                ModelState.AddModelError("UnitPrice", "Unit Price is required");
            }
            if (Quantity == null)
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
                    UnitPrice = Convert.ToDecimal(UnitPrice),
                    Quantity = Convert.ToInt32(Quantity)
                };
                ABCPOS ABCHardware = new();
                Confirmation = ABCHardware.UpdateItem(AItem);

                if (Confirmation)
                {
                    Message = "Item was updated successfully";
                    ItemCode = null;
                    Description = null;
                    UnitPrice = null;
                    Quantity = null;
                }
                else
                {
                    Message = "Item was not updated successfully";
                }
            }
            else
            {
                Message = "*** Invalid Inputs ***";
            }
        }
    }
}
