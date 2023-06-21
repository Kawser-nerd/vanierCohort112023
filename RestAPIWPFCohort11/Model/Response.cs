using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIWPFCohort11.Model
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public Student student { get; set; }

        public List<Student> students { get; set; }
    }
}
