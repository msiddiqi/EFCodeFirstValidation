using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using EFCodeFirstDatabaseCreation.ValidationAttributes;

namespace EFCodeFirstValidation.Entities.Validation.AssociateMetadata
{
    class StudentAssociatedMetadata
    {
        [MinLength(3)]
        public virtual string StudentFirstName { get; set; }

        [Required]
        [SiddiqiValidationAttribute]
        public virtual string StudentLastName { get; set; }

        [Range(1, 4)]
        public virtual double GradePointAverage { get; set; }
        
    }
}
