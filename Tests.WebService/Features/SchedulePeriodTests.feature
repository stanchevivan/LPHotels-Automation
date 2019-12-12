Feature: SchedulePeriodTests

	As a user 
	I want to be able to save and edit shifts
	so that I can create a schedule


@CreateLocation
@CreateLocations
@LocationForAnotherOrganisation
@CreateArea
@CreateAreaAnotherOrganisation
@CreateRole
@CreateRoleForAnotherOrganisation
@CreateDepartment
@CreateAnotherDepartmentSameLocation
@CreateDepartmentAnotherLocationSameOrganisation
@CreateDepartmentAnotherOrganisation
@CreateJobTitle
@CreateEmployee
@CreateAnotherOrganisationEmployee
@CreateEmployees
@CreateMainAssignment
@CreateMainAssignments
@MainAssignmentForEmployeeAnotherOrganisation
Scenario Outline: Get Schedule period
    Given SchedulePeriod data is created for departments
	| Field         | Value            |
	| StartDateTime | 2030-01-15 07:09 |
	| EndDateTime   | 2030-01-15 08:00 |
	| ChargedDate   | 2030-01-15       |
	
	Given the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/schedule-period/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | 2030-01-15     |
	    | to           | 2030-01-18     |
		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response
	Examples: 
| TestCase               | Break1Minutes | Break2Minutes | StartDateTime    | EndDateTime      |
| 1.InTeFutureWithBreaks | 15            | 25            | 2022-01-02 08:09 | 2022-12-02 10:09 |
| 2.WithoutBreaks        | 0             | 0             | 2022-01-02 08:09 | 2022-1-02 10:09 |
| 3.ShiftInThePast       | 15            | 25            | 2019-01-15 08:09 | 2019-01-15 10:09 |


@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateEmployees
@CreateMainAssignment
Scenario: Get Schedule period for transition shift
    Given create and save shift in db
		 | Field         | Value            |
		 | StartDateTime | 2030-02-01 02:09 |
		 | EndDateTime   | 2030-02-02 08:00 |
		 | ChargedDate   | 2030-02-02       |
	
	Given the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/schedule-period/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | 2030-02-01     |
	    | to           | 2030-02-02     |
		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response


@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateEmployees
Scenario Outline: Get Schedule period for employee with assignment in the future or in the past
    Given create assignment
		| Field    | Value      |
		| FromDate | <fromDate> |
		| ToDate   | <toDate>   |		
	Given the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/schedule-period/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | <from>         |
	    | to           | <to>           |		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response
#CreateMainAssignmentInTheFuture
Examples: 
| TestCase                | fromDate   | toDate     | from       | to         |
| 1.AssignmentInTheFuture | 2030-02-06 |            | 2030-02-04 | 2030-02-06 |
| 2.AssignmentInThePast   | 2018-02-04 | 2019-11-11 | 2019-11-11 | 2019-11-12 |



@CreateLocation
@CreateArea
@CreateRole
@CreateAnotherRole
@CreateDepartment
@CreateAnotherDepartmentSameLocation
@CreateJobTitle
@CreateEmployee
Scenario Outline: Get Schedule period for employee with main and non main assignments with different roles and departments
    Given create assignment
		| Field    | Value      |
		| FromDate | <fromDateMain> |
		| ToDate   | <toDateMain>   |	
		And create non main assignment for another department, same location
		| Field    | Value      |
		| FromDate | <fromDateNonMain> |
		| ToDate   | <toDateNonMain>   |	
	    And the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/schedule-period/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | <from>         |
	    | to           | <to>           |		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response
#CreateMainAssignmentInTheFuture
Examples: 
| TestCase                | fromDateMain | toDateMain | fromDateNonMain | toDateNonMain | from       | to         |
| 1.AssignmentInTheFuture | 2030-03-02   |            | 2030-03-03      |               | 2030-03-01 | 2030-03-04 |



@CreateLocation
@CreateArea
@CreateRole
@CreateAnotherRole
@CreateDepartment
@CreateAnotherDepartmentSameLocation
@CreateJobTitle
@CreateEmployee
Scenario Outline: Get Schedule period for employee with shifts for non main assignments with another department, same location 
    Given create assignment
		| Field    | Value      |
		| FromDate | <fromDateMain> |
		| ToDate   | <toDateMain>   |	
		And create non main assignment for another department, same location
		| Field    | Value      |
		| FromDate | <fromDateNonMain> |
		| ToDate   | <toDateNonMain>   |	
		And create and save shift in db
		 | Field         | Value            |
		 | StartDateTime | 2030-03-05  08:09 |
		 | EndDateTime   | 2030-03-05  10:00 |
		 | ChargedDate   | 2030-03-05        |
		 And create and save shift in db for another department and role
		 | Field         | Value            |
		 | StartDateTime | 2030-03-06 08:09 |
		 | EndDateTime   | 2030-03-06 10:00 |
		 | ChargedDate   | 2030-03-06       |
	    And the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/schedule-period/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | <from>         |
	    | to           | <to>           |		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response
#CreateMainAssignmentInTheFuture
Examples: 
| TestCase                | fromDateMain | toDateMain | fromDateNonMain | toDateNonMain | from       | to         |
| 1.AssignmentInTheFuture | 2030-03-05   |            | 2030-03-06      |               | 2030-03-04 | 2030-03-07 |
######and for the same day

@CreateLocation
@CreateArea
@CreateRole
@CreateAnotherRole
@CreateDepartment
@CreateAnotherDepartmentSameLocation
@CreateJobTitle
@CreateEmployee
Scenario Outline: Get Schedule period for employee with shifts for non main assignments with another department, different location
    Given create assignment
		| Field    | Value      |
		| FromDate | <fromDateMain> |
		| ToDate   | <toDateMain>   |	
		And create non main assignment for another location, same organisation
		| Field    | Value      |
		| FromDate | <fromDateNonMain> |
		| ToDate   | <toDateNonMain>   |	
		And create and save shift in db
		 | Field         | Value            |
		 | StartDateTime | 2030-03-05  08:09 |
		 | EndDateTime   | 2030-03-05  10:00 |
		 | ChargedDate   | 2030-03-05        |
		 And create and save shift in db for another location, same organisation
		 | Field         | Value            |
		 | StartDateTime | 2030-03-06 08:09 |
		 | EndDateTime   | 2030-03-06 10:00 |
		 | ChargedDate   | 2030-03-06       |
	    And the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/schedule-period/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | <from>         |
	    | to           | <to>           |		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response
#CreateMainAssignmentInTheFuture
Examples: 
| TestCase                | fromDateMain | toDateMain | fromDateNonMain | toDateNonMain | from       | to         |
| 1.AssignmentInTheFuture | 2030-03-05   |            | 2030-03-06      |               | 2030-03-04 | 2030-03-07 |