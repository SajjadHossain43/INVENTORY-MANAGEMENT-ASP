using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_CRUD.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> manager;

        public LogoutModel(SignInManager<IdentityUser> manager)
        {
            this.manager = manager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await manager.SignOutAsync();
            return RedirectToPage("Login");
        }
        public IActionResult OnPostDontLogoutAsync()
        {
            return RedirectToPage("Index");
        }
    }
}
