Feature: Dashboard
	
Scenario: Open create shift window
	Given LPH app is open
	When shift window is open at "5" "5"
    Then shift popover is present