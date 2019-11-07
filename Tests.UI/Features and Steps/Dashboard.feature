Feature: Dashboard
	
Scenario Outline: Open create shift window
	Given LPH app is open on "<environment>"
	When shift window is open at "5" "5"
    Then shift popover is present
    @QA
    Examples:
    |environment|
    |QA         |

    @local
    Examples:
    |environment|
    |local      |