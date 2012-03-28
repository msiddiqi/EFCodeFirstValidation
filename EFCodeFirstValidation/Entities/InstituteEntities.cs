using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace EFCodeFirstValidation.Entities
{
    public class InstituteEntities : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
