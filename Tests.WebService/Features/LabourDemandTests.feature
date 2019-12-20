Feature: LabourDemandTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateEmployees
@CreateMainAssignment
Scenario: Get Labour Demand when one shift
    Given create dailyPeriods	
	    And create sales types
		And create actual sales
		| Field     | Value      |
		| SalesDate | 2019-12-06 |
		And create rule with <requiredHours> and <amount>
		 Given create and save shift in db
		 | Field                   | Value            |
		 | StartDateTime           | 2019-12-06 06:00 |
		 | EndDateTime             | 2019-12-06 14:00 |
		 | ChargedDate             | 2019-12-06       |
		 | Break1DurationInMinutes | 60               |
		 #| Break2DurationInMinutes |                |
		 
		 
	Given the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/labour-demand/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | 2019-12-06   |
	    | to           | 2019-12-06     |
		
	When a GET request is executed
	#And response
	#Then HTTP Code is 200
	    And response should be with correct values <fromDate>, <scheduledHoursFirstSession>, <requiredHours>
		Examples: 
| fromDate   | requiredHours | amount | scheduledHoursFirstSession | scheduledHoursSecondSession |
| 2019-12-06 | 20            | 100    | 6                          | 2                           |


@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateEmployees
@CreateMainAssignment
Scenario: Get Labour Demand when more then one shift
    Given create dailyPeriods	
	    And create sales types
		And create actual sales
		| Field     | Value      |
		| SalesDate | 2019-12-09 |
		And create rule with <requiredHours> and <amount>
		 Given create and save shift in db
		 | Field         | Value            |
		 | StartDateTime | 2019-12-09 06:00 |
		 | EndDateTime   | 2019-12-09 07:00 |
		 | ChargedDate   | 2019-12-09       |
	Given the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/labour-demand/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | 2019-12-09     |
	    | to           | 2019-12-09     |
		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response
		Examples:
| TestCase1 | requiredHours | amount |
|           | 14             | 30   |






@CreateLocation
@CreateArea
@CreateRole
@CreateRoles
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateEmployees
@CreateMainAssignment
Scenario: Get Labour Demand when shift is from another role
    Given create dailyPeriods	
	    And create sales types
		And create actual sales
		| Field     | Value      |
		| SalesDate | 2019-12-09 |
		And create rule with <requiredHours> and <amount>
		 Given create and save shift in db for another  role same departments
		 | Field         | Value            |
		 | StartDateTime | 2019-12-09 06:00 |
		 | EndDateTime   | 2019-12-09 07:00 |
		 | ChargedDate   | 2019-12-09       |
	Given the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/labour-demand/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | 2019-12-09     |
	    | to           | 2019-12-09     |
		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response
		Examples:
| TestCase1 | requiredHours | amount |
|           | 14            | 30     |



@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateEmployees
@CreateMainAssignment
Scenario: Get Labour Demand when two shifts in different sessions
    Given create dailyPeriods	
	    And create sales types
		And create actual sales
		| Field     | Value      |
		| SalesDate | 2019-12-10 |
		And create rule with <requiredHours> and <amount>
		 Given create and save shift in db
		 | Field         | Value            |
		 | StartDateTime | 2019-12-10 06:00 |
		 | EndDateTime   | 2019-12-10 07:00 |
		 | ChargedDate   | 2019-12-10       |
		 Given create and save shift in db
		 | Field         | Value            |
		 | StartDateTime | 2019-12-10 13:00 |
		 | EndDateTime   | 2019-12-10 14:00 |
		 | ChargedDate   | 2019-12-10       |
	Given the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/labour-demand/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | 2019-12-10     |
	    | to           | 2019-12-10     |
		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response
		Examples:
| TestCase1 | requiredHours | amount |
|     all rules affected      | 14             | 100   |
#|     when only one rule affected      | 14             | 30   |


@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateEmployees
@CreateMainAssignment
Scenario: Get Labour Demand when shifts are crossing two sessions
    Given create dailyPeriods	
	    And create sales types
		And create actual sales
		| Field     | Value      |
		| SalesDate | 2019-12-12 |
		And create rule with <requiredHours> and <amount>
		 Given create and save shift in db
		 | Field         | Value            |
		 | StartDateTime | 2019-12-12 11:00 |
		 | EndDateTime   | 2019-12-12 13:00 |
		 | ChargedDate   | 2019-12-12       |
		 Given create and save shift in db
		 | Field         | Value            |
		 | StartDateTime | 2019-12-12 10:00 |
		 | EndDateTime   | 2019-12-12 14:00 |
		 | ChargedDate   | 2019-12-12       |
	Given the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/labour-demand/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | 2019-12-11     |
	    | to           | 2019-12-13     |
		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response
		Examples:
| TestCase1 | requiredHours | amount |
|     all rules affected      | 14             | 100   |


@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateEmployees
@CreateMainAssignment
Scenario: Get Labour Demand when shift after 24h
    Given create dailyPeriods	
	    And create sales types
		And create actual sales
		| Field     | Value      |
		| SalesDate | 2019-11-03 |
		And create rule with 14 and 100		
		 Given create and save shift in db
		 | Field         | Value            |
		 | StartDateTime | 2019-11-03 23:00 |
		 | EndDateTime   | 2019-11-04 02:00 |
		 | ChargedDate   | 2019-11-03       |
	Given the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/labour-demand/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | 2019-11-03     |
	    | to           | 2019-11-04     |
		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response
		Examples:
| TestCase1 | requiredHours | amount |
|           | 14             | 30   |