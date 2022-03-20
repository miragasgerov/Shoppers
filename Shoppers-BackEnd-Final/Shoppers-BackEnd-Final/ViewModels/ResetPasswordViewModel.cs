using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
        [StringLength(maximumLength: 25, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(maximumLength: 25, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
