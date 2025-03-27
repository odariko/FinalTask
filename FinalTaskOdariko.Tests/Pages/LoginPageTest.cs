using FinalTaskOdariko.Factories;
using FinalTaskOdariko.Pages;
using FinalTaskOdariko.Tests.Utilities;
using OpenQA.Selenium;
using Xunit;
using FluentAssertions;

namespace FinalTaskOdariko.Tests.Pages
{
    public class LoginPageTest
    {
        [Theory]
        [MemberData(nameof(TestDataProvider.TestData), MemberType = typeof(TestDataProvider))]
        public void TestLoginInChrome(string username, string password, string expected)
        {
            TestWithDriver("chrome", username, password, expected);
        }

        [Theory]
        [MemberData(nameof(TestDataProvider.TestData), MemberType = typeof(TestDataProvider))]
        public void TestLoginInFirefox(string username, string password, string expected)
        {
            TestWithDriver("firefox", username, password, expected);
        }

        private void TestWithDriver(string driver, string username, string password, string expected)
        {
            using IWebDriver browserDriver = WebDriverFactory.CreateDriver(driver);
            browserDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            LoginPage loginPage = new(browserDriver);

            loginPage.EnterCredentials(username, password);
            loginPage.ClickLogin();
            Thread.Sleep(2000);

            if (expected.Contains("required"))
            {
                string errorMessage = loginPage.GetErrorMessage();
                errorMessage.Should().NotBeNullOrEmpty().And.Contain(expected);
            }
        }
    }
}
