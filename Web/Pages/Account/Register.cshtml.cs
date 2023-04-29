using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Data;
using Web.Models;
using Web.ViewModels;

namespace Web.Pages.Account;

public class RegisterModel : PageModel
{
    private readonly UserManager<User> _userManager;
    public RegisterModel(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [BindProperty]
    public AccountRegisterViewModel Input { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) { return Page(); }

        var user = await _userManager.FindByNameAsync(Input.UserName);
        if (user is not null)
        {
            ModelState.AddModelError(string.Empty, "User name is already taken.");
            return Page();
        }

        user = await _userManager.FindByEmailAsync(Input.EmailAddress);
        if (user is not null)
        {
            ModelState.AddModelError(string.Empty, "Email address is already registered.");
            return Page();
        }

        var newUser = new User
        {
            UserName = Input.UserName,
            Email = Input.EmailAddress
        };

        await _userManager.CreateAsync(newUser, Input.Password);

        return Redirect("~/");
    }
}
