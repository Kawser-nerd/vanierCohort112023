namespace RestAPICohort.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public Student student { get; set; }

        public List<Student> students { get; set;}
    }
}
