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
            var category = new Entities.Category(ID, Name);
            string deleteRes = CategoryBL.Delete(category);
            Response.Redirect("/Categories/Index");
        }
    }
}
