using System;
using System.ComponentModel.DataAnnotations;

namespace Razor_Pages_Demo.Validation
{
    public class CustomerValidation : ValidationAttribute
    {
        public CustomerValidation()
        {
            ErrorMessage = "The year of birth connot greeter than current year (2021).";
        }



        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            int number = Int32.Parse(value.ToString());
            return (number < 2021);

        }
    }
}
