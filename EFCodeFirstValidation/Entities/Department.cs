
namespace EFCodeFirstValidation.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Department
    {
        public int DepartmentId { get; set; }

        [RegularExpression("^Department of")]
        public virtual string DepartmentName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}