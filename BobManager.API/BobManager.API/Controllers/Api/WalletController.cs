using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BobManager.Domain.Services.Abstraction;
using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BobManager.API.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService walletService;

        public WalletController(IWalletService _walletService)
        {
            walletService = _walletService;
        }

        [HttpGet]
        public Task<CollectionResultDto<SpendingDto>> GetSpendings()
        {
            
                return walletService.GetSpendigs();
            
        }
    }
}