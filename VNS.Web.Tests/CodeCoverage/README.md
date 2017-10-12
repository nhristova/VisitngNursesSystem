### Steps to set up MSTest code coverage reports locally and in Jenkins

1. Install NuGetPackages

    - OpenCover
    - ReportGenerator
    - OpenCoverToCoberturaConverter

2. Configure local bat file, test if it works (see `MSTest_local_relative.bat` and `MSTest_local_absolute.bat`)

3. Configure Jenkins batch commands (using environment variable %Workspace%) (see `MSTest_Jenkins.bat`)

4. Install Jenkins plugins

    - Cobertura
    - HTML Publisher

5. Add batch commands to Jenkins 

6. Add post-build actions for Cobertura and HTML Publisher

7. Build 50 times

