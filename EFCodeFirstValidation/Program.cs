using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using EFCodeFirstValidation.Entities;
using System.Threading;

namespace EFCodeFirstValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory);
            Database.SetInitializer<InstituteEntities>(new DropCreateDatabaseAlways<InstituteEntities>());

            using (var context = new InstituteEntities())
            {
                var student = context.Students.Create();
                student.StudentFirstName = "Muhammad";
                student.StudentLastName = "Siddiqi";
                context.Students.Add(student);

                context.SaveChanges();

            }
        }
    }
}
