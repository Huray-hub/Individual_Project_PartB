using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiPro_PartB
{
    public enum Stream { Java = 1, Csharp }
    public enum Type { PartTime = 1, FullTime }
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Stream Stream { get; set; }        
        public Type Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString() => $"{Id}. Title: {Title}\n   Stream: {Stream}\n   Type: {Type}\n   Starting Date: {StartDate.ToShortDateString()}\n   Ending Date: {EndDate.ToShortDateString()}\n";

    }
}
