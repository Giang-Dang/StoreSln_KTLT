using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.ProductRecords
{
    public class AddProductRecordModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Type { get; set; }

        [BindProperty]
        public int ProductID { get; set; }

        [BindProperty]
        public int ProductCount { get; set; }

        public List<Entities.Product> Products = new List<Entities.Product>();
        public void OnGet()
        {
            Products = ProductBL.ReadData();
        }

        public void OnPost()
        {
            var resAddProductRecord = InvoiceBL.AddProductRecord(ID, ProductID, ProductCount);
            Response.Redirect($"../{Type}s/Add{Type}?id={ID}");
        }
    }
}
