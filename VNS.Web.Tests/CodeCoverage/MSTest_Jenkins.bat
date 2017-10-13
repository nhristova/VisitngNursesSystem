
REM ======================================
REM CREATE REPORT FOLDER
REM ======================================

mkdir "%WORKSPACE%\GeneratedReports"

REM ======================================
REM GENERATE OPENCOVER REPORT
REM ======================================

"%WORKSPACE%\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:Path32 ^
-target:"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%WORKSPACE%\VNS.Web.Tests\bin\Release\VNS.Web.Tests.dll\" /resultsfile:\"%WORKSPACE%\VNS-OpenCover-Tests-Result.trx\"" ^
-filter:"+[VNS*]* -[VNS.Web.Tests]* -[VNS.Data*]*Migrations*" ^
-mergebyhash ^
-skipautoprops ^
-output:"%WORKSPACE%\GeneratedReports\VNS-OpenCover-Report.xml"

REM ======================================
REM CONVERT OPENCOVER REPORT TO COBERTURA FORMAT
REM ======================================

"%WORKSPACE%\packages\OpenCoverToCoberturaConverter.0.2.6.0\tools\OpenCoverToCoberturaConverter.exe" ^
-input:"%WORKSPACE%\GeneratedReports\VNS-OpenCover-Report.xml" -output:"%WORKSPACE%\GeneratedReports\VNS-Converted-Report.xml" -sources:"%WORKSPACE%"

REM ======================================
REM GENERATE REPORT WITH REPORT GENERATOR
REM ======================================

"%WORKSPACE%\packages\ReportGenerator.3.0.2\tools\ReportGenerator.exe" ^
-reports:"%WORKSPACE%\GeneratedReports\VNS-OpenCover-Report.xml" ^
-targetdir:"%WORKSPACE%\GeneratedReports\ReportGenerator_Output"
