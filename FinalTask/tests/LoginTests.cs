using OpenQA.Selenium;
using Xunit;
using FluentAssertions;
using System.Threading;
using System;

public class LoginTests : IDisposable
{
    private IWebDriver _driver;
    private LoginPage _loginPage;
    private DashboardPage _dashboardPage;

    [Theory]
    [MemberData(nameof(TestDataProvider.TestData), MemberType = typeof(TestDataProvider))]
    public void TestLogin(string username, string password, string expected)
    {
        // Arrange
        _driver = WebDriverFactory.CreateDriver("chrome"); // Use Firefox or Chrome as per requirement
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        _loginPage = new LoginPage(_driver);
        _dashboardPage = new DashboardPage(_driver);

        // Act
        _loginPage.EnterCredentials(username, password);
        _loginPage.ClickLogin();
        Thread.Sleep(2000); // Add wait if needed for the page to load

        // Assert
        if (expected.Contains("required"))
        {
            var errorMessage = _loginPage.GetErrorMessage();
            errorMessage.Should().Contain(expected);
        }
        else
        {
            _dashboardPage.GetTitle().Should().Be(expected);
        }
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}