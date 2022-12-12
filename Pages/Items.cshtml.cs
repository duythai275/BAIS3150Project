using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3150Project.Domain;

namespace BAIS3150Project.Pages
{
    public class ItemsModel : PageModel
    {
        public List<Item> Items { get; set; }
        public void OnGet()
        {
            ABCPOS ABCHardware = new();
            Items = ABCHardware.GetAllItems();
        }

        public IActionResult OnPost(string action)
        {
            return action == "Add" ? RedirectToPage("AddItem") :
                    action == "Update" ? RedirectToPage("UpdateItem")
                    : RedirectToPage("DeleteItem");
        }
    }
}
