using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.ProductRecords
{
    public class AddProductRecordModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Type { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Action { get; set; }

        [BindProperty]
        public int ProductID { get; set; }

        [BindProperty]
        public int ProductCount { get; set; }

        public bool IsNotiActive = false;
        public string[] Notifications = new string[1];

        public string PreviousPageAddress;
        public string Title;

        public List<Entities.Product> Products = new List<Entities.Product>();
        public void OnGet()
        {
            Products = ProductBL.ReadData();
            PreviousPageAddress = $"../{Type}s/{Action}{Type}?id={ID}";
            if(Type == "Invoice")
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
            if (ProductRecordBL.IsInputValidAndReturnNoti(ProductID, ProductCount, Type == "Receipt", out Notifications))
            {
                if(Type == "Invoice")
                {
                    var resAddProductRecord = InvoiceBL.AddProductRecord(ID, ProductID, ProductCount);
                    Response.Redirect(PreviousPageAddress);
                }    
                if(Type == "Receipt")
                {
                    var resAddProductRecord = ReceiptBL.AddProductRecord(ID, ProductID, ProductCount);
                    Response.Redirect(PreviousPageAddress);
                }    
            }
            IsNotiActive = true;
        }


    }
}
