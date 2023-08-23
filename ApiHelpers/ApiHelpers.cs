using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Api
{
    public partial class ApiHelpers
    {
        private string _azureDevOpsUserAuthToken = ConfigurationManager.AppSettings["AzureDevOpsUserAuthToken"].ToString();

        private Uri ApiBaseUri()
        {
            string organization = ConfigurationManager.AppSettings["AzureDevOpsOrganization"].ToString();
            string project = ConfigurationManager.AppSettings["AzureDevOpsProject"].ToString();

            return new Uri($"https://dev.azure.com/{organization}/{project}/_apis");
        }

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
            Uri requestUri = new Uri($"{ApiBaseUri()}/test/points?api-version=5.0-preview.2");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", _azureDevOpsUserAuthToken))));
                using (HttpResponseMessage response = await client.PostAsync(requestUri, requestBody))
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
            Uri requestUri = new Uri($"{ApiBaseUri()}/test/Plans/{testPlanID}/suites/{testSuiteID}/testcases?api-version=5.0");

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", _azureDevOpsUserAuthToken))));
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(requestUri))
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
            Uri requestUri = new Uri($"{ApiBaseUri()}/wit/workItems/{workItemID.ToString()}");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", _azureDevOpsUserAuthToken))));
                using (HttpResponseMessage response = await client.GetAsync(requestUri))
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