using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Invoices
{
    public class DeleteInvoiceModel : PageModel
    {
            [BindProperty(SupportsGet = true)]
            public int ID { get; set; }


            public List<Entities.Invoice> Invoices = new List<Entities.Invoice>();
            public void OnGet()
            {
                Invoices = InvoiceBL.ReadData();
                var deleteRes = InvoiceBL.RemoveAtID(ID);

                var previousPageAddress = $"../Invoices";
                Response.Redirect(previousPageAddress);

            }

    }
}
