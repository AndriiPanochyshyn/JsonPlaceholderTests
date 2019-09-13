Feature: UpdatePostChecking
	
	- Check that new post can be updated into the system

	Important: the resource will not be really updated on the server but it will be faked as if.

Scenario Outline: UI Check that new post can be updated into the system

	Given User <Method> post in the system through api request
	  | UserId | Id | Title      | Body      |
	  | 1      | 1  | Test title | Test body |
	 Then User expects reponse status to be 'OK'

	 When User opens JsonPlaceholder main page
	  And User opens Posts page
	 Then User expects post doesn't exist
	  | User id | Id | Title      | Body      |
	  | 1       | 1  | Test title | Test body |

Examples: 
	| Method |
	| put    |
	| patch  |
