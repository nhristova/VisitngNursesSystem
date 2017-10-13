@ECHO off

ECHO ================================================================== 
ECHO.
ECHO                 CREATING REPORT FOLDER
ECHO.
ECHO ================================================================== 
ECHO.

mkdir "%WORKSPACE%\GeneratedReports"

ECHO ================================================================== 
ECHO.
ECHO                 GENERATING OPENCOVER REPORT
ECHO.
ECHO ================================================================== 
ECHO.

"%WORKSPACE%\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:Path32 ^
-target:"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%WORKSPACE%\VNS.Web.Tests\bin\Release\VNS.Web.Tests.dll\" /resultsfile:\"%WORKSPACE%\VNS-OpenCover-Tests-Result.trx\"" ^
-filter:"+[VNS*]* -[VNS.Web.Tests]* -[VNS.Data*]*Migrations*" ^
-mergebyhash ^
-skipautoprops ^
-output:"%WORKSPACE%\GeneratedReports\VNS-OpenCover-Report.xml"

ECHO ================================================================== 
ECHO.
ECHO             CONVERTING OPENCOVER REPORT TO COBERTURA FORMAT
ECHO.
ECHO ================================================================== 
ECHO.

"%WORKSPACE%\packages\OpenCoverToCoberturaConverter.0.2.6.0\tools\OpenCoverToCoberturaConverter.exe" ^
-input:"%WORKSPACE%\GeneratedReports\VNS-OpenCover-Report.xml" -output:"%WORKSPACE%\GeneratedReports\VNS-Converted-Report.xml" -sources:"%WORKSPACE%"

ECHO ================================================================== 
ECHO.
ECHO                 GENERATING REPORT WITH REPORT GENERATOR
ECHO.
ECHO ================================================================== 
ECHO.

"%WORKSPACE%\packages\ReportGenerator.3.0.2\tools\ReportGenerator.exe" ^
-reports:"%WORKSPACE%\GeneratedReports\VNS-OpenCover-Report.xml" ^
-targetdir:"%WORKSPACE%\GeneratedReports\ReportGenerator_Output"

ECHO ================================================================== 
ECHO.
ECHO                SENDING REPORT TO COVERALLS
ECHO.
ECHO ================================================================== 
ECHO.

"%WORKSPACE%\packages\coveralls.io.1.4.2\tools\coveralls.net.exe" --opencover "%WORKSPACE%\GeneratedReports\VNS-OpenCover-Report.xml" -r OqaQOgths99GfAcSGTxoMZm21UdbkM6ut
