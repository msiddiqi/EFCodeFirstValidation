
namespace EFCodeFirstValidation.Entities
{
    using System.Data.Entity;
    using EFCodeFirstValidation.Entities.Validation.FluentConfiguration;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Collections.Generic;

    public class InstituteEntities : DbContext
    {
        #region Public Properties

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        #endregion

        #region Constructors

        public InstituteEntities()
        {
            Configuration.ValidateOnSaveEnabled = false;
        }

        #endregion

        #region Overriden Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                        .Property(d => d.DepartmentName)
                        .HasMaxLength(20);

            modelBuilder.Configurations.Add(new StudentConfiguration());
        }

        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            bool ret = base.ShouldValidateEntity(entityEntry);;

            if (entityEntry.Entity is Student)
            {
                ret = false;
            }

            return ret;
        }

        protected override DbEntityValidationResult ValidateEntity(
                                                        DbEntityEntry entityEntry, 
                                                        IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }
        #endregion
    }
}
