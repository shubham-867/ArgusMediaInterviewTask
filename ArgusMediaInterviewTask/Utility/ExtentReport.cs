using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter.Config;
using AventStack.ExtentReports.Gherkin.Model;
namespace ArgusMediaInterviewTask.Utility
{
    public class ExtentReport
    {

        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;
        public static ExtentTest step;

        public static string testResultPath = Directory.GetParent(@"..\..\..\").FullName
             + Path.DirectorySeparatorChar + "Result"
             + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy HHmmss") + ".html";

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentSparkReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Youtube");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void CreateTest(string featuretitle)
        {
            _feature = _extentReports.CreateTest<Feature>(featuretitle);
        }

        public static void CreateScenarioNode(string scenarioTitle)
        {
            _scenario = _feature.CreateNode<Scenario>(scenarioTitle);
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public static void CreateStepNodeTestPass(string stepType, string stepName)
        {
            if (stepType == "Given")
            {
                _scenario.CreateNode<Given>(stepName);
            }
            else if (stepType == "When")
            {
                _scenario.CreateNode<When>(stepName);
            }
            else if (stepType == "Then")
            {
                _scenario.CreateNode<Then>(stepName);
            }
            else if (stepType == "And")
            {
                _scenario.CreateNode<And>(stepName);
            }
        }
        public static void CreateStepNodeTestFail(string stepType, string stepName, string message)
        {           
            if (stepType == "Given")
            {
                _scenario.CreateNode<Given>(stepName).Fail(message);
            }
            else if (stepType == "When")
            {
                _scenario.CreateNode<When>(stepName).Fail(message);
            }
            else if (stepType == "Then")
            {
                _scenario.CreateNode<Then>(stepName).Fail(message);
            }
            else if (stepType == "And")
            {
                _scenario.CreateNode<And>(stepName).Fail(message);
            }

        }

    }
}
