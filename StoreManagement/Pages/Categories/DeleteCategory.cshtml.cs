using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Category
{
    public class DeleteCategoryModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        [BindProperty]
        public string Name { get; set; }

        public bool IsNotiActive = false;
        public string[] Notifications = new string[2];

        public Entities.Category Category;
        public void OnGet()
        {
            if (ID != 0)
            {
                Category = CategoryBL.FindByID(ID);
            }
        }
        public void OnPost()
        {
            OnGet();
            if (!ProductBL.AnyProductInCategory(ID))
            {
                
                var category = CategoryBL.FindByID(ID);
                var deleteRes = CategoryBL.Delete(category);
                Response.Redirect("/Categories/Index");
            }
            Notifications[0] = "Không thể xóa loại hàng này, do có sản phẩm thuộc loại hàng này.";
            Notifications[1] = " Vui lòng xóa sản phẩm hoặc thay đổi loại hàng của các sản phẩm thuộc loại hàng này" +
                    " trước khi thực hiện xóa.";
            IsNotiActive = true;
        }
    }
}
