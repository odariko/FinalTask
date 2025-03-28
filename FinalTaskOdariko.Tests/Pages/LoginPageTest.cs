using FinalTaskOdariko.Factories;
using FinalTaskOdariko.Pages;
using OpenQA.Selenium;
using Xunit;
using FluentAssertions;
using Serilog;

[assembly: CollectionBehavior(DisableTestParallelization = false, MaxParallelThreads = 16)]

namespace FinalTaskOdariko.Tests.Pages
{
    public class LoginPageTest
    {
        private readonly ILogger _logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/test-login.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        [Theory]
        [InlineData("chrome")]
        [InlineData("firefox")]
        public void ShouldShowUsernameRequiredError_WhenCredentialsAreEmpty(string browser)
        {
            try
            {
                _logger.Information($"Starting CredentialsAreEmpty test for {browser}");
                // Arrange
                using IWebDriver driver = WebDriverFactory.CreateDriver(browser);
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                LoginPage loginPage = new(driver);
                // Act
                loginPage.EnterCredentials("test", "test");
                loginPage.ClearCredentials();
                loginPage.ClickLogin();
                // Assert
                loginPage.GetErrorMessage().Should().Contain("Username is required");
                _logger.Information($"CredentialsAreEmpty test for {browser} completed");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"CredentialsAreEmpty test for {browser} failed");
            }
        }

        [Theory]
        [InlineData("chrome")]
        [InlineData("firefox")]
        public void ShouldShowUsernameRequiredError_WhenUsernameIsEmpty(string browser)
        {
            try
            {
                _logger.Information($"Starting UsernameIsEmpty test for {browser}");

                // Arrange
                using IWebDriver driver = WebDriverFactory.CreateDriver(browser);
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                LoginPage loginPage = new(driver);

                // Act
                loginPage.EnterCredentials("", "test");
                loginPage.ClearUsername();
                loginPage.ClickLogin();

                // Assert
                loginPage.GetErrorMessage().Should().Contain("Username is required");

                _logger.Information($"UsernameIsEmpty test for {browser} completed");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"UsernameIsEmpty test for {browser} failed");
            }
        }

        [Theory]
        [InlineData("chrome")]
        [InlineData("firefox")]
        public void ShouldShowPasswordRequiredError_WhenPasswordIsEmpty(string browser)
        {
            try
            {
                _logger.Information($"Starting PasswordIsEmpty test for {browser}");

                // Arrange
                using IWebDriver driver = WebDriverFactory.CreateDriver(browser);
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                var loginPage = new LoginPage(driver);

                // Act
                loginPage.EnterCredentials("standard_user", "test");
                loginPage.ClearPassword();
                loginPage.ClickLogin();

                // Assert
                loginPage.GetErrorMessage().Should().Contain("Password is required");

                _logger.Information($"PasswordIsEmpty test for {browser} completed");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"PasswordIsEmpty test for {browser} failed");
            }
        }

        [Theory]
        [InlineData("chrome")]
        [InlineData("firefox")]
        public void ShouldNavigateToDashboard_WhenCredentialsAreValid(string browser)
        {
            try
            {
                _logger.Information($"Starting CredentialsAreValid test for {browser}");

                // Arrange
                using IWebDriver driver = WebDriverFactory.CreateDriver(browser);
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                LoginPage loginPage = new(driver);

                // Act
                loginPage.EnterCredentials("standard_user", "secret_sauce");
                loginPage.ClickLogin();
                DashboardPage dashboardPage = new(driver);

                // Assert
                dashboardPage.GetTitle().Should().Be("Swag Labs");

                _logger.Information($"CredentialsAreValid test for {browser} completed");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"CredentialsAreValid test for {browser} failed");
            }
        }
    }
}
