using System.Text.RegularExpressions;

namespace BankManager.Entities
{
    public class EmployeeEntity : EntityDeletable
    {
        #region Constraints
        private const string _employeeFactoryName = "HTC Company";
        #endregion

        #region Constructors
        public EmployeeEntity()
        {
        }

        public EmployeeEntity(int id, string firstName, string lastName, string email, DateTime birthday, bool isContractor)
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public bool? IsContractor { get; set; }
        public DateTime? ModificationDate { get; set; }

        public EmployeeType EmployeeType { get; set; }
        public decimal Salary   { get; set; }

        #endregion

        #region Public Methods
        //Metody opatrzone modyfikatorem dostępu public - są dostępne z zewnątrz (!)
        public string GetEmployeeDescription()
        {
            string formattedDescription = $"{_employeeFactoryName} Employee: {FirstName} {LastName} with email: {Email}, contractor: ";

            //formattedDescription = formattedDescription + GetYesNoContractorDescription(IsContractor);

            formattedDescription += GetYesNoContractorDescription(IsContractor);

            return formattedDescription;
        }
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
        public delegate string EmployeeTypeChangeDelegate(EmployeeEntity employee);
        public delegate void EmployeEmailChangedDelegate(EmployeeEntity employee);

        public delegate void TrackToPlaylistAddedDelegate(int trackId, int playlistId);
        #endregion

        #region Events
        public event EmployeeTypeChangeDelegate EmployeeTypeChanged;
        public event EventHandler<EmployeeEntity> EmployeeTypeUpdated;


        public event EmployeEmailChangedDelegate EmployeEmailChanged;
        public event TrackToPlaylistAddedDelegate TrackToPlaylistAdded;
        #endregion
    }

    public enum EmployeeType
    {
        LineWorker = 10,
        LineManager = 20,
        ShiftLeader = 30,
        TeamLeader = 40,
        Manager = 50,
        Director = 60,
        BoardMember = 70
    }
}
