
namespace EFCodeFirstValidation.Entities
{
    using System.ComponentModel.DataAnnotations;

    public static class StudentValidator
    {
        public static ValidationResult ValidateIsReallyOutStanding(Student student)
        {
            ValidationResult validationResult = ValidationResult.Success;

            if (student.GradePointAverage < 3.7 && student.IsOutStanding == true)
            {
                validationResult =
                    new ValidationResult(
                            "For declaring the student as outstanding one, the GPA must be greater than 3.7",
                            new string[] { "IsOutStanding", "GradePointAverage" }
                            );
            }

            return validationResult;
        }
    }
}
