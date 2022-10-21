using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreManagement.Pages.Products
{
    public class ProductsModel : PageModel
    {
        public List<Entities.Product> Products = new List<Entities.Product>();
        public List<Entities.Category> Categories = new List<Entities.Category>();
        public void OnGet()
        {

        }

        public void OnPost()
        {

        }
    }
}
