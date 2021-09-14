Feature: PlanITpoker
	Simple form to login user

@mytag
Scenario: When email and password are valid the login is successful
	Given the first input is "mailnou273@gmail.com"
	And the second input is "planit273"
	When clicking the login button
	Then the title of the current page should be "Recent Rooms"

	@mytag
Scenario: When password is missing
	Given the first input is "mailnou273@gmail.com"
	And the second input is ""
	When clicking the login button
	Then the error message for wrong password should appear "Please fill all the required fields."

	@mytag
Scenario: When email is missing
	Given the first input is ""
	And the second input is "planit273"
	When clicking the login button
	Then the error message for wrong password should appear "Invalid email address."

	@mytag
Scenario: When email is invalid
	Given the first input is "mailnou"
	And the second input is "planit273"
	When clicking the login button
	Then the error message for wrong password should appear "You have provided invalid credentials."

	@mytag
Scenario: When password is invalid
	Given the first input is "mailnou273u@gmail.com"
	And the second input is "planit"
	When clicking the login button
	Then the error message for wrong password should appear "You have provided invalid credentials."

	@mytag
Scenario: When email and password are both invalid 
	Given the first input is "mailnou25@gmail.com"
	And the second input is "planit25"
	When clicking the login button
	Then the title of the current page should be "You have provided invalid credentials."

	@mytag
Scenario: When email has special characters
	Given the first input is "mailnou$25@gmail.com"
	And the second input is "planit273"
	When clicking the login button
	Then the title of the current page should be "Invalid email address."

	@mytag
Scenario: When the password has special characters
	Given the first input is "mailnou$25@gmail.com"
	And the second input is "planit$@273"
	When clicking the login button
	Then the title of the current page should be "You have provided invalid credentials."

	@mytag
Scenario: When email and password are empty
	Given the first input is ""
	And the second input is ""
	When clicking the login button
	Then the title of the current page should be "Invalid email address."

	@mytag
Scenario: When email is a very long string
	Given the first input is "fredbvdfsnvlsdnvjsalbnvjuhdsfabvhlsabvshdabvsdbvsdbvsbvslbvsjhbvbvbvbvbvbvbvbvhdsbvcasbvcaslbvashblvasjbvlajsvbdjhsbvsabvhjsbvcbnhjsdbvcsdhjbvcjhdsbvsabvcsajnvsdjnvshdbvsfhdljvbdsrfvjlbdsavlfdsnvfesurbvsdarugvbrasdlhfurhfrughvbrugvedvhnreuljhve@gmail.com"
	And the second input is "planit273"
	When clicking the login button
	Then the title of the current page should be "Invalid email address."

