
namespace EFCodeFirstValidation.Entities
{
    using System.ComponentModel.DataAnnotations;
    using EFCodeFirstValidation.Entities.Validation.AssociateMetadata;

    [MetadataType(typeof(DepartmentAssociatedMetadata))]
    public partial class Department
    {
    }
}
