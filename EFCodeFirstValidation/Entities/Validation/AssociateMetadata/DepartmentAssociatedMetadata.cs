using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCodeFirstValidation.Entities.Validation.AssociateMetadata
{
    using System.Text;
    using System.ComponentModel.DataAnnotations;

    class DepartmentAssociatedMetadata
    {
        [RegularExpression("^Department of")]
        public virtual string DepartmentName { get; set; }
    }
}
