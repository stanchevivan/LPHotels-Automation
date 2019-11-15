Feature: ShiftsTests

	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: Create Shift for given location and department
	Given Shift Entity is created to be imported
	When Create Shift endpoint is requested to create shift for given location and department
	Then The status code of the response should be 200
	Examples: :
| count |
| 1     |


Scenario Outline: Update Shift
    Given 1 shifts are created and saved into database
	    And Shift Entity is updated to be imported
	When Update Shift endpoint is requested
	Then The status code of the response should be 200
	Examples: :
| count |
| 1     |


Scenario: Delete Shift
    Given 1 shifts are created and saved into database
	When Delete Shift endpoint is requested
	Then The status code of the response should be 200