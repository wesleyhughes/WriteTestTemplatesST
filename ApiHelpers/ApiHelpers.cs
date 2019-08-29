using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public partial class ApiHelpers
    {
        string AZURE_DEVOPS_AUTHORIZATION_TOKEN = "c4cij3fpebgltasvwrqsjhtoseyn6gvmqz47dkglwkt73ts3tuca";
        // believe this is how it assigns the test runner in devops
        public TestResult TestResultParameters(int testCaseID, int testSuiteID, int testPlanID, string testOutcome, string testLog, int resultIndex, int testRunID, int duration = 0)
        {
            TestResult testResult = new TestResult
            {
                id = 100000 + resultIndex,
                comment = testLog,
                durationInMs = duration,
                outcome = testOutcome,
                state = "Completed",
                testPoint = new TestPoint { id = GetPoint(testCaseID, testSuiteID, testPlanID).Result.ToString() },
                testRun = new TestRun { id = testRunID.ToString() },
                testCase = new TestCase { id = testCaseID.ToString() },
                testSuite = new TestSuite { id = testSuiteID.ToString() }
            };
            return testResult;
        }
        public PostTestRun TestRunParameters(string testName, int testCaseID, int testSuiteID, int testPlanID)
        {
            PostTestRun testRun = new PostTestRun
            {
                name = testName,
                testCase = new TestCase { id = testCaseID.ToString() },
                testPlan = new TestPlan { id = testPlanID.ToString() },
                testSuite = new TestSuite { id = testSuiteID.ToString() },
                plan = new Plan { id = testPlanID.ToString() }
            };
            return testRun;
        }
       

       
        public async Task<int> GetPoint(int testCaseID, int testSuiteID, int testPlanID)
        {
            var json = "{'PointsFilter': {'TestcaseIds': ['" + testCaseID + "']}}";
            var requestBody = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", AZURE_DEVOPS_AUTHORIZATION_TOKEN))));
                using (HttpResponseMessage response = await client.PostAsync(
                            "https://dev.azure.com/allsynx/systems/_apis/test/points?api-version=5.0-preview.2", requestBody))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var testData = JsonConvert.DeserializeObject<PointsResponse>(responseBody);
                    int i = 0;
                    int pointID = 0;
                    for (i = 0; i < testData.points.Count; i++)
                    {
                        string responseUrl = testData.points[i].url;
                        if (responseUrl.Contains(testSuiteID.ToString()) && responseUrl.Contains(testPlanID.ToString()))
                        {
                            pointID = testData.points[i].id;
                        }
                    }
                    return pointID;
                }
            }
        }
     
        public async Task<int[]> GetTestCasesFromSuite(int testSuiteID, int testPlanID)
        {
            List<int> testCases = new List<int>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", AZURE_DEVOPS_AUTHORIZATION_TOKEN))));
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(
                                "https://dev.azure.com/allsynx/systems/_apis/test/Plans/" + testPlanID + "/suites/" + testSuiteID + "/testcases?api-version=5.0"))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var testData = JsonConvert.DeserializeObject<TestSuiteResponse>(responseBody);
                        int count = testData.count;

                        for (int i = 0; i < testData.count; i++)
                        {
                            int testCase = Convert.ToInt32(testData.value[i].testCase.id);
                            testCases.Add(testCase);
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            int[] testCaseIds = testCases.ToArray();
            return testCaseIds;
        }
        public async Task<WorkItemResponse> GetWorkItem(int workItemID)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", AZURE_DEVOPS_AUTHORIZATION_TOKEN))));
                using (HttpResponseMessage response = await client.GetAsync(
                            "https://dev.azure.com/allsynx/systems/_apis/wit/workItems/" + workItemID.ToString()))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var testData = JsonConvert.DeserializeObject<WorkItemResponse>(responseBody);
                    return testData;
                }
            }
        }
    }
}