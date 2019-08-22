using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace SAIC_FTS.EntityFramework.Repositories
{
    public abstract class SAIC_FTSRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SAIC_FTSDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SAIC_FTSRepositoryBase(IDbContextProvider<SAIC_FTSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class SAIC_FTSRepositoryBase<TEntity> : SAIC_FTSRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SAIC_FTSRepositoryBase(IDbContextProvider<SAIC_FTSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
