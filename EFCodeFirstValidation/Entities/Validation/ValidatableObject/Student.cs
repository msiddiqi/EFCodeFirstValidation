
namespace EFCodeFirstValidation.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Student : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IEnumerable<ValidationResult> validationResults = null;

            var student = validationContext.ObjectInstance as Student;

            if (string.IsNullOrEmpty(student.StudentAddress.City))
            {
                validationResults = new[] { 
                                            new ValidationResult(
                                                    "City can not be empty", 
                                                    new [] { "StudentAddress.City"})
                                          };
            }

            return validationResults;
        }
    }
}
