Feature: AddPostChecking

	- Check that new post can be added into the system

	Important: the resource will not be really created on the server but it will be faked as if.
    In other words, if you try to access a post using 101 as an id, you'll get a 404 error.

Scenario: UI Check that new post can be added into the system
	
	Given User adds new post to system through api request
	  | UserId | Title      | Body      |
	  | 1      | Test title | Test body |
	 Then User expects reponse status to be 'Created'

	 When User opens JsonPlaceholder main page
	  And User opens Posts page
	 Then User expects post doesn't exist
	  | User id | Id  | Title      | Body      |
	  | 1       | 101 | Test title | Test body |