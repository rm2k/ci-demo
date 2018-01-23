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

Task("Restore")
    .Does(() => 
    {
        DotNetCoreRestore();
    });

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        var settings = new DotNetCoreBuildSettings
        {
            Configuration = configuration,
            NoRestore = true
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
            NoRestore = true,
            NoBuild = true
        }

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