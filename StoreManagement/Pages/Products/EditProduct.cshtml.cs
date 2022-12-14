using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Product
{
    public class EditProductModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public int CategoryID { get; set; }
        [BindProperty]
        public Decimal Price { get; set; }
        [BindProperty]
        public string Manufacturer { get; set; }
        [BindProperty]
        public string str_ExpiryDate { get; set; }
        [BindProperty]
        public string str_ManufacturingDate { get; set; }

        public Entities.Product Product;
        public Entities.Category Category;
        public List<Entities.Category> Categories = new List<Entities.Category>();
        public void OnGet()
        {
            Product = ProductBL.FindByID(ID);
            Category = CategoryBL.FindByID(Product.CategoryID);
            Categories = CategoryBL.ReadData();
        }

        public void OnPost()
        {
            Product = ProductBL.FindByID(ID);
            Category = CategoryBL.FindByID(Product.CategoryID);

            DateTime expiryDate;
            if(!DateTime.TryParse(str_ExpiryDate, out expiryDate))
            {
                expiryDate = Product.ExpiryDate;
            }    

            DateTime manufacturingDate;
            if (!DateTime.TryParse(str_ManufacturingDate, out manufacturingDate))
            {
                manufacturingDate = Product.ManufacturingDate;
            }


            Product = new Entities.Product(ID, Name, Price, CategoryID, expiryDate, manufacturingDate, Manufacturer);
            
            var editRes = ProductBL.Edit(Product);
            Response.Redirect("/Products");
        }
    }
}
