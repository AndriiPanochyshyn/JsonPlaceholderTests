Feature: UserPhotoChecking

	- Check if photo with title "ad et natus qui" belongs to user with email "Sincere@april.biz"

Scenario: Check if photo with specific title belongs to user with specific email

	Given User opens JsonPlaceholder main page
	 When User opens Photos page
	  And User gets album id where photo title is 'ad et natus qui'
	  And User opens JsonPlaceholder main page
	  And User opens Albums page
	  And User gets user id where album has photo with title 'ad et natus qui'
	  And User opens JsonPlaceholder main page
	  And User opens Users page
	 Then User expects user email who has an photo with title 'ad et natus qui' to be 'Sincere@april.biz'