using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Receipt
{
    public class EditReceiptModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty]
        public string str_CreationDateTime { get; set; }
        [BindProperty]
        public string str_NewCreationDateTime { get; set; }

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
            if (!ReceiptBL.AnyMatchID(ID))
            {
                resAdd = ReceiptBL.Add(ID, now);
                str_CreationDateTime = now.ToString();
            }
            str_CreationDateTime = Receipt.CreationDateTime.ToString();

        }

        public void OnPost()
        {
            DateTime creationDateTime;
            Receipt = ReceiptBL.FindByID(ID);
            if (str_NewCreationDateTime == null || !DateTime.TryParse(str_NewCreationDateTime, out creationDateTime))
            {
                creationDateTime = Receipt.CreationDateTime;
            }    
            var editRes = ReceiptBL.Edit(ID, creationDateTime, ProductRecords);
            Response.Redirect("../Receipts");
        }
    }
}
