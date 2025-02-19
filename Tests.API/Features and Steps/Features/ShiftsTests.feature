﻿Feature: ShiftsTests

	As a user 
	I want to be able to save and edit shifts
	so that I can create a schedule

#Scenario: Create Shift for given location and department
#	Given Shift is created to be imported
#	When Create Shift endpoint is requested to create shift for given location and department
#	Then The status code of the response should be 200
#	    And Created shift should be added in the db

@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateAssignment

Scenario Outline: CreateShift endpoint should return correct results
	Given NewShift is created to be imported
	    | Field         | Value           |
	    | Break1Minutes | <Break1Minutes> |
	    | Break2Minutes | <Break2Minutes> |
	    | StartDateTime | <StartDateTime> |
	    | EndDateTime   | <EndDateTime>   |
	When Create Shift endpoint is requested with CorrectData and <id>
	Then The status code of the response should be 200
	    And Created shift should be added in the db
Examples: 
| TestCase               | Break1Minutes | Break2Minutes | StartDateTime    | EndDateTime      |
| 1.InTeFutureWithBreaks | 15            | 25            | 2021-12-02 08:09 | 2021-12-02 10:09 |
| 2.WithoutBreaks        | 0             | 0             | 2021-12-02 08:09 | 2021-12-02 10:09 |
| 3.ShiftInThePast       | 15            | 25            | 2019-11-15 08:09 | 2019-11-15 10:09 |


@CreateLocation
@CreateArea
@CreateAreaAnotherOrganisation
@CreateRole
@CreateRoleForAnotherOrganisation
@CreateDepartment
@CreateDepartmentAnotherLocationSameOrganisation
@CreateJobTitle
@CreateEmployee
@CreateAnotherOrganisationEmployee
@CreateAssignment
Scenario Outline: CreateShift endpoint should return error when body's data is incorrect
	Given Shift is created to be imported with invalid data <invalidData>
	    | Field         | Value           |
	    | Break1Minutes | <Break1Minutes> |
	    | Break2Minutes | <Break2Minutes> |
	    | StartDateTime | <StartDateTime> |
	    | EndDateTime   | <EndDateTime>   |
	    | EmployeeId    | <Id>            |
	    | RoleId        | <Id>            |
	When Create Shift endpoint is requested with CorrectData and <id>
	Then The status code of the response should be 200
	    #And Error <errorMessage> should be returned
		And Shift should not be added in the db
Examples: 
| TestCase                                | invalidData                              | Id      | Break1Minutes | Break2Minutes | StartDateTime    | EndDateTime      | errorMessage                                                                             |
| 1.WhenEmployeeIsInvalid                 | shiftWithInvalidEmployeeId               | 1234567 | 15            | 25            | 2019-12-07 08:09 | 2019-12-07 10:09 | "oops, Some error happened."                                                             |
| 2.WhenEmployeeIsEmpty                   | shiftWithInvalidEmployeeId               | 1234567 | 15            | 25            | 2019-12-07 08:09 | 2019-12-07 10:09 | "oops, Some error happened."                                                             |
| 3.WhenRoleIsInvalid                     | shiftWithInvalidRoleId                   | 1234567 | 15            | 25            | 2019-12-07 08:09 | 2019-12-07 10:09 | "The selected member of staff is not available for scheduling on this role on this date" |
| 4.WhenRoleIsEmpty                       | shiftWithInvalidRoleId                   | 1234567 | 15            | 25            | 2019-12-07 08:09 | 2019-12-07 10:09 | "oops, Some error happened.                                                              |
| 5.WhenEmployeeIsFromAnotherOrganisation | shiftWithEmployeeFromAnotherOrganisation | 1234567 | 15            | 25            | 2019-12-07 08:09 | 2019-12-07 10:09 | "The selected member of staff is not available for scheduling on this date"              |
| 6.WhenRoleIsFromAnotherOrganisation     | shiftWithRoleFromAnotherOrganisation               | 1234567 | 15            | 25            | 2019-12-07 08:09 | 2019-12-07 10:09 | "The selected member of staff is not available for scheduling on this role on this date" |


@CreateLocation
@CreateLocations
@CreateArea
@CreateAreaAnotherOrganisation
@CreateRole
@CreateRoleForAnotherOrganisation
@CreateDepartment
@CreateDepartmentAnotherLocationSameOrganisation
@CreateJobTitle
@CreateEmployee
@CreateAnotherOrganisationEmployee
@CreateAssignment
Scenario Outline: CreateShift endpoint should return error for incorrect dates
	Given NewShift is created to be imported
	    | Field         | Value           |
	    | Break1Minutes | <Break1Minutes> |
	    | Break2Minutes | <Break2Minutes> |
	    | StartDateTime | <StartDateTime> |
	    | EndDateTime   | <EndDateTime>   |
	When Create Shift endpoint is requested with CorrectData and <id>
	Then The status code of the response should be 200
	    #And Error <errorMessage> should be returned
		And Shift should not be added in the db
Examples: 
| TestCase                           | Break1Minutes | Break2Minutes | StartDateTime    | EndDateTime      | errorMessage                                                                |
#| 1.ShiftInThePast                   | 15            | 25            | 2019-11-15 08:09 | 2019-11-15 10:09 | "ok."                                                                       |
| 2.WhenBreaksBiggerThenShift        | 30            | 30            | 2025-12-07 01:09 | 2025-12-07 02:00 | "Shift must be longer than total break time added"                          |
| 3.WhenBreakBiggerThenShift         | 0             | 60            | 2025-12-07 02:09 | 2025-12-07 03:00 | "Shift must be longer than total break time added"                          |
| 4.WhenShiftIsBeforeAssignmentStart | 15            | 25            | 2018-12-07 03:09 | 2018-12-07 04:00 | "The selected member of staff is not available for scheduling on this date" |
| 5.WhenShiftEndIsBeforeShiftStart   | 15            | 25            | 2025-12-07 06:09 | 2025-12-07 05:00 | "Shift must be longer than total break time added"                          |


@CreateLocation
@CreateLocations
@CreateArea
@CreateAreaAnotherOrganisation
@CreateRole
@CreateRoleForAnotherOrganisation
@CreateDepartment
@CreateDepartmentAnotherLocationSameOrganisation
@CreateJobTitle
@CreateEmployee
@CreateAnotherOrganisationEmployee
@CreateAssignment
Scenario Outline: CreateShift endpoint should return error for overlaping shifts
	Given NewShift is created to be imported
	    | Field         | Value           |
	    | Break1Minutes | <Break1Minutes> |
	    | Break2Minutes | <Break2Minutes> |
	    | StartDateTime | <StartDateTime> |
	    | EndDateTime   | <EndDateTime>   |
	    And Create Shift endpoint is requested with CorrectData and <id>
	    And The status code of the response should be 200
	    And NewShift is created to be imported
	    | Field         | Value           |
	    | Break1Minutes | <Break1Minutes> |
	    | Break2Minutes | <Break2Minutes> |
	    | StartDateTime | <StartDateTime> |
	    | EndDateTime   | <EndDateTime>   |
	When Create Shift endpoint is requested with CorrectData and <id>
	Then The status code of the response should be 200
	    #And Error <errorMessage> should be returned
		And Shift should not be added in the db
Examples: 
| Break1Minutes | Break2Minutes | StartDateTime    | EndDateTime      | errorMessage |
| 15            | 25            | 2025-11-17 08:09 | 2025-11-17 10:09 | "The shift could not be added because it overlaps with another"        |


@CreateLocation
@CreateLocations
@LocationForAnotherOrganisation
@CreateArea
@CreateAreaAnotherOrganisation
@CreateRole
@CreateRoleForAnotherOrganisation
@CreateDepartment
@CreateDepartmentAnotherOrganisation
@CreateDepartmentAnotherLocationSameOrganisation
@CreateJobTitle
@CreateEmployee
@CreateAnotherOrganisationEmployee
@CreateAssignment
Scenario Outline: CreateShift endpoint should return error for incorrect locationId or departmentId
	When Create Shift endpoint is requested with <data> and <id>
	Then The status code of the response should be <code>
Examples: 
| TestCase                                        | data                                          | id     | code |
| 1.MissingLocation                               | InvalidLocationId                             |        | 404  |
| 2.InvalidLocation                               | InvalidLocationId                             | 123456 | 401  |
| 3.MissingDepartment                             | InvalidDepartmentId                           |        | 404  |
| 4.InvalidDepartment                             | InvalidDepartmentId                           | 123456 | 404  |
| 5.LocationAnotherOrganisation                   | LocationFromAnatherOrganisation               | 123456 | 401  |
| 6.DepartmentAnotherOrganisation                 | DepartmentFromAnatherOrganisation             | 123456 | 404  |
| 7.DepartmentFromAnatherLocationSameOrganisation | DepartmentFromAnatherLocationSameOrganisation | 123456 | 401  |


Scenario: Update Shift
    Given 1 shifts are created and saved into database
	    And Shift is updated to be imported
	When Update Shift endpoint is requested
	Then The status code of the response should be 200
	    And Shift should be updated in the db

@CreateLocation
@CreateLocations
@LocationForAnotherOrganisation
@CreateArea
@CreateAreaAnotherOrganisation
@CreateRole
@CreateRoleForAnotherOrganisation
@CreateDepartment
@CreateDepartmentAnotherOrganisation
@CreateDepartmentAnotherLocationSameOrganisation
@CreateJobTitle
@CreateEmployee
@CreateAnotherOrganisationEmployee
@CreateAssignment
@CreateShift
Scenario: Delete Shift
    Given 1 shifts are created and saved into database
	    And Delete Shift model is created to be imported
	When Delete Shift endpoint is requested
	Then The status code of the response should be 200
	    And Shift should be deleted from db

Scenario: Delete Shift enpoind should return error with invalid locationId ordepartmentId
	When Delete Shift endpoint is requested with <invalidData> and <id>
	Then The status code of the response should be <code>
Examples: 
| TestCase            | data                | id     | code |
| 1.MissingLocation   | InvalidLocationId   |        | 404  |
| 2.InvalidLocation   | InvalidLocationId   | 123456 | 401  |
| 3.MissingDepartment | InvalidDepartmentId |        | 404  |
| 4.InvalidDepartment | InvalidDepartmentId | 123456 | 404  |


Scenario: Delete Shift enpoind should return error with invalid shiftId
	When Delete Shift endpoint is requested with <invalidData> and <id>
	Then The status code of the response should be <code>
	    #And Shift should be deleted from db
Examples: 
| data           | id     | code | error                   |
| InvalidShiftId | 123456 | 200  | "Shift does not exist." |