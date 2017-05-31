Feature: Transunion Home Page
	As a Transunion Customer
	I want to be able to navigate to the Transunion Home Page

@Smoke
Scenario: Navigate to My Credit Score and Report Page from the Home Page
	Given I go to the "https://www.transunion.com" Home Page 
	When I Tap the My Credit Score and Report button
	Then I am able to sign up to receive My Credit Score
