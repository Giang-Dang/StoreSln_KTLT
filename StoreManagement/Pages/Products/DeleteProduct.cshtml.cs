using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Product
{
    public class DeleteProductModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        public bool IsNotiActive = false;
        public string[] Notifications = new string[1];

        public Entities.Product Product;
        public Entities.Category Category;
        public void OnGet()
        {
            IsNotiActive = false;
            Product = ProductBL.FindByID(ID);
            Category = CategoryBL.FindByID(Product.CategoryID);
        }

        public void OnPost()
        {
            OnGet();
            if(ProductBL.CanDelete(ID))
            {
                Product = ProductBL.FindByID(ID);
                var deleteRes = ProductBL.Remove(Product);
                Response.Redirect("/Products");
            }
            Notifications = new string[1];
            Notifications[0] = "Không thể xóa mặt hàng này, do có hóa đơn này nằm trong hóa đơn nhập hoặc hóa đơn bán hàng.";

        }
    }
}
