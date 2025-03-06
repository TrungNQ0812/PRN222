using Microsoft.AspNetCore.Mvc;
using Razor_Pages_Demo.Validation;
using Razor_Pages_Demo.Binding;
using System;
using System.ComponentModel.DataAnnotations;

namespace Razor_Pages_Demo.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Customer name is required!")]
        [StringLength(20,MinimumLength = 3, ErrorMessage = "Customer name must be between 3 and 20 characters!")]
        [Display(Name ="Customer name")]
        [ModelBinder(BinderType = typeof(CheckNameBinding))]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        [Display(Name = "Customer Email")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Year of birth is required!")]
        [Display(Name = "Year of birth")]
        [Range(1960, 2000, ErrorMessage = "1960 - 2000")]
        [CustomerValidation]
        public int? YearOfBirth { get; set; }
    }
}
