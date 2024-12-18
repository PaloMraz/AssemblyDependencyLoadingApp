TestContracts assembly exposes the ITracer interface.

TestLibrary has dependecy on TestContracts, implements the ITracer interface and has also a dependency on Elastic.Clients.Elasticsearch NuGet package, 
which in turn has transitive dependency on System.Text.Json v8.0.5 NuGet package (cotaining the System.Text.Json.dll assembly version 8.0.0.0).

TestReferenceApp references TestContracts and TestLibrary and building it publishes TestReferenceApp to PublishedApp folder using "dotnet publish"


creates an instance of the Tracer class casting it to the ITracer interface and invokes the Tracer.Trace method.
TestApp has dependecy only on TestContracts, loads the TestLibrary assembly dynamically using Assembly.LoadFrom and then creates an instance
of the Tracer class casting it to the ITracer interface. When invoking the Tracer.Trace method, the following exception is thrown:

System.IO.FileLoadException
  HResult=0x80131621
  Message=Could not load file or assembly 'System.Text.Json, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. Could not find or load a specific file. (0x80131621)
  Source=Elastic.Clients.Elasticsearch
  StackTrace:
   at Elastic.Clients.Elasticsearch.ElasticsearchClientSettingsBase`1..ctor(NodePool nodePool, IRequestInvoker requestInvoker, SourceSerializerFactory sourceSerializerFactory, IPropertyMappingProvider propertyMappingProvider)
   at Elastic.Clients.Elasticsearch.ElasticsearchClientSettings..ctor(NodePool nodePool, IRequestInvoker requestInvoker, SourceSerializerFactory sourceSerializer, IPropertyMappingProvider propertyMappingProvider)
   at Elastic.Clients.Elasticsearch.ElasticsearchClientSettings..ctor(NodePool nodePool, IRequestInvoker requestInvoker, SourceSerializerFactory sourceSerializer)
   at Elastic.Clients.Elasticsearch.ElasticsearchClientSettings..ctor(NodePool nodePool)
   at Elastic.Clients.Elasticsearch.ElasticsearchClientSettings..ctor(Uri uri)
   at TestLibrary.Tracer.Trace(String message) in D:\_data\GithubRepos\PaloMraz\AssemblyDependencyLoadingApp\TestLibrary\Tracer.cs:line 12
   at Program.<Main>$(String[] args) in D:\_data\GithubRepos\PaloMraz\AssemblyDependencyLoadingApp\TestApp\Program.cs:line 21

  This exception was originally thrown at this call stack:
    System.Runtime.Loader.AssemblyLoadContext.LoadFromAssemblyPath(string)
    System.Reflection.Assembly.LoadFrom(string)
    System.Reflection.Assembly.LoadFromResolveHandler(object, System.ResolveEventArgs)
    System.Runtime.Loader.AssemblyLoadContext.InvokeResolveEvent(System.ResolveEventHandler, System.Reflection.RuntimeAssembly, string)

Inner Exception 1:
FileLoadException: Could not load file or assembly 'System.Text.Json, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'.
