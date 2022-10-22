using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;


namespace StoreManagement.Pages.Category
{
    public class AddCategoryModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        public void OnGet()
        {
            Name = String.Empty;
        }

        public void OnPost()
        {
            CategoryBL.Add(0, Name);
            Response.Redirect("/Categories/Index");
        }
    }
}
