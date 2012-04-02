
namespace EFCodeFirstValidation.Entities.Validation.FluentConfiguration
{
    using System.Data.Entity.ModelConfiguration;

    class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Property(s => s.StudentLastName).HasMaxLength(7);
        }
    }
}
