using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SAIC_FTS.Models.Contracts.Dtos;


namespace SAIC_FTS.Models.Contracts
{
    public class ContractAppService : ApplicationService, IContractAppService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IContractTextRepository _contractTextRepository;

        public ContractAppService(IContractRepository contractRepository, IContractTextRepository contractTextRepository)
        {
            _contractRepository = contractRepository;
            _contractTextRepository = contractTextRepository;
            //SolrContractService.StartConnection(null);            
        }


        public void GetContractText()
        {
            var contracts = _contractTextRepository.GetAllWithContractNumber(null);
            //System.Diagnostics.Debug.WriteLine("Number of returned results: " + contracts.Count);
        }


        public GetContractsOutput GetAll()
        {
            var contracts = _contractRepository.GetAll();

            return new GetContractsOutput
            {
                Contracts = Mapper.Map<List<ContractDto>>(contracts)
            };
        }

        public GetContractsOutput GetContracts(GetContractsInput input)
        {
            var contracts = _contractRepository.GetAllWithContractNumber(input.FullContractNum);


            //SolrContractService.QueryByField("Contract","earth");
            //FullTextSearch("earth");

           // System.Diagnostics.Debug.WriteLine("Number of returned results: {0}", contracts.Count);

            return new GetContractsOutput
            {
                Contracts = Mapper.Map<List<ContractDto>>(contracts)
            };
        }

        public GetContractsOutput GetAllContractsWithNumbers(List<string> contractNumbers)
        {
            var contracts = new List<Contract>();

            foreach (var number in contractNumbers)
            {
                contracts.AddRange(_contractRepository.GetAllWithContractNumber(number));
            }

            return new GetContractsOutput
            {
                Contracts = Mapper.Map<List<ContractDto>>(contracts)
            };
        }

        //TODO: Integrate Solr here to accept a search string and find the relevant contracts.
        
        public GetContractsOutput FullTextSearch(string searchstring)
        {
            

            //GetContractText();



            //Perform Solr calls and stuff here to get back a list of relevant contract numbers

            var results = SolrContractService.QueryByField("Contract", searchstring);
            var contractNumbers = new List<string>();

            foreach (SolrContract result in results)
            {
                contractNumbers.Add(result.ContractNumber);
            }

            
            //foreach (string number in contractNumbers)
            {
                //System.Diagnostics.Debug.WriteLine(number + "\n");
            }


            return GetAllContractsWithNumbers(contractNumbers);
        }
        
        public string getContractText(string contractNumber)
        {
            var results = SolrContractService.GetContract(contractNumber);
            return results[0].ContractText;
        }

        public void CreateContract(CreateContractInput input)
        {

            string filepath = System.Web.HttpContext.Current.Server.MapPath("~") + @"BINARYFILES\file." + input.Contract;
            string fileText = SolrContractService.BinaryDocumentUpload(filepath);

            var contract = new Contract
            {
                //FullContractNum is set by Contract constructor
                CRN = input.CRN,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                Title = input.Title,
                CommonName = input.CommonName,
                ContractStatus = input.ContractStatus,
                CeilingCost = input.CeilingCost,
                CeilingFee = input.CeilingFee,
                CeilingValue = input.CeilingValue,
                ProjectControlAnalyst = input.ProjectControlAnalyst,
                Representative = input.Representative,
                LaborCertificationRequired = input.LaborCertificationRequired,
                OneLaborCategoryPerPerson = input.OneLaborCategoryPerPerson,
                LaborCertificationResumeRequired = input.LaborCertificationResumeRequired,
                OrgID = input.OrgID,
                ProgramManager = input.ProgramManager,
                Customer = input.Customer,
                ContractType = input.ContractType,
                ExportControlLicense = input.ExportControlLicense,
                ContractRecTypeCode = input.ContractRecTypeCode,
                IsKeyPersonnel = input.IsKeyPersonnel,
                BillingFrequency = input.BillingFrequency
            };
            var contractText = new ContractText
            {
                ContractNumber = contract.FullContractNum,
                Contract = fileText//input.Contract
            };

            _contractRepository.Insert(contract);
            _contractTextRepository.Insert(contractText);
            SolrContractService.ExecuteDataImportHandler();
            //System.Diagnostics.Debug.WriteLine("testing...");
            return;
        }

        public void TestUpload(string binary, string extn)
        {
            var data = binary.Split(new char[] { ',' }, 2);
            //System.Diagnostics.Debug.WriteLine(data[0]);
            string filepath = System.Web.HttpContext.Current.Server.MapPath("~") + @"\BINARYFILES\file." + extn;
            //System.Diagnostics.Debug.WriteLine(filepath);
//            string filepath = @"C:\Users\kingd\source\repos\Lucky13\SAIC_FTS\src\SAIC_FTS.Web\BINARYFILES\file.pdf";            
            
            byte[] bytes = System.Convert.FromBase64String(data[1]);
            System.IO.File.WriteAllBytes(filepath, bytes);
        }







        public void DeltaImport()
        {
            SolrContractService.ExecuteDataImportHandler();
        }
    }
}
