using System;
using System.Net.Http;

namespace SAIC_FTS.Models.Contracts
{
    public static class SolrHTTPMethods
    {
        private static string connectionString;
        static SolrHTTPMethods()
        {
            System.Configuration.ConnectionStringSettings mySetting = System.Configuration.ConfigurationManager.ConnectionStrings["Solr"];
            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new System.Exception("Fatal error: missing connecting string in web.config file");

            connectionString = mySetting.ConnectionString;
        }

        public static void ExecuteDataImportHandler()
        {
            string solrTargetDIHUrl = connectionString + "/dataimport?command=delta-import";
            System.Diagnostics.Debug.WriteLine(solrTargetDIHUrl);
            try
            {
                using (var solrClient = new HttpClient())
                {
                    var resultObj = solrClient.GetAsync(new Uri(solrTargetDIHUrl)).Result;
                    //System.Diagnostics.Debug.WriteLine("Data Import Triggered Successfully!");
                }
            }
            catch (Exception e)
            {
                //System.Diagnostics.Debug..WriteLine("ERROR in Data Import Handler Trigger: " + e.Message);
            }
        }
    }
}
