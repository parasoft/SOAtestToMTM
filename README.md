# SOAtestToMTM

This open source example shows how to import Parasoft SOAtest report.xml test results into Microsoft Test Manager.

This solution includes two projects:

`SOAtestParser`: Shows how to parse SOAtest reports. 
`MTMImporter`: Takes the results and sends to Microsoft Team Foundation Server.  

## Prerequisites

This example supports 
* SOAtest 9.9.x 
* Team Foundation Sever 2013 or above
* Visual Studio 2013 or above

SOAtest and MTM must be set up with the appropriate association structure.

###### Disclaimer
SOAtest report formats may updated be in future updates of SOAtest. If so, report parsing will need to be adjusted.

### MTM Set Up

MTM test plans must be set up correctly for the importer to able to associate the tests.

User must know the test plan id and its test ids before configuring SOAtest. If there are no test plans in the project yet, please follow MTM documentation on how to add test plans/test cases.

The Test Plan ID can be found in MTM Test Center or using the web client.
![Test Center](/images/testcenter.jpg)

![Web Client](/images/webclient.jpg)

The Test Case ID can be found by drilling down into each test suite within the test plan, Test Suite ids will not be used by the importer.

![Tests](/images/test.jpg)

![Web Client Tests](/images/webtest.jpg)

### SOAtest Set Up
In SOAtest, configure the .tst's root Test Suite with the requirement information that corresponds to the MTM Test Plan structure.

![SOAtest Screenshot](/images/requirement.jpg)

In each test suite's Requirement and Notes tab, add the association for each test. The association added for each Test Suite will be inherited by its children.

@req represents a Test Plan
@pr represents a Test Case

The test results are correlated using the following logic:
Each test plan (associated with @req) can contain multiple test cases (associated with @pr). Each individual SOAtest test result is considered to be a test case step.

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
TestPlan with id 1
  ---Test Case with id 2
     ---two test steps
Test Plan with id 3
  ---Test Case with id 4
```

## How to Build

### Visual Studio
* Open the SOAtestToMTM solution in Visual Studio
* Update the missing Nuget Dependencies by enabling Nuget Restore 
* Build the Solution

### Command Line
* Update the missing Nuget Dependencies with nuget.exe install SOAtestToMTMT/MTMImporter/packages.config
* In the VS Developer Command Prompt, build the solution with msbuild SOAtestToMTM.sln

## How to Run
Running MTMImporter.exe with --help will show the required parameters:
![Help](/images/help.jpg)

This importer example also includes a simple cipher to encrypt passwords.

```
 MTMImporter.exe --encrypt 'password'
 8oT4LZP6D3g2aord/gkXmR/Myfw/1M4F
```

Example command line:

```
 C:\Example>MTMImporter.exe --uri http://tfs2013.parasoft.com:8080/tfs/DefaultCollection --username user 
 --password pass --domain PARASOFT -- project "Project A" --report "C:\Report\report.xml"
```


## Parsing SOAtest results (report.xml)

### Overview
Report.xml contains a lot of information; here, we will focus only on several key elements.

Our example uses XMLReader for the sake of simplicity and efficiency. It expects elements in the following order (default order):

1. `ResultsSession` root element and its attributes to get general test run information, such as project, session tag, test start time and build number.
2. `TestConfig` element for the configuration and user.
3. `ExecutedTestsDetails` element and its children to gather test results.
4. `FuncViols` element for test failures.

##### ResultsSession
ResultsSession is the root element in SOAtest report.xml. The following attributes will be used to populate information for a MTM Test Run.
* `buildId`: For build number.
* `project`: For project name.
* `tag`: For test environment. Note that tag is a user-defined field ("Session Tag" in SOAtest). It can be used to group multiple reports-- in this case, we group by test environment.
* `time`: For time start time.

##### TestConfig
`TestConfig` is the first child element in `ResultsSession`.
* `name`: For the Configuration name.
* `user`: For the test run user.


##### ExecutedTestsDetails
`ExecutedTestsDetails` is the next element that will be parsed. It contains multiple levels that eventually traverse down to 'Test' elements that contain the results of each individual test.
Test results are collected in the parent `TestSuite`, which can be self-nested. 
The hierarchy is represented as:  `ExecutedTestsDetails` --> `Total` --> `Project` (tst files) --> nesting `TestSuites` --> `Test`
The attributes used in `Test` elements are:
* `id`: For mapping test failure messages later.
* `fail`: With value > 0, indicates that the test failed.
* `pass`: With value > 0, indicates that the test passed.
* `startTime`: The time (in ms) that the test started.
* `time` The duration of the test (from start until completion).

##### assoc
`assoc`: Assoc elements are children of `Test`. They contain the requirement associations that were specified in each test suite.
* `tag`: The association tag used to determine if the test is associated with a Test Run "req" or a Test Case "pr".
* `id`: The corresponding id of the Test Run or Test Case in TFS.

#### FuncViols
`FuncViols`: A list of `FuncViol` that contains the following attributes:
* `sev`: The severity of the test result (1 is the highest).
* `taskType`: The type the failure; typical values are "Miscellaneous Errors".
* `msg`: The failure message, which can be added as a comment to the Test Case.
* `testCaseId`: The id of the test case that caused this failure.

## Importing results into MTM

The `MTMImporter` project uses the [Team Foundation Server API](https://msdn.microsoft.com/en-us/library/bb130146(v=vs.120).aspx) to construct results for Test Plans.
It re-maps the parsed ResultSession object into a list of `TFSTestRun` and creates run results in MTM.
The test results are re-arranged according to the logic mentioned in the prerequisites:
Each test run (associated with @req) can contain multiple test cases (associated with @pr). Each indivdual test result in SOAtest is considered to be a test case step.



## License
Please consult the attached LICENSE file for details. All rights not explicitly granted by the Apache 2.0 license are reserved by the Parasoft Corporation.

## Third Party
Active Directory Authentication Library
Microsoft Corporation
Version 2.22.302111727
https://github.com/AzureAD/azure-activedirectory-library-for-dotnet/blob/master/LICENSE

JSON Web Token Handler For the Microsoft .Net Framework 4.5
Microsoft Corporation
Version 4.0.2.206221351
https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/blob/master/LICENSE.txt

Json.NET
James Newton-King
Version 8.0.2
https://raw.githubusercontent.com/JamesNK/Newtonsoft.Json/master/LICENSE.md

Microsoft Visual Studio Services Client
Microsoft Corporation
Version 14.89.0
https://www.microsoft.com/net/dotnet_library_license.htm

Microsoft Visual Studio Services Client (Interactive)
Microsoft Corporation
Version 14.89.0
https://www.microsoft.com/net/dotnet_library_license.htm

Miscrosoft ASP.NET Web API 2.2 Client Libraries
Microsoft Corporation
Version 5.2.3
https://www.microsoft.com/web/webpi/eula/net_library_eula_enu.htm

Miscrosoft ASP.NET Web API 2.2 Core Libraries
Microsoft Corporation
Version 5.2.3
https://www.microsoft.com/web/webpi/eula/net_library_eula_enu.htm

Microsoft Azure Service Bus
Microsoft Corporation
Version 3.1.3
http://go.microsoft.com/fwlink?LinkId=218949

Microsoft Azure Configuration Manager
Microsoft Corporation
Version 3.2.1
https://raw.githubusercontent.com/WindowsAzure/azure-sdk-for-net/master/LICENSE.txt

Microsoft Team Foundation Server Client
Microsoft Corporation
Version 14.89.0
https://www.microsoft.com/net/dotnet_library_license.htm

Microsoft Team Foundation Server Extended Client
Microsoft Corporation
Version 14.89.0
https://www.microsoft.com/net/dotnet_library_license.htm

Command Line Parser Library
Giacomo Stelluti Scala
Version 1.9.71
https://github.com/gsscoder/commandline/blob/master/License.md
