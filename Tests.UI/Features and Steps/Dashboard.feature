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


    Scenario Outline: Create shift
        Given LPH app is open on "<environment>"
        When new shift window is open for Role "<role>" Employee "<employee>" for "5:00"
            * Shift details Start time is set to "<startTime>" and End Time is set to "<endTime>"
            * Shift details Save button is clicked
        Then Shift for Role "<role>" Employee "<employee>" Start time "<startTime>" End time "<endTime>" is "visible"

    @QA
    Examples:
    |environment|role|employee|startTime|endTime|
    |QA         |R1  |SS      |5:30     |   7:30|  

    Scenario Outline: Edit shift
        Given LPH app is open on "<environment>"
        When Shift details are opened for Role "<role>" Employee "<employee>" Start time "<oldStartTime>" End time "<oldEndTime>"
            * Shift details Start time is set to "<newStartTime>" and End Time is set to "<newEndTime>"
            * Shift details Save button is clicked
        Then Shift for Role "<role>" Employee "<employee>" Start time "<newStartTime>" End time "<newEndTime>" is "visible"

    @local
    Examples:
    |environment|role|employee|oldStartTime|oldEndTime|newStartTime|newEndTime|
    |QA         |R1  |SS      |5:30        |7:30      |6:30        |8:30      |

    Scenario Outline: Delete shift
        Given LPH app is open on "<environment>"
        When Shift details are opened for Role "<role>" Employee "<employee>" Start time "<startTime>" End time "<endTime>"
            * Shift details Delete button is clicked
        Then Shift for Role "<role>" Employee "<employee>" Start time "<startTime>" End time "<endTime>" is "not visible"

    @QA
    Examples:
    |environment|role|employee|startTime|endTime|
    |QA         |R1  |SS      |6:30     |8:30   |

    Scenario Outline: Daily total numbers equals sum of session totals
        Given LPH app is open on "<environment>"
        When Role "<role>" is selected
        Then Verify Daily totals equal session totals

    @QA
    Examples:
    |environment|role     |
    |QA         |Role 2   |
    |QA         |All Roles|
    
   

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

    Scenario Outline: Test
        Given LPH app is open on "<environment>"
        When Test

    @QA
    Examples:
    |environment|
    |QA         |

    Scenario Outline: Drag and drop shift
        Given LPH app is open on "<environment>"
        When Move shift
            |Role  |Employee  |ShiftStartTime     |ShiftEndTime     |NewShiftStartTime  |
            |<role>|<employee>|<oldShiftStartTime>|<oldShiftEndTime>|<newShiftStartTime>|
        Then Shift for Role "<role>" Employee "<employee>" Start time "<newShiftStartTime>" End time "<newShiftEndTime>" is "visible"
        When Move shift
            |Role  |Employee  |ShiftStartTime     |ShiftEndTime     |NewShiftStartTime  |
            |<role>|<employee>|<newShiftStartTime>|<newShiftEndTime>|<oldShiftStartTime>|
        Then Shift for Role "<role>" Employee "<employee>" Start time "<oldShiftStartTime>" End time "<oldShiftEndTime>" is "visible"
    @QA
    Examples:
    |environment|role|employee|oldShiftStartTime|oldShiftEndTime|newShiftStartTime|newShiftEndTime|
    |local      |R1  |SS      |6:45             |9:00           |12:15            |14:30          |


    Scenario Outline: Drag and drop shift near the border of an interval does not change shift duration 
        Given LPH app is open on "<environment>"
        When Move shift by offset
            |Role  |Employee  |ShiftStartTime  |ShiftEndTime        |Offset|
            |<role>|<employee>|<shiftStartTime>|<shiftEndTime>      |    -4|
            |<role>|<employee>|<shiftStartTime>|<shiftEndTime>      |     5|
            |<role>|<employee>|<newShiftStartTime>|<newShiftEndTime>|    -5|
        Then Shift for Role "<role>" Employee "<employee>" Start time "<shiftStartTime>" End time "<shiftEndTime>" is "visible"
    @QA
    Examples:
    |environment|role|employee|shiftStartTime|shiftEndTime|newShiftStartTime|newShiftEndTime|
    |local      |R1  |SS      |16:30         |20:00       |16:45            |20:15          |