using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models;
using Web.ViewModels;

namespace Web.Pages.Account;

public class LoginModel : PageModel
{
    private readonly SignInManager<User> _signInManager;
    public LoginModel(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    [BindProperty]
    public AccountLoginViewModel Input { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) { return Page(); }

        var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, false, false);

        if (result.Succeeded)
        {
            return Redirect("~/");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid credentials. Please try again.");
            return Page();
        }
    }
}
