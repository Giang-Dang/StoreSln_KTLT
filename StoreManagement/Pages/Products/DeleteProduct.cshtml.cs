using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Product
{
    public class DeleteProductModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        public Entities.Product Product;
        public void OnGet()
        {
            Product = ProductBL.FindByID(ID);
        }

        public void OnPost()
        {
            Product = ProductBL.FindByID(ID);
            var deleteRes = ProductBL.Delete(Product);
            Response.Redirect("/Products");
        }
    }
}
