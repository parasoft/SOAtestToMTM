# SOAtestToMTM

This is an open source example to show how to take a Parasoft SOAtest report.xml and the import test results into Microsoft Test Manager.

This solution includes two projects:

A `SOAtestParser` example to show how to parse SOAtest reports. 
An `MTMImporter` to take the results and send to Team Foundation Server.  


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

###### assoc
`assoc` element are children of `Test`, it contains the requirement association that user has specified in each test suite.
* `tag` is the association tag we will be using to determine if the test associated to a Test Run "req" or a Test Case "pr"
* `id` is the corresponding id of the Test Run or Test Casein TFS

#### FuncViols
`FuncViols` is a list of `FuncViol` that contains the following userful attribute
* `sev` is the severity of the test result, where 1 is the highest.
* `taskType` is the the type the failure, typical values are "Miscellaneous Errors".
* `msg` is the failure message, which use be added as a comment to the Test Case.
* `testCaseId` is the id of the test case that has this failure

###### Disclaimer
The format of SOAtest reports may be in future updates and parser will needs to be adjusted.

## Importing results into MTM
