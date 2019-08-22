using System;
using Abp.Application.Services.Dto;

namespace SAIC_FTS.Models.Contracts.Dtos
{
    public class ContractTextDto : EntityDto<long>
    {
		public string ContractNumber { get; set; }
		public string Contract { get; set; }
    }
}
