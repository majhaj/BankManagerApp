// See https://aka.ms/new-console-template for more information
using BankManager.BusinessLogic;
using BankManager.BusinessModels;
using BankManager.DataAccess;
using BankManager.DataTransferObjects;
using BankManager.Entities;
using BankManager.Entities.Interfaces;
using BankManager.Services;
using MyFirstConsoleApp.GenericTypes;
using System;
using static BankManager.Entities.EmployeeEntity;

Console.WriteLine("Hello, World!");

Console.WriteLine("Start");


var bankAccountDetailsDto = new BankAccountDetailsDto
{
    Id = 234,
    Number = "3465346534563465",
    Balance = 4654654,
    OwnerFormattedData = "Jan Nowak"
};

var formatted = bankAccountDetailsDto.PrepareFormattedMessage();
bankAccountDetailsDto.Validate();


//bankAccountDetailsDto
//    .ConfigureFirstApprover("34523452345")
//    .ConfigureSecondApprover("23452346456")
//    .ConfigureThirdApprover("23452345234523");



List<DateTime> employeeBirtDates = new List<DateTime>()
{
    new DateTime(1965, 1, 4),
    new DateTime(1978, 12, 22),
    new DateTime(1984, 11, 21),
    new DateTime(1983, 9, 14),
    new DateTime(1999, 8, 17),
    new DateTime(1999, 5, 21),
    new DateTime(2001, 6, 19),
    new DateTime(2002, 4, 6),
    new DateTime(1990, 3, 23),
    };

//a) użyj instrukcji foreach do wyświetlanie na ekranie pracowników urodzonych przed 01.01.1990 rokiem
var verifiedDate = new DateTime(1999, 01, 01);
foreach (var birthday in employeeBirtDates)
{
    if (birthday < verifiedDate)
    {
        Console.WriteLine(birthday.ToString());
    }
}

//b) użyj instrukcji foreach do znalezienia najstarszego pracownika
DateTime oldestEmployeeBirthdate = DateTime.Now;
foreach (var birthday in employeeBirtDates)
{
    if (birthday < oldestEmployeeBirthdate)
    {
        oldestEmployeeBirthdate = birthday;
    }
}

Console.WriteLine(oldestEmployeeBirthdate.ToString());


//c) użyj instrukcji foreach aby sprawdzić czy istnieją pracownicy urodzenie w tym samym roku


List<YearCounter> yearsCounter = new List<YearCounter>();

foreach (var birthday in employeeBirtDates)
{
    var counter = YearCounter.GetYearCounter(birthday.Year, yearsCounter);
    if (counter == null)
    {
        yearsCounter.Add(new YearCounter() { Year = birthday.Year, Counter = 1 });
    }
    else
    {
        counter.Counter += 1;
    }
}

foreach (var yearCounter in yearsCounter)
{
    if (yearCounter.Counter > 1)
    {
        Console.WriteLine(yearCounter.Year);
    }
}

//e) użyj instrukcji foreach zwrócenia daty najbliższych urodzin pracownika
List<DateDifferential> dateDifferentials = new List<DateDifferential>();
var currentDate = DateTime.Now;
foreach (var birthday in employeeBirtDates)
{
    dateDifferentials.Add(new DateDifferential() { CurrentDate = currentDate, VerifyDate = birthday });
}

var result = DateDifferential.GetNearestDifferential(dateDifferentials);

Console.WriteLine(result.VerifyDate.ToString());


var userDbStorage = new EmployeeDbStorage();
userDbStorage.Initialize();

var allEmployees = userDbStorage.Employees;

var x = allEmployees.Select(x => x.GetEmployeeDescription());
var firstEmployee = allEmployees.FirstOrDefault();

var allShiftLeaders = allEmployees.Where(employeeEntity =>
{
    return true;
});

var contractors = allEmployees.Where(x => x.IsContractor.HasValue && x.IsContractor.Value);

IEnumerable<EmployeeEntity> Filter(Func<EmployeeEntity, bool> filtrationMethod)
{
    var result = new List<EmployeeEntity>();
    foreach (var employeeEntity in allEmployees)
    {
        if (filtrationMethod(employeeEntity))
        {
            result.Add(employeeEntity);
        }
    }

    return result;
}

bool CheckIsShiftLeader(EmployeeEntity employeeEntity)
{
    return employeeEntity.EmployeeType == EmployeeType.ShiftLeader;
}

var xxxxx = allEmployees.Where(CheckIsShiftLeader);


bool CheckIsContractor(EmployeeEntity employeeEntity)
{
    return employeeEntity.IsContractor.HasValue && employeeEntity.IsContractor.Value;
}

var xxx34563463xx = allEmployees.Where(CheckIsContractor);

var contractorsByLambda = allEmployees.Where(x => x.IsContractor.HasValue && x.IsContractor.Value);

var allWithRetirement =
    allEmployees.Where(x => x.Birthday <= DateTime.Now.AddYears(-65))
    .Select(employeeEntity => new { employeeEntity.Id, employeeEntity.Email, employeeEntity.Salary });


allEmployees.Where(x => x.Id == 124);

//var result = allEmployees.All(x => x.Birthday > DateTime.Now.AddYears(-65));





bool IsContractor(EmployeeEntity employee)
{
    return employee.IsContractor.Value;
}

bool IsActive(EmployeeEntity employee)
{
    return employee.IsActive;
}

bool HasSalaryAboveAverage(EmployeeEntity employee)
{
    return employee.Salary > 5000;
}


BankAccountEntity GetEmployeeBankAccount(EmployeeEntity employee, BankEntity bank)
{
    return new BankAccountEntity();
}

Func<EmployeeEntity, bool> checkEmployeeConditionsDelegate = new Func<EmployeeEntity, bool>(IsContractor);
checkEmployeeConditionsDelegate += IsActive;
checkEmployeeConditionsDelegate += HasSalaryAboveAverage;



bool checkEmployeeResult = checkEmployeeConditionsDelegate(firstEmployee);








Func<EmployeeEntity, BankEntity, DateTime, CurrencyEntity, bool> predicate2;
Func<EmployeeEntity, BankEntity, BankAccountEntity> werjkglnwerjkgwe;


var employeeService = new EmployeeService();

firstEmployee.EmployeeTypeChanged += employeeService.SendEmployeeTypeChangedSmsNotification;
firstEmployee.EmployeeTypeChanged += employeeService.SendEmployeeTypeChangedEmailNotification;
firstEmployee.EmployeeTypeChanged += employeeService.ChangeApprovmentStatus;


#region Old examples
/*
 * 



//Sekcja deklaracji zminennych
int id;
string firstName;
string lastName;
string email;
string phoneNumber;
string city;
string country;
double multiplier;
DateTime birthday;
bool isContractor = true;

//Sekcja inicjalizacji zminennych

//user user0 = new user()
//{
//    FirstName = "Eugeniusz",
//    LastName = "Kowalski",
//    Email = "janusz.kowalski@gmail.com",
//    Id = 12789,
//    Birthday = new DateTime(2007, 12, 12)
//};

UserEntity user0 = new UserEntity();
user0.FirstName = "Eug";
user0.LastName = "";

UserEntity user1 = new UserEntity()
{
    FirstName = "Eugeniusz",
    LastName = "Kowalski",
    Email = "janusz.kowalski@gmail.com",
    Id = 12789,
    Birthday = new DateTime(2007, 12, 12)
};



string userDescription = user1.GetUserDescription();
UserEntity xxxxxx = user1;

SimpleBankAccountDto primaryBankAccount = new SimpleBankAccountDto();
primaryBankAccount.Number = "3453456345634567456734674567";

UserEntity userA = new UserEntity();

userA.GetUserDescription();
userA.Id = 12343;
userA.FirstName = "Eugeniusz";
userA.LastName = "Kowalski";
userA.Email = "janusz.kowalski@gmail.com";
userA.Birthday = new DateTime(1993, 12, 14);
userA.IsContractor = null;

var x = userA.GetUserDescription();

//save

userA.Email = "irek.kowalski@gmail.com";
//save

UserEntity userCreator = new UserEntity(34332, "Andrzej", "Kowal", "andiejs.novak@gmail.com", new DateTime(1980, 12, 01), false);

UserEntity userX = new UserEntity
{
    Id = 12343,
    FirstName = "Eugeniusz",
    LastName = "Kowalski",
    Email = "janusz.kowalski@gmail.com",
    Birthday = new DateTime(1993, 12, 14),
    IsContractor = false,

};

string userBDescription = userCreator.GetUserDescription();
Console.WriteLine(userBDescription);


string xxx = $"{userA.FirstName} {userA.Birthday:dd-MM-YYYY} {userA.LastName}";


id = 12790;
firstName = "Eugeniusz I";
lastName = "Nowakowski";
city = "Radzionkow";
country = "Polska";
firstName = "Janusz";
lastName = "Nowakowski";
email = "janusz.nowakowski@gmail.com";
phoneNumber = "345-434-465";
multiplier = 1.87;
birthday = new DateTime(1993, 12, 14);

Console.WriteLine($"Nasz nowy pracownik: {firstName} {lastName}");
Console.WriteLine($"Miasto {city}, email {email}, phone number  {phoneNumber}");
Console.WriteLine($"Nasz nowy pracownik: {firstName} {lastName} podwykonawca: {isContractor}");
Console.WriteLine($"Nasz nowy pracownik: {firstName} {lastName} podwykonawca: {isContractor}");
Console.WriteLine($"Nasz nowy pracownik: {firstName} {lastName} podwykonawca: {isContractor}");

////////////////////////////////////////LEKCAJ 3///////////////////////////////////////////

var bankAccount2 = new BankAccountEntity();
bankAccount2.Id = 2;
bankAccount2.Number = "2342342";
bankAccount2.Owner = user1;
bankAccount2.Interest = 2.3456456445645m;
bankAccount2.Balance = 1.34564456456456;
bankAccount2.CreationDate = new DateTime(1900, 1, 1);
bankAccount2.DeletionDate = new DateTime(2021, 12, 31);

var creationProcessDescription = bankAccount2.GetCreationProcessDescription();

var firstBank = new BankEntity();
firstBank.Name = "ING";
firstBank.Id = 1;
firstBank.CreationDate = new DateTime(1900, 01, 01);
firstBank.CreatorId = 34332;
firstBank.Creator = userA;

var secondBank = new BankEntity();
secondBank.Name = "MBANK";
secondBank.Id = 2;
secondBank.CreationDate = new DateTime(1900, 01, 01);
secondBank.CreatorId = 34332;
secondBank.Creator = userA;

var thirdBank = new BankEntity();
thirdBank.Name = "Santander";
thirdBank.Id = 3;
thirdBank.CreationDate = new DateTime(1900, 01, 01);
thirdBank.CreatorId = 34332;
thirdBank.Creator = userCreator;

creationProcessDescription = firstBank.GetCreationProcessDescription();

var bankAccount = new BankAccountEntity();
bankAccount.Id = 1;
bankAccount.Number = "43534536345634653465";
bankAccount.Owner = user1;
bankAccount.Interest = 3.5m;
bankAccount.Balance = 5600;
bankAccount.CreationDate = new DateTime(2022, 01, 01);
bankAccount.CreatorId = 34332;
bankAccount.Creator = userCreator;
bankAccount.Bank = firstBank;


creationProcessDescription = bankAccount.GetCreationProcessDescription();

List<BankEntity> banks = new List<BankEntity>();
banks.Add(firstBank);
banks.Add(secondBank);
banks.Add(thirdBank);

var mbank = banks.FirstOrDefault(x => x.Name == "MBANK");
mbank = banks.FirstOrDefault(x => x.Id == 2);

var allBanksCreatedBy = banks.Where(x => x.Creator.LastName == "Kowalski");


foreach (var item in banks)
{
    Console.WriteLine(item.GetCreationProcessDescription());
}

List<IEntity> entities = new List<IEntity>();

entities.Add(user0);
entities.Add(bankAccount);
entities.AddRange(banks);

foreach (var entity in entities)
{
    Console.WriteLine(entity.GetCreationProcessDescription());
}

creationProcessDescription = bankAccount.GetCreationProcessDescription();


////////////////////////////////////////LEKCAJ 4///////////////////////////////////////////
///

var company = new SmallCompany() { CompanyId = 1, Income = 2000000, Name = "ING" };
var asianTaxService = new AsianTaxService
{
    CountryId = 1,
};

var ueTaxService = new UeTaxService
{
    CountryId = 2,
};

var intTable = new int[] { 1, 4, 7, 12, 567, 2, 6, 8, 18 };
var taxCalculator = new TaxCalculator
{
    Company = company,
};

var globalTax = taxCalculator.Calculate(ueTaxService) + taxCalculator.Calculate(asianTaxService);

string xyuityui = "";

List<DateTime> employeeBirtDates = new List<DateTime>()
{
    new DateTime(1965, 1, 4),
    new DateTime(1978, 12, 22),
    new DateTime(1984, 111, 21),
    new DateTime(1983, 9, 14),
    new DateTime(1999, 8, 17),
    new DateTime(1998, 5, 21),
    new DateTime(2001, 6, 19),
    new DateTime(2002, 4, 6),
    new DateTime(1990, 3, 23),

};

*/

#endregion