using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Api
{
    [DataContract]
    public class Project
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string url { get; set; }
    }
    [DataContract]
    public class TestPoint
    {
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class TestRun
    {
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class TestSuite
    {
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class Avatar
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Owner
    {
        [DataMember]
        public string displayName { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public Links _links { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string uniqueName { get; set; }
        [DataMember]
        public string imageUrl { get; set; }
        [DataMember]
        public string descriptor { get; set; }
    }
    [DataContract]
    public class Avatar2
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Links2
    {
        [DataMember]
        public Avatar2 avatar { get; set; }
    }
    [DataContract]
    public class RunBy
    {
        [DataMember]
        public string displayName { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public Links2 _links { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string uniqueName { get; set; }
        [DataMember]
        public string imageUrl { get; set; }
        [DataMember]
        public string descriptor { get; set; }
    }
    [DataContract]
    public class Avatar3
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Links3
    {
        [DataMember]
        public Avatar3 avatar { get; set; }
    }
    [DataContract]
    public class LastUpdatedBy
    {
        [DataMember]
        public string displayName { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public Links3 _links { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string uniqueName { get; set; }
        [DataMember]
        public string imageUrl { get; set; }
        [DataMember]
        public string descriptor { get; set; }
    }
    [DataContract]
    public class PostRunResponse
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string comment { get; set; }
        [DataMember]
        public Configuration configuration { get; set; }
        [DataMember]
        public Project project { get; set; }
        [DataMember]
        public DateTime startedDate { get; set; }
        [DataMember]
        public DateTime completedDate { get; set; }
        [DataMember]
        public string outcome { get; set; }
        [DataMember]
        public int revision { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public TestCase testCase { get; set; }
        [DataMember]
        public TestPoint testPoint { get; set; }
        [DataMember]
        public TestRun testRun { get; set; }
        [DataMember]
        public DateTime lastUpdatedDate { get; set; }
        [DataMember]
        public int priority { get; set; }
        [DataMember]
        public DateTime createdDate { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string failureType { get; set; }
        [DataMember]
        public string testCaseTitle { get; set; }
        [DataMember]
        public int testCaseRevision { get; set; }
        [DataMember]
        public List<object> customFields { get; set; }
        [DataMember]
        public TestPlan testPlan { get; set; }
        [DataMember]
        public TestSuite testSuite { get; set; }
        [DataMember]
        public int testCaseReferenceId { get; set; }
        [DataMember]
        public Owner owner { get; set; }
        [DataMember]
        public RunBy runBy { get; set; }
        [DataMember]
        public LastUpdatedBy lastUpdatedBy { get; set; }
    }
}