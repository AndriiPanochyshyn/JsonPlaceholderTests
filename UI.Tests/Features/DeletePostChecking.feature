Feature: DeletePostChecking
	
	- Check that new post can be deleted from the system

	Important: the resource will not be really deleted on the server but it will be faked as if.

Scenario: UI Check that new post can be deleted from the system

	Given User deletes post with id '1' from the system through api request
	 Then User expects reponse status to be 'OK'

	 When User opens JsonPlaceholder main page
	  And User opens Posts page
	 Then User expects post to be exist
	  | User id | Id | Title                                                                      | Body                                                                                                                                                              |
	  | 1       | 1  | sunt aut facere repellat provident occaecati excepturi optio reprehenderit | quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto |