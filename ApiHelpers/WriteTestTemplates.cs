using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Api;
using System.Threading.Tasks;
using System.Linq;

namespace Write_Test_Template
{
    public partial class WriteTestTemplates : ApiHelpers
    {
   
        public async Task WriteFile(int testSuiteID, int testPlanID,string filePath)
        {
            WorkItemResponse testSuiteData = await GetWorkItem(testSuiteID);
            string name = testSuiteData.fields.Title;
            string fileName = FormatNameForFilename(name);
            string className = FormatNameForMethod(name);
            string[] openingLines = { "using API;","using System;", "using Xunit;", "", "namespace Tests",
                "{", "    public class " + className, "    {","        ApiHelpers apiHelpers = new ApiHelpers();" };
            string[] closingLines = { "    }", "}" };
            int[] testCases = await GetTestCasesFromSuite(testSuiteID, testPlanID);
           
            using (StreamWriter testFile = new StreamWriter(filePath + "\\"+ fileName + ".cs"))
            {
                foreach (string line in openingLines)
                {
                    testFile.WriteLine(line);
                }
                
                testFile.WriteLine("            ");
                testFile.WriteLine("        [Fact]");
                testFile.WriteLine("        public void RunAll()");
                testFile.WriteLine("        {");
                testFile.WriteLine("            apiHelpers.RunTestAndPostResult(new Action[]{");

                foreach (int testCaseID in testCases)
                {
                    WorkItemResponse testData = await GetWorkItem(testCaseID);
                    string testName = FormatNameForMethod(testData.fields.Title);
                    testFile.WriteLine("                " + testName + ", ");
                }

                testFile.WriteLine("                },");
                string testCases2 = string.Join(",", testCases);
                testFile.WriteLine("                new int[]{" + string.Join(",", testCases2) + "},");
                testFile.WriteLine("                " + testSuiteID + " , " + testPlanID + ", " + "this.GetType().Name);");
                testFile.WriteLine("        }");

                foreach (int testCaseID in testCases)
                {
                    WorkItemResponse testData = await GetWorkItem(testCaseID);
                    string testName = FormatNameForMethod(testData.fields.Title);
                    testFile.WriteLine("        [Fact]");
                    testFile.WriteLine("        //" + testCaseID + " - " + testData.fields.Title);
                    testFile.WriteLine("        public void " + testName + "()");
                    testFile.WriteLine("        {");
                    testFile.WriteLine("            ");
                    testFile.WriteLine("        }");
                }

                foreach (string line in closingLines)
                {
                    testFile.WriteLine(line);
                }

                testFile.Flush();
                testFile.Close();
            }

        }

        public string FormatNameForMethod(string name)
        {
            List<char> removeCharacters = new List<char>() {'\"', '/', '\\', '>', '<', '*', '(', ')', '-', ':', ';', ',', '?', '[', ']', '{', '}', '.', '|', '*', '&', '^', '%', '$', '#', '@', '!', '^' };
            char[] removeNumbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            name = name.Replace("+", " Plus ");
            name = name.Replace("=", " Equals ");
            name = name.Replace(">", " Above ");
            name = name.Replace("<", " Below ");
            name = name.Replace("&", " And ");
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            name = textInfo.ToTitleCase(name);

            name = name.TrimStart(removeNumbers);
            foreach (char character in removeCharacters)
            {
                name = name.Replace(character, ' ');
            }
            name = name.Replace(" ", "");
            return name;
        }
        public string FormatNameForFilename(string name)
        {
            List<char> removeCharacters = new List<char>() { '/', '\\', '>', '<', '*', '(', ')', '-', ':', ';' };
            name = name.Replace("+", "Plus");
            name = name.Replace("=", "Equals");
            foreach (char character in removeCharacters)
            {
                name = name.Replace(character, ' ');
            }
            return name;
        }
    }
}