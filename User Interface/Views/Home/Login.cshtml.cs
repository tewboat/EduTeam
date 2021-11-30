using Microsoft.AspNetCore.Mvc.RazorPages;

namespace User_Interface.Views.Home
{
    public class Login : PageModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        public void OnGet()
        {
            
        }
    }
}