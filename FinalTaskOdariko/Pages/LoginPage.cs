using OpenQA.Selenium;

namespace FinalTaskOdariko.Pages
{
    public class LoginPage(IWebDriver driver) : BasePage(driver)
    {
        private IWebElement UsernameField => WaitForElement(By.CssSelector("#user-name"));
        private IWebElement PasswordField => WaitForElement(By.CssSelector("#password"));
        private IWebElement LoginButton => WaitForElement(By.CssSelector("#login-button"));
        private IWebElement ErrorMessage => WaitForElement(By.CssSelector(".error-message-container"));

        public void EnterCredentials(string username, string password)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(username);
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }

        public void ClearCredentials()
        {
            UsernameField.Clear();
            PasswordField.Clear();
        }

        public void EnterUsername(string username)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }

        public void ClearPassword()
        {
            PasswordField.Clear();
        }

        public void ClearUsername()
        {
            UsernameField.Clear();
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