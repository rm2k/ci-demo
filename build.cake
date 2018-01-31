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

Task("Break-No-Matter-What")
    .IsDependentOn("Build")
    .Does(() =>
    {
            var projects = GetFiles("./test/**/*.tests.csproj");

            foreach(var project in projects)
            {
                DotNetCoreTool(
                    projectPath: project.FullPath, 
                    command: "xunit", 
                    arguments: $"-configuration {configuration} -xml ./reports/test-reports.xml -nobuild"
                );
            }
    });

Task("Test")
    .IsDependentOn("Break-No-Matter-What")
    .Does(() => {
        throw new NullReferenceException(message: "Yep! Broken and Broken!");
    });

Task("Default")
    .IsDependentOn("Test");

////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////

RunTarget(target);