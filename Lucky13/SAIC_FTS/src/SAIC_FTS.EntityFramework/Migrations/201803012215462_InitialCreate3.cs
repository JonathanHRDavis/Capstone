namespace SAIC_FTS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "FullContractNum", c => c.String());
            AddColumn("dbo.Contracts", "ContractStatus", c => c.Int());
            AddColumn("dbo.Contracts", "CeilingCost", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "CeilingFee", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "CeilingValue", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "ProjectControlAnalyst", c => c.String());
            AddColumn("dbo.Contracts", "Representative", c => c.String());
            AddColumn("dbo.Contracts", "LaborCertificationRequired", c => c.Boolean());
            AddColumn("dbo.Contracts", "OneLaborCategoryPerPerson", c => c.Boolean());
            AddColumn("dbo.Contracts", "LaborCertificationResumeRequired", c => c.Boolean());
            AddColumn("dbo.Contracts", "OrgID", c => c.String());
            AddColumn("dbo.Contracts", "ProgramManager", c => c.String());
            AddColumn("dbo.Contracts", "Customer", c => c.String());
            AddColumn("dbo.Contracts", "ExportControlLicense", c => c.String());
            AddColumn("dbo.Contracts", "ContractRecTypeCode", c => c.String());
            AddColumn("dbo.Contracts", "IsKeyPersonnel", c => c.Boolean());
            AddColumn("dbo.Contracts", "BillingFrequency", c => c.String());
            AlterColumn("dbo.Contracts", "CRN", c => c.Int());
            AlterColumn("dbo.Contracts", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Contracts", "EndDate", c => c.DateTime());
            DropColumn("dbo.Contracts", "ContractNumber");
            DropColumn("dbo.Contracts", "TaskNumber");
            DropColumn("dbo.Contracts", "CRT");
            DropColumn("dbo.Contracts", "Status");
            DropColumn("dbo.Contracts", "SPAValue");
            DropColumn("dbo.Contracts", "NegotiatedValue");
            DropColumn("dbo.Contracts", "NegotiatedFee");
            DropColumn("dbo.Contracts", "NegotiatedLOE");
            DropColumn("dbo.Contracts", "FundedValue");
            DropColumn("dbo.Contracts", "FundedFee");
            DropColumn("dbo.Contracts", "FundedLOE");
            DropColumn("dbo.Contracts", "LOCLOFPercentage");
            DropColumn("dbo.Contracts", "RATEAT");
            DropColumn("dbo.Contracts", "OwningOrgID");
            DropColumn("dbo.Contracts", "ProgramController");
            DropColumn("dbo.Contracts", "TaskOrderManager");
            DropColumn("dbo.Contracts", "ContractRepresentative");
            DropColumn("dbo.Contracts", "Hybrid");
            DropColumn("dbo.Contracts", "FCCMBillable");
            DropColumn("dbo.Contracts", "ApplyBurdenCeilings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "ApplyBurdenCeilings", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contracts", "FCCMBillable", c => c.Single(nullable: false));
            AddColumn("dbo.Contracts", "Hybrid", c => c.String());
            AddColumn("dbo.Contracts", "ContractRepresentative", c => c.String());
            AddColumn("dbo.Contracts", "TaskOrderManager", c => c.String());
            AddColumn("dbo.Contracts", "ProgramController", c => c.String());
            AddColumn("dbo.Contracts", "OwningOrgID", c => c.Int());
            AddColumn("dbo.Contracts", "RATEAT", c => c.Single());
            AddColumn("dbo.Contracts", "LOCLOFPercentage", c => c.Single());
            AddColumn("dbo.Contracts", "FundedLOE", c => c.Single());
            AddColumn("dbo.Contracts", "FundedFee", c => c.Single());
            AddColumn("dbo.Contracts", "FundedValue", c => c.Single());
            AddColumn("dbo.Contracts", "NegotiatedLOE", c => c.Single());
            AddColumn("dbo.Contracts", "NegotiatedFee", c => c.Single());
            AddColumn("dbo.Contracts", "NegotiatedValue", c => c.Single());
            AddColumn("dbo.Contracts", "SPAValue", c => c.Single());
            AddColumn("dbo.Contracts", "Status", c => c.String());
            AddColumn("dbo.Contracts", "CRT", c => c.Single());
            AddColumn("dbo.Contracts", "TaskNumber", c => c.Int());
            AddColumn("dbo.Contracts", "ContractNumber", c => c.Int());
            AlterColumn("dbo.Contracts", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contracts", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contracts", "CRN", c => c.Single());
            DropColumn("dbo.Contracts", "BillingFrequency");
            DropColumn("dbo.Contracts", "IsKeyPersonnel");
            DropColumn("dbo.Contracts", "ContractRecTypeCode");
            DropColumn("dbo.Contracts", "ExportControlLicense");
            DropColumn("dbo.Contracts", "Customer");
            DropColumn("dbo.Contracts", "ProgramManager");
            DropColumn("dbo.Contracts", "OrgID");
            DropColumn("dbo.Contracts", "LaborCertificationResumeRequired");
            DropColumn("dbo.Contracts", "OneLaborCategoryPerPerson");
            DropColumn("dbo.Contracts", "LaborCertificationRequired");
            DropColumn("dbo.Contracts", "Representative");
            DropColumn("dbo.Contracts", "ProjectControlAnalyst");
            DropColumn("dbo.Contracts", "CeilingValue");
            DropColumn("dbo.Contracts", "CeilingFee");
            DropColumn("dbo.Contracts", "CeilingCost");
            DropColumn("dbo.Contracts", "ContractStatus");
            DropColumn("dbo.Contracts", "FullContractNum");
        }
    }
}
