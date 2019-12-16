Feature: Dashboard

    @sandbox @ignore
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

    @local
    Examples:
    |environment|
    |local      |

    Scenario Outline: Edit shift
        Given LPH app is open on "<environment>"
        When Shift details are opened for Role "C" Employee "MS" Start time "11:00" End time "2:15"
            * Shift details Start time is set to "22:11" and End Time is set to "23:21"
            * Shift details Save button is clicked
        Then Shift for Role "C" Employee "MS" Start time "22:11" End time "23:21" is "visible"

    @local
    Examples:
    |environment|
    |local      |

    Scenario Outline: Create shift
        Given LPH app is open on "<environment>"
        When new shift window is open for Role "C" Employee "II" for "10:00"
            * Shift details Start time is set to "10:11" and End Time is set to "11:21"
            * Shift details Save button is clicked
        Then Shift for Role "C" Employee "II" Start time "10:11" End time "11:21" is "visible"

    @QA
    Examples:
    |environment|
    |QA         |

    Scenario Outline: Delete shift
        Given LPH app is open on "<environment>"
        When Shift details are opened for Role "C" Employee "II" Start time "10:11" End time "11:21"
            * Shift details Delete button is clicked
        Then Shift for Role "C" Employee "II" Start time "10:11" End time "11:21" is "not visible"

    @QA
    Examples:
    |environment|
    |QA         |

    Scenario Outline: Daily total numbers equals sum of session totals
        Given LPH app is open on "<environment>"
        Then Verify Daily totals equal session totals

    @QA
    Examples:
    |environment|
    |QA         |

    Scenario Outline: Daily total pie chart percentages match daily total numbers
        Given LPH app is open on "<environment>"
        Then Verify Daily Total pie chart percentages are correct

    @QA
    Examples:
    |environment|
    |QA         |

    Scenario Outline: Session pie chart percentages match session total numbers
        Given LPH app is open on "<environment>"
        Then Verify Session pie chart percentages are correct

    @QA
    Examples:
    |environment|
    |QA         |