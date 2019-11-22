Feature: LocationsSteps
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


@CreateLocation
Scenario Outline: Add test
    Given Shift is created to be imported
	When Create Shift endpoint is requested with CorrectData and <id>
	And  The status code of the response should be 200
	#And Shift is deleted
	   # And  1 areas are created and saved into database
	Examples: 
| count |
| 1     |






@Organisation
Scenario: Add Test Bank
	Given bank are created and saved into database
