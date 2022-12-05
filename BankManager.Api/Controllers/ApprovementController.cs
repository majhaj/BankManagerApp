using AutoMapper;
using BankManager.DataTransferObjects;
using BankManager.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankManager.Entities;
using BankManager.Services;
using BankManager.Services.Interfaces;

namespace BankManager.Api.Controllers
{
    [Route("api/approvements")]
    [ApiController]
    public class ApprovementController : ControllerBase
    {
        private readonly IMapper _mapper;

        public IApprovementService ApprovementService { get; }

        public ApprovementController(IApprovementService approvementService, IMapper mapper)
        {
            ApprovementService = approvementService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("allPendingApprovementsByApproverId")]
        public IEnumerable<ApprovementDto> GetAllPendingApprovementsByApproverId(int approverId)
        {
            var result = ApprovementService.GetAllPendingApprovementsByApproverId(approverId).Select(entity => _mapper.Map<ApprovementDto>(entity));
            return result;
        }

        [HttpGet]
        [Route("byApprovementId")]
        public ApprovementEntity GetByApprovementId(int approvementId)
        {
            var result = ApprovementService.GetByApprovementId(approvementId);
            return result;
        }

        [HttpPut]
        [Route("approve")]
        public void Approve(int approvalId)
        {
            ApprovementService.Approve(approvalId);
        }

        [HttpPut]
        [Route("reject")]
        public void Reject(int approvalId)
        {
            ApprovementService.Reject(approvalId);
        }
    }
}
