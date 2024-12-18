using System;
using System.IO;
using System.Reflection;
using TestContracts;

Console.WriteLine($"Running on CLR {Environment.Version}");

// From TestApp\bin\Debug\net7.0 to appropriate subfolder of TestReferenceApp :-)
string publishedAppFolderName = (Environment.Version.Major < 7) ? "PublishedAppNet461" : "PublishedAppNet70";
string solutionFolderPath = new DirectoryInfo(Path.GetDirectoryName(typeof(Program).Assembly.Location)!).Parent!.Parent!.Parent!.Parent!.FullName;
string dllFilePath = Path.Combine(solutionFolderPath, "TestReferenceApp", publishedAppFolderName, "TestLibrary.dll");

Console.WriteLine($"Press ENTER to load '{dllFilePath}'");
Console.ReadLine();

Assembly assembly = Assembly.LoadFrom(dllFilePath);
Console.WriteLine($"'{assembly.FullName}' loaded\nPress ENTER to create TestLibrary.Tracer instance");
Console.ReadLine();

ITracer? tracer = assembly.CreateInstance("TestLibrary.Tracer") as ITracer;
Console.WriteLine($"'{tracer?.GetType().FullName}' instance created\nPress ENTER to call Trace");
Console.ReadLine();

tracer?.Trace("Hello, World!");
Console.WriteLine($"Trace method called. Press ENTER to finish");
Console.ReadLine();
