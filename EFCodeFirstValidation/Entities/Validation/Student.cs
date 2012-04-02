

namespace EFCodeFirstValidation.Entities
{
    using System.ComponentModel.DataAnnotations;
    using EFCodeFirstValidation.Entities.Validation.AssociateMetadata;

    [CustomValidation(typeof(StudentValidator), "ValidateIsReallyOutStanding")]
    [MetadataType(typeof(StudentAssociatedMetadata))]
    public partial class Student
    {
    }
}
