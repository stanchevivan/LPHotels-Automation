Feature: ShiftFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@CreateLocation
@CreateDepartment
Scenario: Post Shift
	Given the /locations/{locationId}/departments/{departmentId}/shifts/ resource
	 And the following url segments
	 | Name         | Value          |
	 | locationId   | $Location.Id   |
	 | departmentId | $Department.Id |
	 And request has a shift as a body
	When a POST request is executed
	Then HTTP Code is 200
	 And the shift is created