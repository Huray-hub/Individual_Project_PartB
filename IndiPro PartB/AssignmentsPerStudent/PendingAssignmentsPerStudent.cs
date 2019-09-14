using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB.AssignmentsPerStudentFolder
{
    public class PendingAssignmentsPerStudent
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public DateTime SubmissionDateTime { get; set; }

        public override string ToString() => $" {Id}. Student: {LastName} {FirstName}\n     Pending Assignment: {Title}\n     Submission Date and Time: {SubmissionDateTime}\n";
    }
}
