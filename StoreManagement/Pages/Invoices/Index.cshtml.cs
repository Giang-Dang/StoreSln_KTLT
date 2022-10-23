using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        public int nextID { get; set; }
        public List<Entities.Invoice> Invoices { get; set; }
        public void OnGet()
        {
            Invoices = InvoiceBL.ReadData();
            nextID = InvoiceBL.GetNextID();
        }
    }
}
