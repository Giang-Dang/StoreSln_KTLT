using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Invoice
{
    public class EditInvoiceModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty]
        public string str_CreationDateTime { get; set; }
        [BindProperty]
        public string str_NewCreationDateTime { get; set; }
        public decimal TotalAmount = 0;

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
            if (!InvoiceBL.AnyMatchID(ID))
            {
                resAdd = InvoiceBL.Add(ID, now);
                str_CreationDateTime = now.ToString();
            }
            str_CreationDateTime = Invoice.CreationDateTime.ToString();

        }

        public void OnPost()
        {
            DateTime creationDateTime;
            Invoice = InvoiceBL.FindByID(ID);
            if (str_NewCreationDateTime == null || !DateTime.TryParse(str_NewCreationDateTime, out creationDateTime))
            {
                creationDateTime = Invoice.CreationDateTime;
            }    
            var editRes = InvoiceBL.Edit(ID, creationDateTime, ProductRecords);
            Response.Redirect("../Invoices");
        }
    }
}
