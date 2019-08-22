using System;

namespace SAIC_FTS.Models.Contracts.Dtos
{
    public class CreateContractInput
    {
        public int? CRN { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public string CommonName { get; set; }
        public int? ContractStatus { get; set; }
        public decimal? CeilingCost { get; set; }
        public decimal? CeilingFee { get; set; }
        public decimal? CeilingValue { get; set; }
        public string ProjectControlAnalyst { get; set; }
        public string Representative { get; set; }
        public bool? LaborCertificationRequired { get; set; }
        public bool? OneLaborCategoryPerPerson { get; set; }
        public bool? LaborCertificationResumeRequired { get; set; }
        public string OrgID { get; set; }
        public string ProgramManager { get; set; }
        public string Customer { get; set; }
        public string ContractType { get; set; }
        public string ExportControlLicense { get; set; }
        public string ContractRecTypeCode { get; set; }
        public bool? IsKeyPersonnel { get; set; }
        public string BillingFrequency { get; set; }
        public string Contract { get; set; }
    }
}
