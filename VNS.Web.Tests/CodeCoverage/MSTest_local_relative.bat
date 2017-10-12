REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"
 
REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0vns-test-result.trx" del "%~dp0vns-test-result.trx%"
 
REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics
 
REM Generate the report output based on the test results
if %errorlevel% equ 0 (
 call :RunReportGeneratorOutput
)
 
REM Convert the report for Cobertura
if %errorlevel% equ 0 (
 call :RunConvert
)

REM Launch the report
if %errorlevel% equ 0 (
 call :RunLaunchReport
)

REM Remove any previously created test output directories
if %errorlevel% equ 0 (
 call :RunDeleteUserFolder
)

exit /b %errorlevel%
 
:RunDeleteUserFolder
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"
exit /b %errorlevel%

:RunOpenCoverUnitTestMetrics
"%~dp0..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS140COMNTOOLS%\..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\..\VNS.Web.Tests\bin\Debug\VNS.Web.Tests.dll\" /resultsfile:\"%~dp0vns-test-result.trx\"" ^
-filter:"+[VNS*]* -[VNS.Web.Tests]* -[VNS.Data*]*Migrations* -[*]*ViewModel" ^
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
