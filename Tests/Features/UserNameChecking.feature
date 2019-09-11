Feature: UserNameChecking

	- Check if user who posted a post with title "eos dolorem iste accusantium est eaque quam" name is "Patricia Lebsack"

Scenario: Check if user who posted a post with specific title has specific name

	Given User opens JsonPlaceholder main page
	 When User opens Posts page
	  And User get user id who has a post with title 'eos dolorem iste accusantium est eaque quam'
	  And User opens JsonPlaceholder main page
	  And User opens Users page
	 Then User expects user name who has a post with title 'eos dolorem iste accusantium est eaque quam' to be 'Patricia Lebsack'