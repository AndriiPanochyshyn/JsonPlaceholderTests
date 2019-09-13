Feature: UserEmailChecking

	- Check if email of user who left a comment with "ipsum dolorem" text in comment's body is "Marcia@name.biz"

Scenario Outline: UI Check if email of user who left a comment with text in comment's body is

	Given User opens JsonPlaceholder main page
	 When User opens Comments page
	 Then User expects comment with text '<CommentInnerText>' in body to have email '<Email>'

Examples: 
	| CommentInnerText | Email            |
	| ipsum dolorem    | Marcia@name.biz  |
	| ipsum dolorem    | Jackeline@eva.tv |