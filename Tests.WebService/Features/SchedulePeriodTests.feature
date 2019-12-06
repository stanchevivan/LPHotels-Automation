Feature: SchedulePeriodTests

	As a user 
	I want to be able to save and edit shifts
	so that I can create a schedule


@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateMainAssignment
@PostShiftModel
Scenario Outline: Get Schedule period
	Given the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/schedule-period/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | 2019-11-12 |
	    | to           | 2019-11-22 |
	When a GET request is executed
	#Then HTTP Code is 200
	    And the shift is created
	Examples: 
| TestCase               | Break1Minutes | Break2Minutes | StartDateTime    | EndDateTime      |
| 1.InTeFutureWithBreaks | 15            | 25            | 2022-12-02 08:09 | 2022-12-02 10:09 |
| 2.WithoutBreaks        | 0             | 0             | 2022-12-02 08:09 | 2022-12-02 10:09 |
| 3.ShiftInThePast       | 15            | 25            | 2019-10-15 08:09 | 2019-10-15 10:09 |

