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
        public List<Entities.Product> Products = new List<Entities.Product>();
        public List<Entities.Category> Categories = new List<Entities.Category>();
        public Entities.Invoice Invoice;
        public void OnGet()
        {
            var now = DateTime.Now;
            Invoice = InvoiceBL.FindByID(ID);
            ProductRecords = Invoice.ProductRecords ?? new List<Entities.ProductRecord>();
            Products = ProductBL.ReadData();
            Categories = CategoryBL.ReadData();

            bool resAdd;
            str_CreationDateTime = Invoice.CreationDateTime.ToString();
            if (!InvoiceBL.AnyMatchID(ID))
            {
                resAdd = InvoiceBL.Add(ID, now);
                str_CreationDateTime = now.ToString();
            }

            Response.Redirect($"../Invoices/EditInvoice?id={ID}");
        }

        public void OnPost()
        {

        }
    }
}
