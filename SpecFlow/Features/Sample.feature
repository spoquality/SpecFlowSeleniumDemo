Feature: SpecFlow Selenium Sample

@Home
Scenario: Sign In Link Exists
	Given I have navigated to my test site
	When the Home page loads
	Then the Sign In link appears on the Home page

@Home @SignIn
Scenario: Sign In Link Takes User To The Sign In Page
	Given I have navigated to my test site
	When I click the Sign In link
	Then I am taken to the Sign In page

@SignIn
Scenario: User Can Enter Email To Start Create Account Process
	Given I have navigated to my test site
	And I have clicked the Sign In link
	When I enter an email address
    And I click the Create New Account button
	Then I am taken to the Create Account page

@CreateAccount
Scenario: User Can Register With Minimal Information
	Given I have navigated to my test site
	And I have started the Create account process
	When I enter the minimal information required
    And I click the Register button
	Then my new user is successfully created

@SignIn
Scenario: Newly Created User Can Login
	Given I have navigated to my test site
	And I have already created a new user
	When I click the Sign In link
    And I enter my login information
    And I click the Sign In button
	Then I successfully login to the site