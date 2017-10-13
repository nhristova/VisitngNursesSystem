### Steps to set up MSTest code coverage reports locally and in Jenkins

1. Install NuGet packages

    - OpenCover
    - ReportGenerator
    - OpenCoverToCoberturaConverter

2. Configure local bat file, test if it works (see `MSTest_local_relative.bat` and `MSTest_local_absolute.bat`)

3. Configure Jenkins batch commands (using environment variable %Workspace%) (see `MSTest_Jenkins.bat`), add html report folder to .gitignore

4. Install Jenkins plugins

    - Cobertura
    - HTML Publisher

5. Add batch commands to Jenkins 

6. Add post-build actions for Cobertura and HTML Publisher

7. Build 50 times

Total time ~30 hours

Instructins from: [Allen Conway](https://magenic.com/thinking/using-opencover-and-reportgenerator-to-get-unit-testing-code-coverage-metrics-in-net) and [Jane Dallaway](http://jane.dallaway.com/jenkins-code-coverage-net/)


### Set up code coverage with AppVeyor and Coveralls

1. Register at AppVeyor and Coveralls with GitHub account and link repo

2. Install NuGet packages 

3. Follow [easy instructions](https://github.com/coveralls-net/coveralls.net/wiki/CI-Integrations)

Possible errors - not finding moq4 files -> filter them out (use the same filter as for Jenkins OpenCover set up)

Total time: ~ 30 mins
