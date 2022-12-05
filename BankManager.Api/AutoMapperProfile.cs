using AutoMapper;
using BankManager.Api.Requests;
using BankManager.DataTransferObjects;
using BankManager.Entities;

namespace BankManager.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApprovementEntity, ApprovementDto>()
                .ForMember(dest => dest.Approver, opt => opt.MapFrom(src => src.Approver));


            CreateMap<BankAccountEntity, BankAccountDetailsDto>();
            CreateMap<BankAccountDetailsDto, BankAccountEntity>();
            CreateMap<BankAccountRequest, BankAccountEntity>();

            CreateMap<AccountTransactionEntity, AccountTransactionDto>()
                .ForMember(dest => dest.Approvements, opt => opt.MapFrom(src => src.AccountTransactionApprovements.Select(x => x.Approvement)));


            CreateMap<AccountTransactionDto, AccountTransactionEntity>();
            CreateMap<AccountTransactionRequest, AccountTransactionEntity>();


            CreateMap<NotificationEntity, NotificationDto>();

            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, UserRequest>();
            CreateMap<UserRequest, UserEntity>();

            
        }
    }
}
