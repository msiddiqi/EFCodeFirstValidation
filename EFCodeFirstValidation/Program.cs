
namespace EFCodeFirstValidation
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using EFCodeFirstValidation.Entities;
    using EFCodeFirstValidation.Helpers;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory);
            Database.SetInitializer<InstituteEntities>(new DropCreateDatabaseAlways<InstituteEntities>());

            //TestValidatonAll();
           // TestValidationEntity();
            TestValidationProperty();
            
            //TestValidationAllEntities();

            Console.ReadLine();
        }

        private static void TestValidatonAll()
        {
            using (var context = new InstituteEntities())
            {
                //create entity
                var student = context.Students.Create();
                student.StudentLastName = "Siddiqi";
                student.GradePointAverage = 5;

                var department = context.Departments.Create();
                department.DepartmentName = "Electrical Engineering";

                //add it to context
                context.Students.Add(student);
                context.Departments.Add(department);

                try
                {
                    //save changes
                    context.SaveChanges();
                }
                catch (DbEntityValidationException validationException)
                {
                    //Console.WriteLine(validationException.)
                    string validationErrorMessage =
                        DbEntityValidationMessageParser.GetErrorMessage(validationException);

                    Console.WriteLine(validationErrorMessage);
                }
            }
        }

        private static void TestValidationEntity()
        {
            using (var context = new InstituteEntities())
            {
                //create entity
                var student = context.Students.Create();
                student.GradePointAverage = 2;
                student.IsOutStanding = true;

                var department = context.Departments.Create();
                department.DepartmentName = "Electrical Engineering";

                //add it to context
                context.Students.Add(student);
                context.Departments.Add(department);

                //validate only student entity 
                DbEntityValidationResult validationResult =
                    context.Entry<Student>(student).GetValidationResult();

                string errorMessage =
                    DbEntityValidationMessageParser.GetErrorMessage(validationResult);

                //Print Message
                Console.WriteLine(errorMessage);
            }
        }

        private static void TestValidationProperty()
        {
            using (var context = new InstituteEntities())
            {
                //create entity
                var student = context.Students.Create();
                student.StudentLastName = "Siddiqui";
                student.GradePointAverage = 5;

                var department = context.Departments.Create();
                department.DepartmentName = "Electrical Engineering";

                //add it to context
                context.Students.Add(student);
                context.Departments.Add(department);

                //validate entity 
                ICollection<DbValidationError> validationErrors =
                                                    context.Entry<Student>(student)
                                                           .Property<string>(s => s.StudentLastName)
                                                           .GetValidationErrors();

                string errorMessage =
                    DbEntityValidationMessageParser.GetErrorMessage(validationErrors);

                //Print Message
                Console.WriteLine(errorMessage);
            }
        }

        private static void TestValidationAllEntities()
        {
            using (var context = new InstituteEntities())
            {
                //create entity
                var student = context.Students.Create();
                student.StudentLastName = "Siddiqi";
                student.GradePointAverage = 5;

                var department = context.Departments.Create();
                department.DepartmentName = "Electrical Engineering";

                //add it to context
                context.Students.Add(student);
                context.Departments.Add(department);

                //validate entity 
                IEnumerable<DbEntityValidationResult> validationResults = context.GetValidationErrors();
                string errorMessage = DbEntityValidationMessageParser.GetErrorMessage(validationResults);

                //Print Message
                Console.WriteLine(errorMessage);
            }
        }
        
    }
}
