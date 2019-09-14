using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB.AssignmentPerCourseFolder
{
    public class AssignmentPerCourse
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public override string ToString() => $"{Id}. {Title}\n";
    }
}
