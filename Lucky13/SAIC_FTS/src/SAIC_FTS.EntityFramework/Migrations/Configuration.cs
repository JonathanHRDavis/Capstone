using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using SAIC_FTS.Migrations.SeedData;
using EntityFramework.DynamicFilters;

using SAIC_FTS.Models.Contracts;

namespace SAIC_FTS.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SAIC_FTS.EntityFramework.SAIC_FTSDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SAIC_FTS";
        }

        protected override void Seed(SAIC_FTS.EntityFramework.SAIC_FTSDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            //Deletes all contracts in database
            /*System.Collections.Generic.IEnumerator<Contract> enumerator = context.Contracts.GetEnumerator();
            while(enumerator.MoveNext())
            {
                context.Contracts.Remove(enumerator.Current);
            }
            context.SaveChanges();*/
             
            
            context.Contracts.AddOrUpdate(
                p => p.FullContractNum,
                new Contract {
                    FullContractNum = "Contract111",
                    CRN = 111,
                    StartDate = new System.DateTime(2018, 01, 01),
                    EndDate = new System.DateTime(2018, 01, 31),
                    Title = "My First Contract",
                    CommonName = "Contract Number One",
                    ContractStatus = 1,
                    CeilingCost = 40000.00m,
                    CeilingFee = 10000.00m,
                    CeilingValue = 5000.00m,
                    ProjectControlAnalyst = "Joe Schmoe",
                    Representative = "Some Guy",
                    LaborCertificationRequired = false,
                    OneLaborCategoryPerPerson = false,
                    LaborCertificationResumeRequired = false,
                    OrgID = "TTU123",
                    ProgramManager = "Big Boss",
                    Customer = "Random Person",
                    ContractType = "Good",
                    ExportControlLicense = "Free",
                    ContractRecTypeCode = "Who Knows",
                    IsKeyPersonnel = true,
                    BillingFrequency = "Monthly"
                }
            );

            context.Contracts.AddOrUpdate(
                p => p.FullContractNum,
                new Contract
                {
                    FullContractNum = "Contract222",
                    CRN = 222,
                    StartDate = new System.DateTime(2018, 01, 01),
                    EndDate = new System.DateTime(2018, 01, 31),
                    Title = "My Second Contract",
                    CommonName = "Contract Number Two",
                    ContractStatus = 2,
                    CeilingCost = 50000.00m,
                    CeilingFee = 15000.00m,
                    CeilingValue = 7000.00m,
                    ProjectControlAnalyst = "Billy Bob",
                    Representative = "Some Other Guy",
                    LaborCertificationRequired = false,
                    OneLaborCategoryPerPerson = false,
                    LaborCertificationResumeRequired = false,
                    OrgID = "TTU123",
                    ProgramManager = "Big Boss Man",
                    Customer = "Random Person",
                    ContractType = "Good",
                    ExportControlLicense = "Free",
                    ContractRecTypeCode = "Who Knows",
                    IsKeyPersonnel = true,
                    BillingFrequency = "Annually"
                }
            );

            context.Contracts.AddOrUpdate(
                p => p.FullContractNum,
                new Contract
                {
                    FullContractNum = "Contract333",
                    CRN = 333,
                    StartDate = new System.DateTime(2018, 01, 01),
                    EndDate = new System.DateTime(2018, 01, 31),
                    Title = "My Third Contract",
                    CommonName = "Contract Number Three",
                    ContractStatus = 3,
                    CeilingCost = 10000.00m,
                    CeilingFee = 5000.00m,
                    CeilingValue = 3000.00m,
                    ProjectControlAnalyst = "Mary Sue",
                    Representative = "Some Dude",
                    LaborCertificationRequired = true,
                    OneLaborCategoryPerPerson = false,
                    LaborCertificationResumeRequired = true,
                    OrgID = "TTU123",
                    ProgramManager = "Big Boss Woman",
                    Customer = "Random Person",
                    ContractType = "Bad",
                    ExportControlLicense = "Free",
                    ContractRecTypeCode = "Who Knows",
                    IsKeyPersonnel = false,
                    BillingFrequency = "Monthly"
                }
            );

            context.Contracts.AddOrUpdate(
                p => p.FullContractNum,
                new Contract
                {
                    FullContractNum = "Contract444",
                    CRN = 444,
                    StartDate = new System.DateTime(2018, 01, 01),
                    EndDate = new System.DateTime(2018, 01, 31),
                    Title = "My Fourth Contract",
                    CommonName = "Contract Number Four",
                    ContractStatus = 4,
                    CeilingCost = 75000.00m,
                    CeilingFee = 22000.00m,
                    CeilingValue = 15000.00m,
                    ProjectControlAnalyst = "Gary Stew",
                    Representative = "Some Dude",
                    LaborCertificationRequired = true,
                    OneLaborCategoryPerPerson = false,
                    LaborCertificationResumeRequired = true,
                    OrgID = "TTU123",
                    ProgramManager = "Big Boss",
                    Customer = "Random Person",
                    ContractType = "Good",
                    ExportControlLicense = "Free",
                    ContractRecTypeCode = "Who Knows",
                    IsKeyPersonnel = true,
                    BillingFrequency = "Monthly"
                }
            );

            context.Contracts.AddOrUpdate(
                p => p.FullContractNum,
                new Contract
                {
                    FullContractNum = "Contract555",
                    CRN = 555,
                    StartDate = new System.DateTime(2018, 01, 01),
                    EndDate = new System.DateTime(2018, 01, 31),
                    Title = "My Fifth Contract",
                    CommonName = "Contract Number Five",
                    ContractStatus = 5,
                    CeilingCost = 55000.00m,
                    CeilingFee = 30000.00m,
                    CeilingValue = 25000.00m,
                    ProjectControlAnalyst = "Joe Schmoe",
                    Representative = "Some Guy",
                    LaborCertificationRequired = false,
                    OneLaborCategoryPerPerson = false,
                    LaborCertificationResumeRequired = false,
                    OrgID = "TTU123",
                    ProgramManager = "Big Boss",
                    Customer = "Random Person",
                    ContractType = "Good",
                    ExportControlLicense = "Free",
                    ContractRecTypeCode = "Who Knows",
                    IsKeyPersonnel = true,
                    BillingFrequency = "Monthly"
                }
            );

            context.SaveChanges();
        }
    }
}
