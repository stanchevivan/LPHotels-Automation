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
Scenario: Get Labour Demand
    Given create dailyPeriod
		 | Field     | Value        |
		 | Name      | FirstSession |
		 | StartMins | 300          |
		 | EndMins   | 1020         |
		 
	
	Given the /locations/{locationId}/departments/{departmentId}/from/{from}/to/{to}/labour-demand/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	    | from         | 2030-02-01     |
	    | to           | 2030-02-02     |
		
	When a GET request is executed
	#Then HTTP Code is 200
	    And response
