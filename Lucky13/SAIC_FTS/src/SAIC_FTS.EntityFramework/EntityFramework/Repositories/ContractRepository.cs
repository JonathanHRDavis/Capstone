/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Abp.EntityFramework;
using SAIC_FTS.Models.Contracts;

namespace SAIC_FTS.EntityFramework.Repositories
{
    public class ContractRepository : SAIC_FTSRepositoryBase<Contract>, IContractRepository
    {
        public ContractRepository(IDbContextProvider<SAIC_FTSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        /*public List<Contract> GetemAll()
        {
            var query = GetAll(); 
            return query
                .ToList();
        }*/

        /*
        public List<Contract> GetAllWithContractNumber(int? contractNumber)
        {
            var query = GetAll();
            //System.Diagnostics.Debug.Print(query.GetType().ToString());

            if (contractNumber.HasValue)
            {
                query = query.Where(contract => contract.FullContractNum.Equals(contractNumber.Value));
            }
            //System.Diagnostics.Debug.WriteLine("Number of returned results: {0}", query.ToList().Count);
            return query
                //.Include(contract => contract.FullContractNum)
                .ToList();
        }
        */
        public List<Contract> GetAllWithContractNumber(string contractNumber)
        {
            var query = GetAll();

            
            if (contractNumber != null)
            {
                query = query.Where(contract => contract.FullContractNum.Equals(contractNumber));
            }
            

            //System.Diagnostics.Debug.WriteLine("Number of returned results: {0}", query.ToList().Count);
            return query
                //.Include(contract => contract.ContractNumber)
                .ToList();
        }

    }
}
