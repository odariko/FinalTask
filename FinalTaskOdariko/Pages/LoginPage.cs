using OpenQA.Selenium;

namespace FinalTaskOdariko.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private IWebElement UsernameField => _driver.FindElement(By.CssSelector("#user-name"));
        private IWebElement PasswordField => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement LoginButton => _driver.FindElement(By.CssSelector("#login-button"));
        private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector(".error-message-container"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterCredentials(string username, string password)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(username);
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }
    }
}