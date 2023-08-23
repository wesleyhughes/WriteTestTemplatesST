This project is a very basic windows forms app that writes automated test templates by getting the test names for a given test suite in a test plan and creates an XUnit Fact method for each test. 

To use: 
        Open in visual studio and run
        set your Azure DevOps organization, project, and user access token in App.Config under appsettings if you want to use your azure devops account. 
        You must have a test plan containing a test suite containing a test for it to work.
        Can use TestPlanId = 4 and TestSuiteId = 5 if leaving the default config values.
        Enter the TestPlanId and TestSuiteId, along with a directory to write the test templates to.
        Click Create Test Template and if no error message appears you should be able to look at your test file, name will be the name of the test suite
        
Most of this was written in 2019-2020 at my previous employer and parts of it are no longer accessible. Was in the process of rewriting to test my personal website, which no longer exists.
I was also learning C# when I did most of this, so there may be questionable design patterns and technical decisions, some incorrect formatting, and other bad practices,
 but it's really more of a demonstration of my ability to conceptualize and build something than a comprehensive representation of my skills.