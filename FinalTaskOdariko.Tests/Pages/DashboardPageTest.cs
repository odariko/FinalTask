using FinalTaskOdariko.Factories;
using FinalTaskOdariko.Pages;
using FinalTaskOdariko.Tests.Utilities;
using FluentAssertions;
using OpenQA.Selenium;
using Xunit;

namespace FinalTaskOdariko.Tests.Pages
{
    public class DashboardPageTest
    {
        [Theory]
        [MemberData(nameof(TestDataProvider.TestData), MemberType = typeof(TestDataProvider))]
        public void TestDashboardInChrome(string username, string password, string expected)
        {
            TestWithDriver("chrome", username, password, expected);
        }

        [Theory]
        [MemberData(nameof(TestDataProvider.TestData), MemberType = typeof(TestDataProvider))]
        public void TestDashboardInFirefox(string username, string password, string expected)
        {
            TestWithDriver("firefox", username, password, expected);
        }

        private void TestWithDriver(string driver, string username, string password, string expected)
        {
            using IWebDriver browserDriver = WebDriverFactory.CreateDriver(driver);
            browserDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            LoginPage loginPage = new(browserDriver);
            DashboardPage dashboardPage = new(browserDriver);

            loginPage.EnterCredentials(username, password);
            loginPage.ClickLogin();
            Thread.Sleep(2000);

            if (!expected.Contains("required"))
            {
                dashboardPage.GetTitle().Should().Be(expected);
            }
        }
    }
}
