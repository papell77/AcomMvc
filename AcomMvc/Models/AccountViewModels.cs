using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AcomMvc.Core.Domain;

namespace AcomMvc.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Posta elettronica")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Codice")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Memorizzare questo browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Il testo non corrisponde ad una email valida")]
        [Display(Name = "Posta elettronica")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Il testo non corrisponde ad una email valida")]
        [Display(Name = "Posta elettronica")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Inserire una password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Memorizza account")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage="Inserire nome dell'utente")]
        [Display(Name="Nome")]
        public string firstName { get; set; }

        [Required(ErrorMessage="Inserire cognome dell'utente")]
        [Display(Name="Cognome")]
        public string surname { get; set; }

        [Required(ErrorMessage="Inserire indirizzo email")]
        [EmailAddress(ErrorMessage="Il testo non corrisponde ad una email valida")]
        [Display(Name = "Posta elettronica")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Inserire una password")]
        [StringLength(100, ErrorMessage = "La lunghezza di {0} deve essere di almeno {2} caratteri.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Conferma password")]
        [Compare("Password", ErrorMessage = "La password e la password di conferma non corrispondono.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage="Inserire ruolo")]
        [Display(Name="Ruolo")]
        public string role { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage="Inserire un indirizzo email")]
        [EmailAddress(ErrorMessage = "Il testo non corrisponde ad una email valida")]
        [Display(Name = "Posta elettronica")]
        public string Email { get; set; }

        [Required(ErrorMessage="Inserire una password")]
        [StringLength(100, ErrorMessage = "La lunghezza di {0} deve essere di almeno {2} caratteri.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Conferma password")]
        [Compare("Password", ErrorMessage = "La password e la password di conferma non corrispondono.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Inserire un indirizzo email")]
        [EmailAddress(ErrorMessage = "Il testo non corrisponde ad una email valida")]
        [Display(Name = "Posta elettronica")]
        public string Email { get; set; }
    }
}
