using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_CRUD.Model.View;

namespace Razor_CRUD.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> manager;

        [BindProperty]
        public Login login { get; set; }
        public LoginModel(SignInManager<IdentityUser> manager)
        {
            this.manager = manager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await manager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);
                if (result.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage("Register");
                    }
                }
                ModelState.AddModelError("", "Username or Password incorrect!");
            }
            return Page();
        }
    }
}
