using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;

namespace StoreManagement.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string str_MinCreationDateTime { get; set; }
        [BindProperty]
        public string str_MaxCreationDateTime { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DeleteNoti { get; set; }
        public int nextID { get; set; }
        public List<Entities.Invoice> Invoices = new List<Entities.Invoice>();
        public List<Entities.Category> Categories = new List<Entities.Category>();

        public string[] Notifications = new string[1];
        public bool IsNotiActive = false;

        public void OnGet()
        {
            Invoices = InvoiceBL.ReadData();
            nextID = InvoiceBL.GetNextID();

            Categories = CategoryBL.ReadData();
            IsNotiActive = false;
            if (DeleteNoti != null)
            {
                IsNotiActive = true;
                Notifications[0] = DeleteNoti;
            }    
            
        }

        public void OnPost()
        {
            OnGet();
            IsNotiActive = false;
            Invoices = InvoiceBL.Filter(str_MinCreationDateTime, str_MaxCreationDateTime);
            if (!Invoices.Any())
            {

                Notifications = new string[1];
                Notifications[0] = "Không có hóa đơn nào thỏa yêu cầu tìm kiếm.";
                IsNotiActive = true;
            }
        }
    }
}
