using BankManager.DataTransferObjects;
using BankManager.Services;
using BankManager.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BankManager.Api.Extensions;
using AutoMapper;
using BankManager.Entities;

namespace BankManager.Api.Controllers
{
    [ApiController]
    [Route("/api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly IMapper _mapper;

        public INotificationService NotificationService { get; }

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            NotificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/byUser")]
        public IEnumerable<NotificationDto> GetAllNotificationsByAppForUser(int userId)
        {
            return NotificationService.GetAllNotificationsByAppForUser(userId).Select(entity => _mapper.Map<NotificationDto>(entity));
        }

        [HttpPut]
        [Route("/changeNotificationState")]
        public void ChangeNotificationState(IEnumerable<int> notificationIds)
        {
            NotificationService.ChangeNotificationState(notificationIds);
        }

        //[HttpPut]
        //public BankAccountDetailsDto UpdateAccount(BankAccountRequest request)
        //{
        //    var createdEntity = BankAccountService.UpdateAccount(_mapper.Map<BankAccountEntity>(request));
        //    var dto = _mapper.Map<BankAccountDetailsDto>(createdEntity);

        //    return dto;
        //}
    }
}