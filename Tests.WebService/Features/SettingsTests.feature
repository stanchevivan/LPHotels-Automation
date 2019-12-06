Feature: SettingsTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@CreateLocation
@CreateLocations
@LocationForAnotherOrganisation
@CreateDepartment
@CreateAnotherDepartmentSameLocation
@CreateDepartmentAnotherLocationSameOrganisation
@CreateDepartmentAnotherOrganisation
Scenario: Get Settings
    Given Daily peroods are created for departments
	Given the /locations/{locationId}/departments/{departmentId}/Settings/ resource
		And the following url segments
	    | Name         | Value          |
	    | locationId   | $Location.ID   |
	    | departmentId | $Department.ID |
	When a GET request is executed
	Then HTTP Code is 200
	    And the response should be correct


@CreateLocation
@CreateLocations
@LocationForAnotherOrganisation
@CreateDepartment
@CreateDepartmentAnotherLocationSameOrganisation
@CreateDepartmentAnotherOrganisation
Scenario Outline: Get Settings should return error when missing locationId or departmentId
	Given the /locations/{locationId}/departments/{departmentId}/shifts/{id}/ resource
	    And the following url segments
	    | Name         | Value          |
	    | locationId   | <locationId>   |
	    | departmentId | <departmentId> |
	When a PUT request is executed
	Then HTTP Code is <Code>
	Examples: 
| TestCase                                    | locationId                      | departmentId                                  | Code |
| 1.MissingLocation                           |                                 | $Department.ID                                | 404  |
| 2.InvalidLocation                           | 123456                          | $Department.ID                                | 401  |
| 3.MissingDepartment                         | $Location.ID                    |                                               | 404  |
| 4.InvalidDepartment                         | $Location.ID                    | 123456                                        | 404  |
| 5.DepartmentAnotherLocationSameOrganisation | $Location.ID                    | $DepartmentAnotherLocationSameOrganisation.ID | 401  |
| 6.DepartmentAnotherOrganisation             | $Location.ID                    | $DepartmentAnotherOrganisation.ID             | 404  |
| 7.DepartmentAnotherOrganisation             | $LocationAnotherOrganisation.ID | $Department.ID                                | 401  |



