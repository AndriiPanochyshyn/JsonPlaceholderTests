Feature: GoogleAutomationSearch

Background:
	
	Given User opens Google main page

Scenario: Verify that title contains searched word 'Automation' after opening first link

	Given User input 'automation' to google entry field
	 Then User press 'Enter' on keyboard after input text to google

	 When User opens first link after search
	 Then User expect website title contains 'automation'

Scenario Outline: Verify that there is domain on search results pages 1-5

	Given User input '<TextForSearch>' to google entry field
	  And User press 'Enter' on keyboard after input text to google
	 Then User check first '5' pages for domain 'testautomationday.com' availability

Examples: 

	| TextForSearch         | SearchResult                  |
	| automation            | testautomationday.com         |
	| testautomationday.com | testautomationday.com         |
	| testautomation        | https://www.training.epam.ua/ |

