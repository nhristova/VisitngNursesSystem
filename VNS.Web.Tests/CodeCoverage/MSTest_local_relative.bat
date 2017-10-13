@ECHO off

ECHO ================================================================== 
ECHO.
ECHO Creating a 'GeneratedReports' folder if it does not exist...
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"
 
ECHO.
ECHO ================================================================== 
ECHO.
ECHO Removing any previous test execution files to prevent issues overwriting...

IF EXIST "%~dp0vns-test-result.trx" del "%~dp0vns-test-result.trx%"

ECHO.
ECHO ================================================================== 
ECHO.
ECHO Runing the tests against the targeted output...
ECHO.
call :RunOpenCoverUnitTestMetrics
 
ECHO.
ECHO ================================================================== 
ECHO.
ECHO Generating the report output based on the test results...
ECHO.
if %errorlevel% equ 0 (
 call :RunReportGeneratorOutput
)

ECHO.
ECHO ==================================================================  
ECHO.
ECHO Converting the report for Cobertura...

if %errorlevel% equ 0 (
 call :RunConvert
)

ECHO.
ECHO ================================================================== 
ECHO.
ECHO Launching the report...

if %errorlevel% equ 0 (
 call :RunLaunchReport
)
ECHO.
ECHO ================================================================== 
ECHO.
ECHO Removing any previously created test output directories...
if %errorlevel% equ 0 (
 call :RunDeleteUserFolder
)

ECHO.
ECHO ================================================================== 
ECHO                        ALL DONE, BYE!
ECHO ================================================================== 

exit /b %errorlevel%
 
:RunDeleteUserFolder
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"
exit /b %errorlevel%

:RunOpenCoverUnitTestMetrics
"%~dp0..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS140COMNTOOLS%\..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\..\VNS.Web.Tests\bin\Release\VNS.Web.Tests.dll\" /resultsfile:\"%~dp0vns-test-result.trx\"" ^
-filter:"+[VNS*]* -[VNS.Web.Tests]* -[VNS.Data*]*Migrations*" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0\GeneratedReports\VNS-OpenCover-Report.xml"
exit /b %errorlevel%

:RunConvert
"%~dp0..\..\packages\OpenCoverToCoberturaConverter.0.2.6.0\tools\OpenCoverToCoberturaConverter.exe" ^
-input:"%~dp0\GeneratedReports\VNS-OpenCover-Report.xml" -output:"%~dp0\GeneratedReports\VNS-Converted-Report.xml" -sources:"%~dp0"
exit /b %errorlevel%
 
:RunReportGeneratorOutput
"%~dp0..\..\packages\ReportGenerator.3.0.2\tools\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\VNS-OpenCover-Report.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGenerator_Output"
exit /b %errorlevel%
 
:RunLaunchReport
start "report" "%~dp0\GeneratedReports\ReportGenerator_Output\index.htm"
exit /b %errorlevel%
