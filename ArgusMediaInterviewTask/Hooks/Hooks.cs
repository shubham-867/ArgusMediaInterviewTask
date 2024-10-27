using ArgusMediaInterviewTask.Utility;
using TechTalk.SpecFlow;

namespace ArgusMediaInterviewTask.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ConfigManager _configManager;
        public ExtentReport _extentReport;
        public ScenarioContext _context;

        public Hooks(ConfigManager configManager, ExtentReport extentReport, ScenarioContext context)
        {
            _configManager = configManager;
            _extentReport = extentReport;
            _context = context;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReport.ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReport.ExtentReportTearDown();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            ExtentReport.CreateTest(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            ExtentReport.CreateScenarioNode(_context.ScenarioInfo.Title);
        }

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    //TODO: implement logic that has to run after executing each scenario
        //}
        [AfterStep]
        public void AfterStep()
        {
            string stepType = _context.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = _context.StepContext.StepInfo.Text;
            if (_context.TestError == null)
            {
                ExtentReport.CreateStepNodeTestPass(stepType, stepName);

            }
            else
            {
                ExtentReport.CreateStepNodeTestFail(stepType, stepName, _context.TestError.Message);
            }
        }
    }
}