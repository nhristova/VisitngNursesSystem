"D:\Telerik-HW\Teamwork-mvc\VisitingNursesSystem\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS140COMNTOOLS%\..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"D:\Telerik-HW\Teamwork-mvc\VisitingNursesSystem\VNS.Web.Tests\bin\Debug\VNS.Web.Tests.dll\" /resultsfile:\"%~dp0vns-test-result-9.trx\"" ^
-filter:"+[VNS*]* -[VNS.Web.Tests]* -[VNS.Data*]*Migrations* -[*]*ViewModel" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0GeneratedReports\VNS-Report.xml"

"D:\Telerik-HW\Teamwork-mvc\VisitingNursesSystem\packages\ReportGenerator.3.0.2\tools\ReportGenerator.exe" ^
-reports:"%~dp0GeneratedReports\VNS-Report.xml" ^
-targetdir:"%~dp0GeneratedReports"
	
start "report" "%~dp0GeneratedReports\index.htm"