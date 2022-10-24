using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        public int nextID { get; set; }
        public List<Entities.Invoice> Invoices = new List<Entities.Invoice>();
        public List<Entities.Category> Categories = new List<Entities.Category>();
        public void OnGet()
        {
            Invoices = InvoiceBL.ReadData();
            nextID = InvoiceBL.GetNextID();

            Categories = CategoryBL.ReadData();
        }

        public void OnPost()
        {

        }
    }
}
