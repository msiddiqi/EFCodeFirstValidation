
namespace EFCodeFirstDatabaseCreation.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class SiddiqiValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = value as string;
            ValidationResult validationResult = ValidationResult.Success;

            if (string.IsNullOrEmpty(val) || !val.Equals("Siddiqi"))
            {
                StringBuilder errorMessageBuilder = new StringBuilder();
                errorMessageBuilder.AppendFormat("Last Name: {0} is not valid. ", value);
                errorMessageBuilder.Append("Only Siddiqi's are allowed in this institute. ");
                errorMessageBuilder.Append("This is our home school!");

                validationResult = new ValidationResult(errorMessageBuilder.ToString());
            }

            return validationResult;
        }
    }
}
