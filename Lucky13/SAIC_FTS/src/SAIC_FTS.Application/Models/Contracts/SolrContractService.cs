using CommonServiceLocator;
using SolrNet;

namespace SAIC_FTS.Models.Contracts
{
    public static class SolrContractService
    {
        static SolrContractService()
        {
            System.Configuration.ConnectionStringSettings mySetting = System.Configuration.ConfigurationManager.ConnectionStrings["Solr"];
            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new System.Exception("Fatal error: missing connecting string in web.config file");

            string connectionString = null;
            connectionString = mySetting.ConnectionString;

            StartConnection(connectionString);
        }

        public static void StartConnection(string connectionString)
        {
            try
            {
                if (connectionString != null)
                {
                    Startup.Init<SolrContract>(connectionString);
                }
                else
                {
                    Startup.Init<SolrContract>("http://149.149.134.251:8983/solr/Contracts");
                }
            }
            catch
            {
                throw new System.Exception("Solr Connection could not be established, please check your configuration.");
            }
        }

        public static SolrQueryResults<SolrContract> QueryByField(string field, string terms)
        {
            
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SolrContract>>();
            SolrQueryResults<SolrContract> results = null;
            try
            {
                results = solr.Query(new SolrQueryByField(field, terms));
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Could not perform Solr search query; check your Solr server for any errors.");
            }
            //System.Diagnostics.Debug.WriteLine("Here's all the text: \n" + results[0].ContractNumber);
            return results;
            
        }

        public static string BinaryDocumentUpload(string filepath)
        {
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SolrContract>>();
            //System.Diagnostics.Debug.WriteLine(filepath);
            using (var file = System.IO.File.OpenRead(filepath))
            {
                var response = solr.Extract(new ExtractParameters(file, "some_document_id")
                {
                    ExtractOnly = true,
                    ExtractFormat = ExtractFormat.Text,
                });
                //System.Diagnostics.Debug.WriteLine(response.Content);
                return response.Content;               
            }
        }

        public static SolrQueryResults<SolrContract> GetContract(string contractNumber)
        {

            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SolrContract>>();
            var results = solr.Query(new SolrQueryByField("ContractNumber", contractNumber));
            //System.Diagnostics.Debug.WriteLine("Here's all the text: \n" + results[0].ContractText);
            return results;

        }


        public static void ExecuteDataImportHandler()
        {
            System.Configuration.ConnectionStringSettings mySetting = System.Configuration.ConfigurationManager.ConnectionStrings["Solr"];
            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new System.Exception("Fatal error: missing connecting string in web.config file");

            var connectionString = mySetting.ConnectionString;
            string solrTargetDIHUrl = connectionString + "/dataimport?command=delta-import";
            //System.Diagnostics.Debug.WriteLine(solrTargetDIHUrl);

            try
            {
                using (var solrClient = new System.Net.Http.HttpClient())
                {
                    var resultObj = solrClient.GetAsync(new System.Uri(solrTargetDIHUrl)).Result;
                    //System.Diagnostics.Debug.WriteLine("Data Import Triggered Successfully!");
                }
            }
            catch (System.Exception e)
            {
                //System.Diagnostics.Debug..WriteLine("ERROR in Data Import Handler Trigger: " + e.Message);
            }
        }

    }
}
