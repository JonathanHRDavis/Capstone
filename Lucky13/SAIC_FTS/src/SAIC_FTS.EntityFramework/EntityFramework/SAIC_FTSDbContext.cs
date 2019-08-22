using System.Data.Common;
using Abp.Zero.EntityFramework;
using SAIC_FTS.Authorization.Roles;
using SAIC_FTS.Authorization.Users;
using SAIC_FTS.MultiTenancy;

using System.Data.Entity;
using SAIC_FTS.Models.Contracts;

namespace SAIC_FTS.EntityFramework
{
    public class SAIC_FTSDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public virtual IDbSet<Contract> Contracts { get; set; }
        public virtual IDbSet<ContractText> ContractText { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //WIll change the "Contracts" table to "Contract" if uncommented
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContractText>().ToTable("ContractText");
        }




        public SAIC_FTSDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SAIC_FTSDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SAIC_FTSDbContext since ABP automatically handles it.
         */
        public SAIC_FTSDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SAIC_FTSDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public SAIC_FTSDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
