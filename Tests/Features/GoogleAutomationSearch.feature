Feature: GoogleAutomationSearch

Scenario: Verify that title contains searched word 'Automation' after opening first link

	Given User opens Google main page
	  And User input 'automation' to google entry field
	 Then User press 'Enter' on keyboard

