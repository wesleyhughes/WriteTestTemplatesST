using System.Collections.Generic;
using System.Runtime.Serialization;

namespace API
{
    [DataContract]
    public class Plan
    {
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class PostTestRun
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public TestCase testCase { get; set; }
        [DataMember]
        public TestPlan testPlan { get; set; }
        [DataMember]
        public TestSuite testSuite { get; set; }
        [DataMember]
        public Plan plan { get; set; }
        [DataMember]
        public List<string> pointIds { get; set; }
    }
}