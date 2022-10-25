using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreManagement.Pages.Statistics
{
    public class StatisticsModel : PageModel
    {
        [BindProperty]
        public string str_ExpiryDate { get; set; }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            if(str_ExpiryDate == null)
            {
                str_ExpiryDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            Response.Redirect($"./Statistics/ByExpiryDate?str_ExpiryDate={str_ExpiryDate}");
        }
    }
}
