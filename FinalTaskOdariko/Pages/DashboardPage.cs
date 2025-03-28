using OpenQA.Selenium;

namespace FinalTaskOdariko.Pages
{
    public class DashboardPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly IWebDriver _driver = driver;

        public string GetTitle()
        {
            return _driver.Title;
        }
    }
}