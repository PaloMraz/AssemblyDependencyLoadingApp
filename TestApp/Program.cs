using System;
using System.IO;
using System.Reflection;
using TestContracts;

// From TestApp\bin\Debug\net7.0 to TestReferenceApp\PublishedApp :-)
string solutionFolderPath = new DirectoryInfo(Path.GetDirectoryName(typeof(Program).Assembly.Location)!).Parent!.Parent!.Parent!.Parent!.FullName;
string dllFilePath = Path.Combine(solutionFolderPath, "TestReferenceApp", "PublishedApp", "TestLibrary.dll");

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
