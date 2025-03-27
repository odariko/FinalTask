using OpenQA.Selenium;

namespace FinalTaskOdariko.Pages
{
    public class DashboardPage
    {
        private readonly IWebDriver _driver;

        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetTitle()
        {
            return _driver.Title;
        }
    }
}