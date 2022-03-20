using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string Email { get; set; }
    }
}
