using BankManager.Api.Requests;
using BankManager.DataTransferObjects;
using BankManager.Entities;

namespace BankManager.Api.Extensions
{
    public static class MapperExtension
    {
        public static BankAccountDetailsDto MapToDto(this BankAccountEntity entity)
        {
            var dto = new BankAccountDetailsDto
            {
                Id = entity.Id,
                Number = entity.Number,
                Balance = entity.Balance,
                OwnerFormattedData = "Owner"
            };

            return dto;
        }

        public static BankAccountEntity MapToDEntity(this BankAccountRequest request)
        {
            var dto = new BankAccountEntity
            {
                Id = request.Id,
                BankId = request.BankId,
            };

            return dto;
        }
    }
}
