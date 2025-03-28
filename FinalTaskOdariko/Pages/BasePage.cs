using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace FinalTaskOdariko.Pages
{
    public abstract class BasePage(IWebDriver driver)
    {
        protected readonly IWebDriver _driver = driver;
        protected readonly WebDriverWait _wait = new(driver, TimeSpan.FromSeconds(10));

        protected IWebElement WaitForElement(By locator)
        {
            return _wait.Until(driver => driver.FindElement(locator));
        }
    }
}
