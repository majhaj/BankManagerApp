namespace BankManager.DataTransferObjects
{
    public static class Extensions
    {
        public static string PrepareFormattedMessage(this BankAccountDetailsDto bankAccountDetailsDto)
        {
            return $"Account id: {bankAccountDetailsDto.Id}; Account number: {bankAccountDetailsDto.Number}; Owner: {bankAccountDetailsDto.OwnerFormattedData}";
        }

        public static bool Validate(this BankAccountDetailsDto bankAccountDetailsDto)
        {
            return true;
        }

        //public static BankAccountDetailsDto ConfigureFirstApprover(this BankAccountDetailsDto bankAccountDetailsDto, string firstApproverNumber)
        //{
        //    bankAccountDetailsDto.FirstApproverNumber = firstApproverNumber;

        //    return bankAccountDetailsDto;
        //}

        //public static BankAccountDetailsDto ConfigureSecondApprover(this BankAccountDetailsDto bankAccountDetailsDto, string secondApproverNumber)
        //{
        //    ////////
        //    bankAccountDetailsDto.SecondApproverNumber = secondApproverNumber;

        //    return bankAccountDetailsDto;
        //}

        //public static BankAccountDetailsDto ConfigureThirdApprover(this BankAccountDetailsDto bankAccountDetailsDto, string thirdApproverNumber)
        //{
        //    ////////
        //    bankAccountDetailsDto.ThirdApproverNumber = thirdApproverNumber;

        //    return bankAccountDetailsDto;
        //}





        public static string PrepareFormattedMessage(this SimpleBankAccountDto simpleBankAccountDto)
        {
            return $"Account id: {simpleBankAccountDto.Id}; Account number: {simpleBankAccountDto.Number};";
        }
    }
}
