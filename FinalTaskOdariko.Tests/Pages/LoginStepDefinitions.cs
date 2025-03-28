using System;
using FinalTaskOdariko.Factories;
using FinalTaskOdariko.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using Reqnroll;
using Serilog;

namespace FinalTaskOdariko.Tests.Pages
{
    [Binding]
    public class LoginStepDefinitions(LoginPage loginPage)
    {
        private readonly LoginPage _loginPage = loginPage;
        private readonly IWebDriver _driver = WebDriverFactory.CreateDriver("chrome");

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When("I enter {string} as username")]
        public void WhenIEnterAsUsername(string test)
        {
            _loginPage.EnterUsername(test);
        }

        [When("I enter {string} as password")]
        public void WhenIEnterAsPassword(string test)
        {
            _loginPage.EnterPassword(test);
        }

        [When("I clear both fields")]
        public void WhenIClearBothFields()
        {
            _loginPage.ClearCredentials();
        }

        [When("I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _loginPage.ClickLogin();
        }

        [Then("I should see the error message {string}")]
        public void ThenIShouldSeeTheErrorMessage(string p0)
        {
            _loginPage.GetErrorMessage().Should().Contain(p0);
        }
    }
}
