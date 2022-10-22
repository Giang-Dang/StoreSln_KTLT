using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Category
{
    [BindProperties]
    public class CategoriesModel : PageModel
    {
        public List<Entities.Category> Categories = new List<Entities.Category>();
        [BindProperty]
        public string SearchName { get; set; }
        public void OnGet()
        {
            Categories = CategoryBL.ReadData();
        }

        public void OnPost()
        {
            Categories = CategoryBL.FindByName(SearchName);
        }
    }
}
