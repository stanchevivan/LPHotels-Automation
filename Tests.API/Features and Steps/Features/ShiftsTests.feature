Feature: ShiftsTests

	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: Shifts
	Given Shift Entity is created to be imported
	When Shift endpoint is requested to create shift for the given location
	Then The status code of the response should be 200
	Examples: :
| count |
| 1     |
