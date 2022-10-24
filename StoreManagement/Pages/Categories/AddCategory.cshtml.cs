using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.BAL;


namespace StoreManagement.Pages.Category
{
    public class AddCategoryModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        public bool IsNotiActive = false;
        public string[] Notifications = new string[1];
        public void OnGet()
        {
            Name = String.Empty;
        }

        public void OnPost()
        {
            if(CategoryBL.IsInputValidAndReturnNoti(Name,out Notifications))
            {  
                CategoryBL.Add(0, Name);
                Response.Redirect("/Categories/Index");
            }
            IsNotiActive = true;
        }
    }
}
