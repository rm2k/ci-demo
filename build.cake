var settings = new DotNetCoreCleanSettings
{
	Framework = "netcoreapp1.1",
    Configuration = "Debug",
    OutputDirectory = "./artifacts/"
};

var target = Argument("target", "Default");
var configuration = Argument("configuration","Debug");

var testProjects  = GetFiles("./test/**/*.csproj");

var buildDir = Directory("./src/demoapi/bin") + Directory(configuration);

Task("Clean")
	.Does(() => 
	{
		DotNetCoreClean("./ci-demo.sln", settings);
    });

Task("Test")
	.IsDependentOn("Clean")
	.Does(() =>
	{
		DotNetCoreTest("./test/demoapi.tests/");
	
	});

Task("Default")
    .IsDependentOn("Test");

RunTarget(target);