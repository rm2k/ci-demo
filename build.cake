////////////////////////////////////////////////////////////////
// ARGUMENTS
////////////////////////////////////////////////////////////////

var target = Argument<string>("target", "Default");
var configuration = Argument<string>("configuration", "Release"); 

///////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////


Task("Clean")
    .Does(() => 
    {
        var settings = new DotNetCoreCleanSettings
        {
            Configuration = configuration
        };

        DotNetCoreClean(".", settings);
    });

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        var settings = new DotNetCoreBuildSettings
        {
            Configuration = configuration
        };

        DotNetCoreBuild(".", settings);
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
            var projects = GetFiles("./test/**/*.tests.csproj");

            foreach(var project in projects)
            {
                DotNetCoreTool(project, "xunit", "-xml ./reports/test-reports.xml");
            }
    });

Task("Default")
    .IsDependentOn("Test");

////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////

RunTarget(target);