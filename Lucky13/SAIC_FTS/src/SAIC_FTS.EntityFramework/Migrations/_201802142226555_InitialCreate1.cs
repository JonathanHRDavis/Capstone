namespace SAIC_FTS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Results", newName: "Contracts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Contracts", newName: "Results");
        }
    }
}
