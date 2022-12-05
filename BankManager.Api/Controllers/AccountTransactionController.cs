
using BankManager.DataTransferObjects;
using BankManager.Services;
using BankManager.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BankManager.Api.Extensions;
using BankManager.Api.Requests;
using AutoMapper;
using BankManager.Entities;

namespace BankManager.Api.Controllers
{
    [Route("/api/accountTransactions")]
    [ApiController]
    public class AccountTransactionController : ControllerBase
    {
        private readonly IMapper _mapper;

        public IAccountTransactionService AccountTransactionService { get; }

        public AccountTransactionController(IAccountTransactionService accountTransactionService, IMapper mapper)
        {
            AccountTransactionService = accountTransactionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("byId")]
        public AccountTransactionDto GetById(int id)
        {
            var entity = AccountTransactionService.GetById(id);
            var result = _mapper.Map<AccountTransactionDto>(entity);

            return result;
        }

        [HttpGet]
        [Route("byAccountId")]
        public AccountTransactionDto GetByAccountId(int accountId)
        {
            var entity = AccountTransactionService.GetByAccountId(accountId);
            return _mapper.Map<AccountTransactionDto>(entity);
        }

        [HttpGet]
        [Route("byAccountOwnerId")]
        public AccountTransactionDto GetByAccountOwnerId(int accountOwnerId)
        {
            var entity = AccountTransactionService.GetByAccountOwnerId(accountOwnerId);
            return _mapper.Map<AccountTransactionDto>(entity);
        }

        [HttpPost]
        public AccountTransactionDto Create(AccountTransactionRequest request)
        {
            var createdEntity = AccountTransactionService.Create(_mapper.Map<AccountTransactionEntity>(request));
            var result = _mapper.Map<AccountTransactionDto>(createdEntity);
            return result;
        }

        [HttpPut]
        [Route("approve")]
        public void ApproveAccountTransaction(int approvementId, int approvedById)
        {
            AccountTransactionService.ApproveAccountTransaction(approvementId, approvedById);





        }

        [HttpPut]
        [Route("reject")]
        public void RejectAccountTransaction(int approvementId, int approvedById)
        {
            AccountTransactionService.RejectAccountTransaction(approvementId, approvedById);
        }
    }
}
