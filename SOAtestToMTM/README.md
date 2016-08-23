# SOAtestToMTM

This is an open source example to show how to take a Parasoft SOAtest report.xml and the import test results into Microsoft Test Manager.

This solution includes two projects:

A `SOAtestParser` example to show how to parse SOAtest reports. 
An `MTMImporter` to take the results and send to Team Foundation Server.  

## Prerequisites

This example supports 
* SOAtest 9.8 
* Team Foundation Sever (version )
* Visual Studio 2013, 2015

SOAtest and MTM must be set up correctly with the same assocation structure.

###### Disclaimer
The format of SOAtest reports may be in future updates and how to parse the report will need to be adjusted.

### SOAtest
User must configure the root Test Suite in a tst file with the correct Requirement information that corresponds to the Test Plan sturcture in MTM.

!(/images/requirement.jpg)

In Requirement and Notes tab of each Test Suite, add the association for each test. Association added for each Test Suite will be inherited by its children.

@req is representing a Test Run
@pr is representing a Test Case

The test results correlated in the following logic:
In each test run (associated with @req) can contain multiple test cases (associated with @pr), each indivdual test results in SOAtest are considered as steps for each test case.

```
Example.tst
 ---TestSuite associates with @req 1
   ---Test associated with @pr 2
   ---Test associated with @pr 2
 ---TestSuite associates with @req 3
   ---Test associated with @pr 4
```

will be translated into this in TFS

```
TestPlan
 ---Test Run with id 1
  ---Test Case with id 2
     ---two test steps
 ---Test Run with id 3
  ---Test Case with id 4
```


### MTM
Same structure in MTM
!(/images/mtm.jpg)


## Pasring SOAtest results (report.xml)

### Overview
There are a lot of information in the report but we will be utilizing only several key elements.

The example is using XMLReader for simplicity and efficiency reasons and expect elements in the following order (default order):

1. `ResultsSession` root element and its attributes to get general information for the test run, such as project, session tag, test start time and build number.
2. `TestConfig` element for the configuration and user.
3. `ExecutedTestsDetails` element and its children to gather test result
4. `FuncViols` element for test failures.

##### ResultsSession
ResultsSession is the root element in SOAtest report.xml and the following attributes will be used to populate infomration for a MTM Test Run.
* `buildId` will be used for build number
* `project` will be used for project name
* `tag` will be used for for test environment. Note: tag is a user defiend field "Session Tag" in SOAtest, it can be used to group multiple reports, in this case, a test environment.
* `time` will be used for time start time, we will have to calculate the test end time based of this.

##### TestConfig
`TestConfig` the the first child element in `ResultsSession`
* `name` will be used for Configuration name
* `user` will be used for the test run user


##### ExecutedTestsDetails
`ExecutedTestsDetails` is the next element that will be parsed, it contains multiple levels that eventually traverse down to 'Test' elements that contain results of each individual tests.
Test results are culminated in parent `TestSuite`, which can be self nested. 
The hierarchy represents as:  `ExecutedTestsDetails` --> `Total` --> `Project` (tst files) --> nesting `TestSuites` --> `Test`
The attributes used in `Test` elements are:
* `id` will be for mapping test failure messages later
* `fail` with value > 0 indicate that the test failed
* `pass` with value > 0 indicate that the test passed
* `startTime` is the time in ms that the test started
* `time` is the duration of the test until completion

##### assoc
`assoc` element are children of `Test`, it contains the requirement association that user has specified in each test suite.
* `tag` is the association tag we will be using to determine if the test associated to a Test Run "req" or a Test Case "pr"
* `id` is the corresponding id of the Test Run or Test Casein TFS

#### FuncViols
`FuncViols` is a list of `FuncViol` that contains the following userful attribute
* `sev` is the severity of the test result, where 1 is the highest.
* `taskType` is the the type the failure, typical values are "Miscellaneous Errors".
* `msg` is the failure message, which use be added as a comment to the Test Case.
* `testCaseId` is the id of the test case that has this failure

## Importing results into MTM

The `MTMImporter` project is utilizing the [Team Foundation Server API](https://msdn.microsoft.com/en-us/library/bb130146(v=vs.120).aspx) to construct results for Test Plans.
It re-maps the parsed ResultSession object into a a list of `TFSTestRun` and create run results in MTM.
The test results are re-arranged in the logic mentioned in the prerequisites:
In each test run (associated with @req) can contain multiple test cases (associated with @pr), each indivdual test results in SOAtest are considered as steps for each test case.


### Using the importer

#### How to Build

#### Parameters
The executable 

#### How to Run

## License


## Reference