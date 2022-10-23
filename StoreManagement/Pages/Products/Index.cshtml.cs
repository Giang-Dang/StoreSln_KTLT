using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Products
{
    public class ProductsModel : PageModel
    {
        public List<Entities.Product> Products = new List<Entities.Product>();
        public List<Entities.Category> Categories = new List<Entities.Category>();
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string str_CategoryID { get; set; }
        [BindProperty]
        public string Manufacturer { get; set; }
        [BindProperty]
        public string str_MinExpiryDate { get; set; }
        [BindProperty]
        public string str_MaxExpiryDate { get; set; }
        [BindProperty]
        public string str_MinManufacturingDate { get; set; }
        [BindProperty]
        public string str_MaxManufacturingDate { get; set; }
        [BindProperty]
        public string str_MinPrice { get; set; }
        [BindProperty]
        public string str_MaxPrice { get; set; }

        public void OnGet()
        {
            Categories = CategoryBL.ReadData();
            Products = ProductBL.ReadData();

        }

        public void OnPost()
        {
            Products = ProductBL.Filter(Name, str_CategoryID, Manufacturer, str_MinExpiryDate, str_MaxExpiryDate, str_MinManufacturingDate, str_MaxManufacturingDate, str_MinPrice, str_MaxPrice);
            Categories = CategoryBL.ReadData();
        }
    }
}
