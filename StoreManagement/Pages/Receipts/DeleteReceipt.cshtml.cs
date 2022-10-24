using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Receipts
{
    public class DeleteReceiptModel : PageModel
    {
            [BindProperty(SupportsGet = true)]
            public int ID { get; set; }


            public List<Entities.Receipt> Receipts = new List<Entities.Receipt>();
            public void OnGet()
            {
                Receipts = ReceiptBL.ReadData();
                var deleteRes = ReceiptBL.RemoveAtID(ID);

                var previousPageAddress = $"../Receipts";
                Response.Redirect(previousPageAddress);

            }

    }
}
