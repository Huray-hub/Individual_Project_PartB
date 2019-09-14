using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB.AssignmentsPerStudent
{
    public class AssignmentPerStudent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime SubmissionDateTime { get; set; }
        public decimal OralMark { get; set; }
        public decimal TotalMark { get; set; }

        public override string ToString() => $" {Id}. {Title}\n     Submission Date Time: {SubmissionDateTime}\n     OralMark: {OralMark}    Total Mark:{TotalMark}\n";
    }
}
