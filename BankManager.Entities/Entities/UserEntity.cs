using System.Text.RegularExpressions;

namespace BankManager.Entities
{
    public class UserEntity : EntityDeletable
    {
        #region Constraints
        //Stale wykorzystujemy na potrzeby przechowywania wartosci niezmiennych dla klasy
        private const string _employeeFactoryName = "HTC Company";
        private const string _emaliValidationRegex = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
        #endregion

        #region Private fields 
        //Prywatne pola - są wykorzystywane do przechowywania wartości, tak aby ich modyfikacja mogła się odbywać tylko za pośrednictwem właściwości
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthday;
        #endregion

        #region Constructors
        public UserEntity()
        {
        }

        public UserEntity(int id, string firstName, string lastName, string email, DateTime birthday, bool isContractor)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Birthday = birthday;
            IsContractor = isContractor;
        }
        #endregion

        #region Public Properties

        //Zapis skrócony - w rzeczywistości dla każdej tak zadeklarowanej właściwości kompilator tworzy prywatne pole i odczyt oraz przypisanei wartości odbywa się tylko za
        //pośrednictwem gettera i settera
        //public string FirstName { get; set; }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                }
            }
        }
        public string LastName { get; set; }
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    //Sprawdz poprawnoes meila wyrazeniem regularnym

                    if (value != null && value.Length > 0)// && Regex.IsMatch(value, _emaliValidationRegex))
                    {
                        _email = value;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid email value");
                    }
                }
            }
        }
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if (_birthday != value)
                {
                    if (value >= new DateTime(1900, 01, 01))
                    {
                        _birthday = value;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid employee birthday");
                    }
                }
            }
        }
        public bool? IsContractor { get; set; }

        public virtual ICollection<BankAccountEntity> BankAccounts { get; set; }
        public virtual ICollection<BankAccountEntity> CreatedBankAccounts { get; set; }
        public virtual ICollection<AccountTransactionEntity> CreatedAccountTransactions { get; set; }
        public virtual ICollection<NotificationEntity> CreatedNotifications { get; set; }
        public virtual ICollection<TransactionTypeEntity> CreatedTransactionTypes { get; set; }
        public virtual ICollection<ApprovementTypeEntity> CreatedApprovementTypes { get; set; }
        public virtual ICollection<ApprovementEntity> Approvements { get; set; }
        public virtual ICollection<ApprovementEntity> CreatedApprovements { get; set; }

        #endregion

        #region Public Methods
        //Metody opatrzone modyfikatorem dostępu public - są dostępne z zewnątrz (!)
        public string GetUserDescription()
        {
            string formattedDescription = $"{_employeeFactoryName} Employee: {FirstName} {LastName} with email: {Email}, contractor: ";

            //formattedDescription = formattedDescription + GetYesNoContractorDescription(IsContractor);

            formattedDescription += GetYesNoContractorDescription(IsContractor);

            return formattedDescription;
        }

        //public string SendEmailNotification()
        //{
        //    if (Email == null)
        //    {
        //        return;
        //    }

        //    //emailService.Send(Email, new EmailMessage());
        //}

        #endregion

        #region Private Methods
        //Metody opatrzone modyfikatorem dostępu public - są dostępne z wnętrza klasy (!)
        private string GetYesNoContractorDescription(bool? isContractorFlag)
        {
            string result;
            if (isContractorFlag.HasValue)
            {
                if (isContractorFlag.Value)
                {
                    result = "YES";
                }
                else
                {
                    result = "NO";
                }
            }
            else
            {
                result = "NOT SET";
            }

            return result;
        }
        #endregion

        #region Delegates
        public delegate int PersonCreatedDelegate(UserEntity person);
        #endregion

        #region Events
        public event PersonCreatedDelegate PersonCreated;
        #endregion
    }
}
