
using BankManager.DataAccess;
using BankManager.Entities;
using BankManager.Entities.Interfaces;
using BankManager.Services.Interfaces;

namespace BankManager.Services
{

    public class EmployeeService
    {
        public string SendEmployeeTypeChangedEmailNotification(EmployeeEntity employeeEntity)
        {
            return employeeEntity.Id.ToString();
        }

        public string SendEmployeeTypeChangedSmsNotification(EmployeeEntity employeeEntity)
        {
            return employeeEntity.Id.ToString();
        }

        public string ChangeApprovmentStatus(EmployeeEntity employeeEntity)
        {
            return employeeEntity.Id.ToString();
        }


        public void UpdateEmployee(EmployeeEntity newEmployeeData)
        {
            var userDbStorage = new EmployeeDbStorage();
            userDbStorage.Initialize();

            var origin = userDbStorage.Employees.FirstOrDefault(x => x.Id == newEmployeeData.Id);

            origin.FirstName = newEmployeeData.FirstName;
            origin.LastName = newEmployeeData.LastName;
            origin.Salary = newEmployeeData.Salary;
            origin.IsContractor = newEmployeeData.IsContractor;

            if (origin.EmployeeType != newEmployeeData.EmployeeType)
            {
                //newEmployeeData.EmployeeTypeChanged(newEmployeeData);

                //EventHandler temp = MyEvent;
                //if (temp != null)
                //{
                //    temp();
                //}
                //newEmployeeData.EmployeeTypeChanged.
            }
        }
    }
}
