using BankManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.DataAccess
{
    public class EmployeeDbStorage
    {
        private List<EmployeeEntity> _employees;
        public List<EmployeeEntity> Employees => _employees;

        public List<EmployeeEntity> Initialize()
        {
            _employees = GetRandomData();
            return _employees;
        }

        public void AddEmployee(EmployeeEntity Employee)
        {
            _employees.Add(Employee);
        }

        private List<EmployeeEntity> GetRandomData()
        {
            var result = new List<EmployeeEntity>();
            for (int i = 0; i < 500; i++)
            {
                var id = i + 100;
                result.Add(CreateEmployee(id));
            }

            return result;
        }

        private EmployeeEntity CreateEmployee(int id)
        {
            var name = GetRandomName();
            var surname = GetRandomSurname();
            var employeeType = GetRandomEmployeeType();
            var salary = GetRandomSalary(employeeType);

            return new EmployeeEntity()
            {
                Id = id,
                FirstName = $"{name}",
                LastName = $"{surname}",
                Birthday = new DateTime(GetRandomYear(), GetRandomMonth(), GetRandomDay()),
                //CreatorId = id,
                CreationDate = new DateTime(2021, GetRandomMonth(), GetRandomDay()),
                Email = $"{name}.{surname}_{id}@gmail.com",
                IsContractor = false,
                EmployeeType = employeeType,
                Salary = salary
            };
        }

        private string GetRandomName()
        {
            var random = new Random();
            var list = new List<string> { "Jan", "Andrzej", "Konrad", "Mathew", "Lech", "Wacław", "Michał", "Leon", "Matthias", 
                "Julia", "Klaudia", "Jeniffer", "Vanessa", "Anna", "Mia", "Jolanda" };
            int index = random.Next(list.Count);
            return list[index];
        }

        private static string GetRandomSurname()
        {
            var random = new Random();
            var list = new List<string> { "Kowalski", "Nowak", "Popiel", "Cohen", "Van der Poel" };
            int index = random.Next(list.Count);
            return list[index];
        }

        private EmployeeType GetRandomEmployeeType()
        {
            var random = new Random();
            var list = new List<EmployeeType> { EmployeeType.LineWorker, EmployeeType.LineManager, EmployeeType.ShiftLeader, EmployeeType.TeamLeader, EmployeeType.Manager, EmployeeType.Director, EmployeeType.BoardMember};
            int index = random.Next(list.Count);
            return list[index];
        }

        private decimal GetRandomSalary(EmployeeType employeeType)
        {
            var random = new Random();
            switch (employeeType)
            {
                case EmployeeType.LineWorker:
                    return random.Next(3600, 4200);
                case EmployeeType.LineManager:
                    return random.Next(4300, 5200);
                case EmployeeType.ShiftLeader:
                    return random.Next(5200, 6000);
                case EmployeeType.TeamLeader:
                    return random.Next(6000, 9000);
                case EmployeeType.Manager:
                    return random.Next(9000, 12000);
                case EmployeeType.Director:
                    return random.Next(18000, 24000);
                case EmployeeType.BoardMember:
                    return random.Next(30000, 42000);
                default:
                    return random.Next(3600, 4200);
            }
        }

        private static int GetRandomDay()
        {
            var random = new Random();
            return random.Next(1, 28);
        }

        private static int GetRandomMonth()
        {
            var random = new Random();
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int index = random.Next(list.Count);
            return list[index];
        }

        private static int GetRandomYear()
        {
            var random = new Random();
            return random.Next(1950, 2004);
        }
    }
}
