using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubDateTime { get; set; }
        public decimal OralMark { get; set; }
        public decimal TotalMark { get; set; }

        public override string ToString() => $"{Id}. Title: {Title}\n   Desciption: {Description}\n   Submission Date and Time: {SubDateTime}\n   Oral Mark: {OralMark}\n   Total Mark: {TotalMark}\n";
    }
}
