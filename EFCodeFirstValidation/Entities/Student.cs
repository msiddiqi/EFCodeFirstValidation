
using System.ComponentModel.DataAnnotations;
namespace EFCodeFirstValidation.Entities
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public virtual string StudentFirstName { get; set; }
        public virtual string StudentLastName { get; set; }
        public virtual double GradePointAverage { get; set; }
        public virtual bool IsOutStanding { get; set; }
        public virtual Address StudentAddress { get; set; }

        public virtual Department StudentDepartment { get; set; }

        public Student()
        {
            StudentAddress = new Address();
        }
    }

    public class Address
    {
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string ZipCode { get; set; }
    }
}
