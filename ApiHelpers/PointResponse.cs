using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Api
{
    [DataContract]
    public class AssignedTo
    {
        [DataMember]
        public string displayName { get; set; }
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class Configuration
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class LastTestRun
    {
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class LastResult
    {
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class Suite
    {
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class TestCase
    {
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class TestPlan
    {
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class WorkItem
    {
        [DataMember]
        public string key { get; set; }
        [DataMember]
        public string value { get; set; }
    }
    [DataContract]
    public class WorkItemProperty
    {
        [DataMember]
        public WorkItem workItem { get; set; }
    }
    [DataContract]
    public class Point
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public AssignedTo assignedTo { get; set; }
        [DataMember]
        public bool automated { get; set; }
        [DataMember]
        public Configuration configuration { get; set; }
        [DataMember]
        public LastTestRun lastTestRun { get; set; }
        [DataMember]
        public LastResult lastResult { get; set; }
        [DataMember]
        public string outcome { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string lastResultState { get; set; }
        [DataMember]
        public Suite suite { get; set; }
        [DataMember]
        public TestCase testCase { get; set; }
        [DataMember]
        public TestPlan testPlan { get; set; }
        [DataMember]
        public List<WorkItemProperty> workItemProperties { get; set; }
    }
    [DataContract]
    public class PointsFilter
    {
        [DataMember]
        public List<int> testcaseIds { get; set; }
    }
    [DataContract]
    public class PointsResponse
    {
        [DataMember]
        public List<Point> points { get; set; }
        [DataMember]
        public PointsFilter pointsFilter { get; set; }
    }
}