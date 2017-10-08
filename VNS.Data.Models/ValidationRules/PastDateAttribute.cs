using System;
using System.ComponentModel.DataAnnotations;

namespace VNS.Data.Models.ValidationRules
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var pastDate = value as DateTime?;

            if (pastDate != null && pastDate.Value.Date > DateTime.UtcNow.Date)
            {
                return new ValidationResult("Date must be in the past.");
            }

            return ValidationResult.Success;
        }
    }
}
