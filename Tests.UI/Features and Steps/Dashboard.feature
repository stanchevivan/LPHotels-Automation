Feature: Dashboard

Scenario Outline: Open create shift window
	Given LPH app is open on "<environment>"
	When shift window is open at "5" "5"
    Then shift popover is present

    @QA
    Examples:
    |environment|
    |QA         |

    @local @MockGet
    Examples:
    |environment|
    |local      |

Scenario Outline: Shift Block is displayed in Schedule Grid
    Given LPH app is open on "<environment>"
    Then shift blocks are present

    @QA
    Examples:
    |environment|
    |QA         |

    @local
    Examples:
    |environment|
    |local      |

Scenario Outline: Test Shift
    Given LPH app is open on "<environment>"
    When Shift details are opened for Role "C" Employee "MS" Start time "11:00" End time "2:15"
        * Shift details Start time is set to "22:11" and End Time is set to "23:21"
        * Shift details Cancel button is clicked

    @local
    Examples:
    |environment|
    |local      |