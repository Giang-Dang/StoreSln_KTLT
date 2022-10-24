using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.ProductRecords
{
    public class EditProductRecordModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Type { get; set; }

        [BindProperty]
        public int ProductID { get; set; }

        [BindProperty]
        public int ProductCount { get; set; }

        public string Title;

        public List<Entities.Product> Products = new List<Entities.Product>();
        public void OnGet()
        {
            Products = ProductBL.ReadData();

            if (Type == "Invoice")
            {
                Title = "Thêm danh mục vào hóa đơn nhập hàng";
            }
            if (Type == "Receipt")
            {
                Title = "Thêm danh mục vào hóa đơn bán hàng";
            }
        }

        public void OnPost()
        {
            OnGet();
            bool resAddProductRecord;
            if (Type == "Invoice")
            {
                resAddProductRecord = InvoiceBL.AddProductRecord(ID, ProductID, ProductCount);
            }
            if (Type == "Receipt")
            {
                resAddProductRecord = ReceiptBL.AddProductRecord(ID, ProductID, ProductCount);
            }
            
            Response.Redirect($"../{Type}s/Add{Type}?id={ID}");
        }
    }
}
