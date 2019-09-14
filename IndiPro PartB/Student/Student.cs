using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal TuitionFees { get; set; }
        public int CourseID { get; set; }

        public override string ToString() => $"{Id}. First Name: {FirstName}\n    Last Name: {LastName}\n    Date of Birth: {DateOfBirth.ToShortDateString()}\n    Tuition Fees: {TuitionFees}\n";
    }
}
