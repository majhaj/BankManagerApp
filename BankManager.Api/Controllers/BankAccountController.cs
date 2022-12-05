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
    [ApiController]
    [Route("/api/bankAccounts")]
    public class BankAccountController : ControllerBase
    {
        private readonly IMapper _mapper;

        public IBankAccountService BankAccountService { get; }

        public BankAccountController(IBankAccountService bankAccountService, IMapper mapper)
        {
            BankAccountService = bankAccountService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<BankAccountDetailsDto> Get()
        {
            return BankAccountService.GetAll().Select(entity => _mapper.Map<BankAccountDetailsDto>(entity));
        }

        [HttpGet]
        [Route("byId")]
        public BankAccountDetailsDto GetById(int id)
        {
            var entity = BankAccountService.GetById(id);

            return _mapper.Map<BankAccountDetailsDto>(entity);
        }


        [HttpPost]
        [Route("create")]
        //https://123.34.54.34:8080/BankManager/api/bankAccount?id=4768
        public BankAccountDetailsDto CreateAccount(BankAccountRequest request)
        {
            var createdEntity = BankAccountService.CreateAccount(_mapper.Map<BankAccountEntity>(request));
            var dto = _mapper.Map<BankAccountDetailsDto>(createdEntity);

            return dto;
        }

        [HttpPut]
        [Route("update")]
        public BankAccountDetailsDto UpdateAccount(BankAccountRequest request)
        {
            var createdEntity = BankAccountService.UpdateAccount(_mapper.Map<BankAccountEntity>(request));
            var dto = _mapper.Map<BankAccountDetailsDto>(createdEntity);

            return dto;
        }

        [HttpDelete]
        [Route("delete")]
        public int DeleteAccount(int bankAccountId)
        {
            BankAccountService.DeleteAccount(bankAccountId);
            return bankAccountId;
        }

        [HttpPut]
        [Route("block")]
        public bool BlockAccount(int accountId)
        {
            return true;
        }

        [HttpPut]
        [Route("unblock")]
        public bool UnblockAccount(int accountId)
        {
            return true;
        }
    }
}