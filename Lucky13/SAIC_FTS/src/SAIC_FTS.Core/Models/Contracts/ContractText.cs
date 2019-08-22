using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
//using SimpleTaskSystem.People;

namespace SAIC_FTS.Models.Contracts
{
    public class ContractText : Entity
    {

        public string ContractNumber { get; set; }
        public string Contract { get; set; }

        //public string FileName { get; set; }

        public ContractText()
        {

        }

        public ContractText(string cNumber)
        {
            ContractNumber = cNumber;
        }
    }
}
