Feature: UserTodosChecking

	- Check that Leanne Graham has more than 3 "completed" TODOs than Ervin Howell

Scenario: UI Check that Leanne Graham has more than 3 "completed" TODOs than Ervin Howell

	Given User opens JsonPlaceholder main page
	 When User opens Users page
	  And User get user ids with names:
	  | Name          |
	  | Leanne Graham |
	  | Ervin Howell  |
	  And User opens JsonPlaceholder main page
	  And User opens Todos page
	 Then User expects user with name 'Leanne Graham' has more than '3' completed TODOs than user with name 'Ervin Howell'


