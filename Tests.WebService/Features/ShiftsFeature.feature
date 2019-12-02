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
@CreateAssignment
@PostShift
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
| 1.InTeFutureWithBreaks | 15            | 25            | 2021-12-02 08:09 | 2021-12-02 10:09 |
| 2.WithoutBreaks        | 0             | 0             | 2021-12-02 08:09 | 2021-12-02 10:09 |
| 3.ShiftInThePast       | 15            | 25            | 2019-11-15 08:09 | 2019-11-15 10:09 |

@CreateLocation
@CreateArea
@CreateRole
@CreateDepartment
@CreateJobTitle
@CreateEmployee
@CreateAssignment
@PostShift
Scenario Outline: Post Shift invalid data
	Given the /locations/{locationId}/departments/{departmentId}/shifts/ resource
	 And the following url segments
	 | Name         | Value          |
	 | locationId   | $Location.ID   |
	 | departmentId | $Department.ID |
	 And request has a shift as a body with parameters
	 | Field         | Value            |
	 | EmployeeId    | <EmployeeId>     |
	 | RoleId        | <RoleId>         |
	 | Break1Minutes | 15               |
	 | Break2Minutes | 25               |
	 | StartDateTime | 2019-12-07 08:09 |
	 | EndDateTime   | 2019-12-07 10:09 |
	When a POST request is executed
	Then HTTP Code is 400
	
	Examples: 
| TestCase          | EmployeeId | RoleId  |
| 1.WrongEmployeeId | 1234567    |         |
| 2.WrongRoldeId    |            | 1234567 |  

@CreateAreaAnotherOrganisation
@CreateLocation
@CreateArea
@CreateRole
@CreateDepartmentAnotherLocationSameOrganisation
@CreateJobTitle
@CreateEmployee
@CreateAssignment
@PostShift
Scenario Outline: Post Shift from department from another location
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
	Then HTTP Code is 400

	Examples: 
| TestCase               | Break1Minutes | Break2Minutes | StartDateTime    | EndDateTime      |
| 1.InTeFutureWithBreaks | 15            | 25            | 2021-12-02 08:09 | 2021-12-02 10:09 |
| 2.WithoutBreaks        | 0             | 0             | 2021-12-02 08:09 | 2021-12-02 10:09 |
| 3.ShiftInThePast       | 15            | 25            | 2019-11-15 08:09 | 2019-11-15 10:09 |