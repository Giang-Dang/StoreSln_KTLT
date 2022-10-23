using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Invoice
{

    public class AddInvoiceModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty]
        public string str_CreationDateTime { get; set; }

        public List<Entities.ProductRecord> ProductRecords = new List<Entities.ProductRecord>();
        public Entities.Invoice Invoice;
        public void OnGet()
        {
            var now = DateTime.Now;
            var resAdd = InvoiceBL.Add(ID, now);
            str_CreationDateTime = now.ToString();
        }

        public void OnPost()
        {

        }
    }
}
