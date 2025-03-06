namespace Estrrado___ASP.net_Machine_test.Models
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        public int StudentId { get; set; }
        public string CourseName { get; set; }
        public string University { get; set; }
        public int Year { get; set; }
        public virtual Student Student { get; set; }
        public decimal Percentage { get; set; }
    }
}
