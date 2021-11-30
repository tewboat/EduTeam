using Microsoft.AspNetCore.Mvc.RazorPages;

namespace User_Interface.Views.Home
{
    public class Registration : PageModel
    {
        //public ViewUser User;
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public void OnGet()
        {
            
        }
    }
}