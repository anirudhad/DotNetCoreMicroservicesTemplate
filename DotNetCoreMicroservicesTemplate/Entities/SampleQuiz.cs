using DotNetCoreMicroservicesTemplate.Entities.Base;

namespace DotNetCoreMicroservicesTemplate.Entities
{
    public class SampleQuiz : BaseEntity
    {
        public Sport sport { get; set; }
        public Maths maths { get; set; }
    }
    public class Maths
    {
        public Q1 q1 { get; set; }
        public Q2 q2 { get; set; }
    }

    public class Q1
    {
        public string question { get; set; }
        public List<string> options { get; set; }
        public string answer { get; set; }
    }

    public class Q2
    {
        public string question { get; set; }
        public List<string> options { get; set; }
        public string answer { get; set; }
    }

    public class Sport
    {
        public Q1 q1 { get; set; }
    }
}
