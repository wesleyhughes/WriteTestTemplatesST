using System.Collections.Generic;

namespace API
{

    public class Tester
    {
        public string displayName { get; set; }
        public string url { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
        public string uniqueName { get; set; }
        public string imageUrl { get; set; }
        public string descriptor { get; set; }
    }

    public class PointAssignment
    {
        public Configuration configuration { get; set; }
        public Tester tester { get; set; }
    }

    public class Value
    {
        public TestCase testCase { get; set; }
        public List<PointAssignment> pointAssignments { get; set; }
    }

    public class TestSuiteResponse
    {
        public List<Value> value { get; set; }
        public int count { get; set; }
    }
}