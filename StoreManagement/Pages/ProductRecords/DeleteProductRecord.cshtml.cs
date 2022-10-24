using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.ProductRecords
{
    public class DeleteProductRecordModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Type { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Action { get; set; }
        [BindProperty(SupportsGet = true)]
        public int RecordID { get; set; }

        public List<Entities.Invoice> Invoices = new List<Entities.Invoice>();
        public List<Entities.Receipt> Receipts = new List<Entities.Receipt>();
        public void OnGet()
        {
            var previousPageAddress = $"../{Type}s/{Action}{Type}?id={ID}";

            if (Type == "Invoice")
            {
                Invoices = InvoiceBL.ReadData();
                var invoice = InvoiceBL.FindByID(ID);
                var productRecord = invoice.ProductRecords.First(r => r.ID == RecordID);
                invoice.ProductRecords.Remove(productRecord);
                InvoiceBL.Edit(invoice.ID, invoice.CreationDateTime, invoice.ProductRecords);
            }

            if (Type == "Receipt")
            {
                Receipts = ReceiptBL.ReadData();
                var receipt = ReceiptBL.FindByID(ID);
                var productRecord = receipt.ProductRecords.First(r => r.ID == RecordID);
                receipt.ProductRecords.Remove(productRecord);
                ReceiptBL.Edit(receipt.ID, receipt.CreationDateTime, receipt.ProductRecords);
            }
            Response.Redirect(previousPageAddress);
        }

    }
}
