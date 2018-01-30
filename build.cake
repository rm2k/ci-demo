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
        var projectFiles = GetFiles("./test/**/*.csproj");

        var settings = new DotNetCoreTestSettings
        {
            Configuration = configuration,
            NoBuild = true,
            Logger = "trx;LogFileName=test-reports.xml"
        };

        foreach(var file in projectFiles)
        {
            DotNetCoreTest(file.FullPath, settings);
        }
    });

Task("Default")
    .IsDependentOn("Test");

////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////

RunTarget(target);