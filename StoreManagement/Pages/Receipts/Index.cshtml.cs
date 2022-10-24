using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Receipts
{
    public class IndexModel : PageModel
    {
        public int nextID { get; set; }
        public List<Entities.Receipt> Receipts = new List<Entities.Receipt>();
        public List<Entities.Category> Categories = new List<Entities.Category>();
        public void OnGet()
        {
            Receipts = ReceiptBL.ReadData();
            nextID = ReceiptBL.GetNextID();

            Categories = CategoryBL.ReadData();
        }

        public void OnPost()
        {

        }
    }
}
