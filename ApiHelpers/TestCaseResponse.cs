using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace API
{

    [DataContract]
    public class Links
    {
        [DataMember]
        public Avatar avatar { get; set; }
    }

    [DataContract]
    public class SystemAssignedTo
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
    public class SystemCreatedBy
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
    public class SystemChangedBy
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
    public class Avatar4
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Links4
    {
        [DataMember]
        public Avatar4 avatar { get; set; }
    }
    [DataContract]
    public class MicrosoftVSTSCommonActivatedBy
    {
        [DataMember]
        public string displayName { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public Links4 _links { get; set; }
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
    public class Fields
    {
        [DataMember]
        [JsonProperty("System.AreaPath")]
        public string AreaPath { get; set; }
        [DataMember]
        [JsonProperty("System.TeamProject")]
        public string TeamProject { get; set; }
        [DataMember]
        [JsonProperty("System.IterationPath")]
        public string IterationPath { get; set; }
        [DataMember]
        [JsonProperty("System.WorkItemType")]
        public string WorkItemType { get; set; }
        [DataMember]
        [JsonProperty("System.State")]
        public string State { get; set; }
        [DataMember]
        [JsonProperty("System.Reason")]
        public string Reason { get; set; }
        [DataMember]
        [JsonProperty("System.AssignedTo")]
        public SystemAssignedTo AssignedTo { get; set; }
        [DataMember]
        [JsonProperty("System.CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        [JsonProperty("System.CreatedBy")]
        public SystemCreatedBy CreatedBy { get; set; }
        [DataMember]
        [JsonProperty("System.ChangedDate")]
        public DateTime ChangedDate { get; set; }
        [DataMember]
        [JsonProperty("System.ChangedBy")]
        public SystemChangedBy ChangedBy { get; set; }
        [DataMember]
        [JsonProperty("System.CommentCount")]
        public int CommentCount { get; set; }
        [DataMember]
        [JsonProperty("System.Title")]
        public string Title { get; set; }
        [DataMember]
        [JsonProperty("Microsoft.VSTS.Common.StateChangeDate")]
        public DateTime StateChangeDate { get; set; }
        [DataMember]
        [JsonProperty("Microsoft.VSTS.Common.ActivatedDate")]
        public DateTime ActivatedDate { get; set; }
        [DataMember]
        [JsonProperty("Microsoft.VSTS.Common.ActivatedBy")]
        public MicrosoftVSTSCommonActivatedBy ActivatedBy { get; set; }
        [DataMember]
        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public int Priority { get; set; }
        [DataMember]
        [JsonProperty("Microsoft.VSTS.TCM.AutomationStatus")]
        public string AutomationStatus { get; set; }
        [DataMember]
        [JsonProperty("MGMAgile.TestCompany")]
        public string TestCompany { get; set; }
        [DataMember]
        [JsonProperty("MGMAgile.ExpiresOn")]
        public DateTime ExpiresOn { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        [JsonProperty("Microsoft.VSTS.TCM.Steps")]
        public string Steps { get; set; }
        [DataMember]
        [JsonProperty("System.LocalDataSource")]
        public string LocalDataSource { get; set; }
    }
    [DataContract]
    public class Self
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class WorkItemUpdates
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class WorkItemRevisions
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class WorkItemComments
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Html
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class WorkItemType
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Fields2
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Links5
    {
        [DataMember]
        public Self self { get; set; }
        [DataMember]
        public WorkItemUpdates workItemUpdates { get; set; }
        [DataMember]
        public WorkItemRevisions workItemRevisions { get; set; }
        [DataMember]
        public WorkItemComments workItemComments { get; set; }
        [DataMember]
        public Html html { get; set; }
        [DataMember]
        public WorkItemType workItemType { get; set; }
        [DataMember]
        public Fields2 fields { get; set; }
    }
    [DataContract]
    public class WorkItemResponse
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int rev { get; set; }
        [DataMember]
        public Fields fields { get; set; }
        [DataMember]
        public Links5 _links { get; set; }
        [DataMember]
        public string url { get; set; }
    }
}