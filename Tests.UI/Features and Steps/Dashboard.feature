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
    When Test step

    @local
    Examples:
    |environment|
    |local      |