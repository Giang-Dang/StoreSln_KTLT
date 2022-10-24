using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Product
{
    public class AddProductModel : PageModel
    {
        public List<Entities.Category> Categories = new List<Entities.Category>();
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public int CategoryID { get; set; }
        [BindProperty]
        public decimal Price { get; set; }
        [BindProperty]
        public string str_ExpiryDate { get; set; }
        [BindProperty]
        public string str_ManufacturingDate { get; set; }
        [BindProperty]
        public string Manufacturer { get; set; }

        public bool IsNotiActive = false;
        
        public string[] Notifications = new string[1];

        public void OnGet()
        {
            Categories = CategoryBL.ReadData();
        }

        public void OnPost()
        {
            OnGet();
            bool isInputValid = ProductBL.IsValidAndReturnNoti(
                Name, 
                CategoryID, 
                Manufacturer,
                str_ExpiryDate,
                str_ManufacturingDate,
                Price,
                out Notifications
                );

            if(isInputValid)
            {
                DateTime expiryDate = DateTime.Parse(str_ExpiryDate);
                DateTime manufacturingDate = DateTime.Parse(str_ManufacturingDate);

                Entities.Product product = new Entities.Product(0, Name, Price, CategoryID, expiryDate, manufacturingDate, Manufacturer);
                var addRes = ProductBL.Add(product);
                Response.Redirect("/Products/Index");
            }      
            IsNotiActive = true;
        }
    }
}
