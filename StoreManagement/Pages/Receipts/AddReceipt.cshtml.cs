using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Receipt
{

    public class AddReceiptModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty]
        public string str_CreationDateTime { get; set; }

        public List<Entities.ProductRecord> ProductRecords = new List<Entities.ProductRecord>();
        public List<Entities.Product> Products = new List<Entities.Product>();
        public List<Entities.Category> Categories = new List<Entities.Category>();
        public Entities.Receipt Receipt;
        public void OnGet()
        {
            var now = DateTime.Now;
            Receipt = ReceiptBL.FindByID(ID);
            ProductRecords = Receipt.ProductRecords ?? new List<Entities.ProductRecord>();
            Products = ProductBL.ReadData();
            Categories = CategoryBL.ReadData();

            bool resAdd;
            str_CreationDateTime = Receipt.CreationDateTime.ToString();
            if (!ReceiptBL.AnyMatchID(ID))
            {
                resAdd = ReceiptBL.Add(ID, now);
                str_CreationDateTime = now.ToString();
            }

            Response.Redirect($"../Receipts/EditReceipt?id={ID}");
        }

        public void OnPost()
        {

        }
    }
}
