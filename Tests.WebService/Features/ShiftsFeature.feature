Feature: ShiftsFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateMainAssignment
@PostShiftModel
Scenario Outline: Post Shift
	Given the /locations/{locationId}/departments/{departmentId}/shifts/ resource
		And the following url segments
	    | Name         | Value          |
		| locationId   | $Location.ID   |
		| departmentId | $Department.ID |
		And request has a shift as a body with parameters
		| Field         | Value           |
		| Break1Minutes | <Break1Minutes> |
		| Break2Minutes | <Break2Minutes> |
		| StartDateTime | <StartDateTime> |
		| EndDateTime   | <EndDateTime>   |	 
	When a POST request is executed
	Then HTTP Code is 200
	    And the shift is created
	Examples: 
| TestCase               | Break1Minutes | Break2Minutes | StartDateTime    | EndDateTime      |
| 1.InTeFutureWithBreaks | 15            | 25            | 2022-12-02 08:09 | 2022-12-02 10:09 |
| 2.WithoutBreaks        | 0             | 0             | 2022-12-02 08:09 | 2022-12-02 10:09 |
| 3.ShiftInThePast       | 15            | 25            | 2019-10-15 08:09 | 2019-10-15 10:09 |








#@CreateLocation
#@LocationForAnotherOrganisation
#@CreateArea
#@CreateAreaAnotherOrganisation
#@CreateRole
#@CreateRoleForAnotherOrganisation
#@CreateDepartment
#@CreateDepartmentAnotherOrganisation
#@CreateJobTitle
#@CreateEmployee
#@CreateAnotherOrganisationEmployee
#@MainAssignmentForEmployeeAnotherOrganisation
#@CreateAssignment
#@PostShiftModel
#Scenario Outline: Post Shift invalid body data
#	Given the /locations/{locationId}/departments/{departmentId}/shifts/ resource
#		 And the following url segments
#		 | Name         | Value          |
#		 | locationId   | $Location.ID   |
#		 | departmentId | $Department.ID |
#	    And request has a shift as a body with parameters
#		| Field         | Value           |
#		| EmployeeId    | <EmployeeId>    |
#		| RoleId        | <RoleId>        |
#		| Break1Minutes | <Break1Minutes> |
#		| Break2Minutes | <Break2Minutes> |
#		| StartDateTime | <StartDateTime> |
#		| EndDateTime   | <EndDateTime>   |
#	When a POST request is executed
#	#Then HTTP Code is <Code>
#		 And Error <error> should be returned	
#	Examples: 
#| TestCase          | EmployeeId | RoleId | Code | Error                  |
#| 1.WrongEmployeeId | 123        |     123  | 500  | An error has occurred. |
#| 3.WrongRoldeId    |            | 123    | 500  | An error has occurred. |
#| 5.EmployeeIsFromAnotherOrganisation | shiftWithEmployeeFromAnotherOrganisation | 500  |                        |
#| 6.RoleIsFromAnotherOrganisation     | shiftWithRoleFromAnotherOrganisation     | 500  |                        |
#| 2.MissingEmployeeId                 |                              | $Role.ID                   |      |                        |
#| 4.MissingRoldeId                    | $Employee.ID                 |                    |      |                        |




#ok
@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateMainAssignment
@PostShiftModel
Scenario Outline: CreateShift endpoint should return error for incorrect dates
	Given the /locations/{locationId}/departments/{departmentId}/shifts/ resource
		And the following url segments
	    | Name         | Value          |
		| locationId   | $Location.ID   |
		| departmentId | $Department.ID |
		And request has a shift as a body with parameters
		| Field         | Value           |
		| Break1Minutes | <Break1Minutes> |
		| Break2Minutes | <Break2Minutes> |
		| StartDateTime | <StartDateTime> |
		| EndDateTime   | <EndDateTime>   |	 
	When a POST request is executed
	Then HTTP Code is <Code>
	    And Error <errorMessage> should be returned
	Examples: 
	| TestCase                           | Break1Minutes | Break2Minutes | StartDateTime    | EndDateTime      | errorMessage                                                                | Code |
	| 2.WhenBreaksBiggerThenShift        | 30            | 30            | 2025-12-07 01:09 | 2025-12-07 02:00 | "Shift must be longer than total break time added"                          | 400  |
	| 3.WhenBreakBiggerThenShift         | 0             | 60            | 2025-12-07 02:09 | 2025-12-07 03:00 | "Shift must be longer than total break time added"                          |     400 |
	#| 4.WhenShiftIsBeforeAssignmentStart | 15            | 25            | 2018-12-07 03:09 | 2018-12-07 04:00 | "The selected member of staff is not available for scheduling on this date" |     200 |
	| 5.WhenShiftEndIsBeforeShiftStart   | 15            | 25            | 2025-12-07 06:09 | 2025-12-07 05:00 | "Shift must be longer than total break time added"                          |   400   |



#ok
@CreateLocation
@CreateAreaAnotherOrganisation
@LocationForAnotherOrganisation
@CreateArea
@CreateRole
@CreateRoleForAnotherOrganisation
@CreateDepartment
@CreateDepartmentAnotherOrganisation
@CreateJobTitle
@CreateEmployee
@CreateAnotherOrganisationEmployee
@CreateMainAssignment
@MainAssignmentForEmployeeAnotherOrganisation
@CreateShift
Scenario Outline: Post Shift should return error when missing locationId, departmentId or shiftId
	Given the /locations/{locationId}/departments/{departmentId}/shifts/{id}/ resource
	    And the following url segments
	    | Name         | Value          |
	    | locationId   | <locationId>   |
	    | departmentId | <departmentId> |
	When a DELETE request is executed
	Then HTTP Code is <Code>
	Examples: 
| TestCase            | locationId   | departmentId   | Code |
| 1.MissingLocation   |              | $Department.ID | 404  |
| 2.InvalidLocation   | 123456       | $Department.ID | 401  |
| 3.MissingDepartment | $Location.ID |                | 404  |
| 4.InvalidDepartment | $Location.ID | 123456         | 404  |



@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateMainAssignment
@PostShiftModel
Scenario Outline: Post Shift endpoint should return error for overlaping shifts
	Given the /locations/{locationId}/departments/{departmentId}/shifts/ resource
		And the following url segments
	    | Name         | Value          |
		| locationId   | $Location.ID   |
		| departmentId | $Department.ID |
		And request has a shift as a body with parameters
		| Field         | Value           |
		| Break1Minutes | <Break1Minutes> |
		| Break2Minutes | <Break2Minutes> |
		| StartDateTime | <StartDateTime> |
		| EndDateTime   | <EndDateTime>   |	 
	When a POST request is executed
	Then HTTP Code is 200
	    And request has a shift as a body with parameters
		| Field         | Value           |
		| Break1Minutes | <Break1Minutes> |
		| Break2Minutes | <Break2Minutes> |
		| StartDateTime | <StartDateTime> |
		| EndDateTime   | <EndDateTime>   |
	    And a POST request is executed
	Then HTTP Code is 400
	    And Error <errorMessage> should be returned
Examples: 
| Break1Minutes | Break2Minutes | StartDateTime    | EndDateTime      | errorMessage |
| 15            | 25            | 2025-11-17 08:09 | 2025-11-17 10:09 | "The shift could not be added because it overlaps with another"        |




#delete

@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateMainAssignment
@CreateShift
@DeleteShiftModel
Scenario Outline: Delete Shift
	Given the /locations/{locationId}/departments/{departmentId}/shifts/{id}/ resource
	    And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | id           | $Shift.ID      |
		And request has the following body
        """
		<employeeId>

        """
	When a DELETE request is executed
	Then HTTP Code is 200
	    And shift should be deleted from db
Examples:
| employeeId   |
| $Employee.ID |


@CreateLocation
@CreateAreaAnotherOrganisation
@LocationForAnotherOrganisation
@CreateArea
@CreateRole
@CreateRoleForAnotherOrganisation
@CreateDepartment
@CreateDepartmentAnotherOrganisation
@CreateJobTitle
@CreateEmployee
@CreateAnotherOrganisationEmployee
@CreateMainAssignment
@MainAssignmentForEmployeeAnotherOrganisation
@CreateShift
Scenario Outline: Delete Shift should return error when missing locationId, departmentId or shiftId
	Given the /locations/{locationId}/departments/{departmentId}/shifts/{id}/ resource
	    And the following url segments
	    | Name         | Value          |
	    | locationId   | <locationId>   |
	    | departmentId | <departmentId> |
	    | id           | <shiftId>      |
	When a DELETE request is executed
	Then HTTP Code is <Code>
	Examples: 
| TestCase            | locationId   | departmentId   | shiftId   | Code |
| 1.MissingLocation   |              | $Department.ID | $Shift.ID | 404  |
| 2.InvalidLocation   | 123456       | $Department.ID | $Shift.ID | 401  |
| 3.MissingDepartment | $Location.ID |                | $Shift.ID | 404  |
| 4.InvalidDepartment | $Location.ID | 123456         | $Shift.ID | 404  |


@CreateLocation
@CreateLocations
@CreateAreaAnotherOrganisation
@LocationForAnotherOrganisation
@CreateArea
@CreateRole
@CreateRoleForAnotherOrganisation
@CreateDepartment
@CreateDepartmentAnotherOrganisation
@CreateAnotherDepartmentSameLocation
@CreateDepartmentAnotherLocationSameOrganisation
@CreateJobTitle
@CreateEmployee
@CreateAnotherOrganisationEmployee
@CreateMainAssignment
@MainAssignmentForEmployeeAnotherOrganisation
@CreateShift
Scenario Outline: Delete Shift should return error when shiftId is incorrect
Given shift for depatment with <locationData> is created and saved into database
	    And the /locations/{locationId}/departments/{departmentId}/shifts/{id}/ resource
	    And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID  |
	    | departmentId | $Department.ID |
	    | id           | <shiftId>    |
	When a DELETE request is executed
	Then HTTP Code is <Code>
	    And Error <error> should be returned
	Examples: 
| TestCase                                    | locationData                    | shiftId                                  | Code | error                 |
| 1.ShiftIsFromAnothrOgranisation             | locationAnotherOrganisation     | $ShiftLocationAnotherOrganisation.ID     | 400  | Invalid request       |
| 2.ShiftIsFromAnothrLocationSameOrganisation | anotherLocationSameOrganisation | $ShiftAnotherLocationSameOrganisation.ID | 400  | Invalid request       |
| 3.ShiftIsFromSameLocationAnotherDepartment  | sameLocationAnotherDepartment   | $ShiftSameLocationAnotherDepartment.ID   | 400  | Invalid request       |
| 4.MissingShiftId                            |                                 |                                          | 405  |                       |
| 5.InvalidShiftId                            |                                 | 123456                                   | 400  | Shift does not exist. |


@CreateLocation
@CreateAreaAnotherOrganisation
@LocationForAnotherOrganisation
@CreateArea
@CreateRole
@CreateRoleForAnotherOrganisation
@CreateDepartment
@CreateDepartmentAnotherOrganisation
@CreateJobTitle
@CreateEmployee
@CreateAnotherOrganisationEmployee
@CreateMainAssignment
@MainAssignmentForEmployeeAnotherOrganisation
@DeleteShiftModel
Scenario Outline: Delete Shift should return error when body is with incorrect EmployeeId
    Given shift for depatment with sameLocationSameOrganisation is created and saved into database
	    And the /locations/{locationId}/departments/{departmentId}/shifts/{id}/ resource
	    And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | id           | $Shift.ID      |
	    And request has the following body
        """
		<employeeId>

        """
	When a DELETE request is executed
	Then HTTP Code is 400
	    And Error <error> should be returned
	Examples: 
| TestCase                            | employeeId                  | locationAndOrganisation      | error                   |
| 1.MissingEmployeeId                 |                             | sameLocationSameOrganisation | The request is invalid. |
| 2.EmployeeIdFromAnotherOrganisation | EmployeeAnotherOrganisation | sameLocationSameOrganisation | The request is invalid. |

