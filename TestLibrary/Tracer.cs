using Elastic.Clients.Elasticsearch;
using System;
using System.Diagnostics;

namespace TestLibrary
{
  public class Tracer : TestContracts.ITracer
  {
    public void Trace(string message)
    {
      // Lets pretrend we setup the Elasticsearch client for tracing...
      var elasticSettings = new ElasticsearchClientSettings(new Uri("http://localhost:9200"));
      Debug.WriteLine($"{elasticSettings}");
    }
  }
}
