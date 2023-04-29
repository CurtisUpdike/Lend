using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels;

public class AccountLoginViewModel
{
    [Required]
    [Display(Name = "User name")]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}