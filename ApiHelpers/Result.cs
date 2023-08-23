using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Api
{
    [DataContract]
    public class TestResult
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string comment { get; set; }
        [DataMember]
        public int durationInMs { get; set; }
        [DataMember]
        public string outcome { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public TestRun testRun { get; set; }
        [DataMember]
        public TestCase testCase { get; set; }
        [DataMember]
        public TestSuite testSuite { get; set; }
        [DataMember]
        public TestPoint testPoint { get; set; }
        
    }
    [DataContract]
    public class Result
    {
        [DataMember]
        public TestResult testResult { get; set; }
    }
}