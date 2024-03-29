﻿using System;
using System.Collections.Generic;
using Castle.Core.Configuration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Xunit;
using SolrNet;

namespace Castle.Facilities.SolrNetIntegration.Tests {
    [Trait("Category","Integration")]
    public class CastleIntegrationFixture {
        [Fact]
        public void Ping_Query()
        {
            var configStore = new DefaultConfigurationStore();
            var configuration = new MutableConfiguration("facility");
            configuration.Attribute("type", typeof(SolrNetFacility).AssemblyQualifiedName);
            configuration.CreateChild("solrURL", "http://localhost:8983/solr");
            configStore.AddFacilityConfiguration(typeof(SolrNetFacility).FullName, configuration);
            var container = new WindsorContainer(configStore);

            var solr = container.Resolve<ISolrOperations<CastleFixture.Document>>();
            solr.Ping();
            Console.WriteLine(solr.Query(SolrQuery.All).Count);
        }

        [Fact]
        public void DictionaryDocument()
        {
            var solrFacility = new SolrNetFacility("http://localhost:8983/solr");
            var container = new WindsorContainer();
            container.AddFacility("solr", solrFacility);
            var solr = container.Resolve<ISolrOperations<Dictionary<string, object>>>();
            var results = solr.Query(SolrQuery.All);
            Assert.True(results.Count> 0);
            foreach (var d in results)
            {
                Assert.True(d.Count > 0);
                foreach (var kv in d)
                    Console.WriteLine("{0}: {1}", kv.Key, kv.Value);
            }
        }

        [Fact]
        public void DictionaryDocument_add()
        {
            var solrFacility = new SolrNetFacility("http://localhost:8983/solr");
            var container = new WindsorContainer();
            container.AddFacility("solr", solrFacility);
            var solr = container.Resolve<ISolrOperations<Dictionary<string, object>>>();
            solr.Add(new Dictionary<string, object> {
                {"id", "ababa"},
                {"manu", "who knows"},
                {"popularity", 55},
                {"timestamp", DateTime.UtcNow},
            });
        }
    }
}