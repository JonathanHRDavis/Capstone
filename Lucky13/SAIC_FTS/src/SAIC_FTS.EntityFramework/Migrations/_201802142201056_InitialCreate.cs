namespace SAIC_FTS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ContractNumber = c.Int(),
                        TaskNumber = c.Int(),
                        CRN = c.Single(),
                        CRT = c.Single(),
                        Status = c.String(),
                        SPAValue = c.Single(),
                        NegotiatedValue = c.Single(),
                        NegotiatedFee = c.Single(),
                        NegotiatedLOE = c.Single(),
                        FundedValue = c.Single(),
                        FundedFee = c.Single(),
                        FundedLOE = c.Single(),
                        LOCLOFPercentage = c.Single(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RATEAT = c.Single(),
                        OwningOrgID = c.Int(),
                        ContractType = c.String(),
                        ProgramController = c.String(),
                        TaskOrderManager = c.String(),
                        ContractRepresentative = c.String(),
                        CommonName = c.String(),
                        Hybrid = c.String(),
                        FCCMBillable = c.Single(nullable: false),
                        ApplyBurdenCeilings = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Results");
        }
    }
}
