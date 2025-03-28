Feature: Login
  As a user
  I want to log in to the system
  So that I can access my account
  
  Scenario: Login with empty credentials
    Given I am on the login page
    When I enter "test" as username
    And I enter "test" as password
    And I clear both fields
    And I click the login button
    Then I should see the error message "Username is required"
