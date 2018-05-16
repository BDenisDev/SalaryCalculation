using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApplication.Models
{
    class SalesmanModel : EmployeeBase
    {
        public List<EmployeeBase> Employees { get; set; }
        public override double CalculateSalary(DateTime enrollmentDate, double baseRate)
        {
            var experience = DateTime.Now.Year - enrollmentDate.Year;

            if (experience == 0)
            {
                Salary = baseRate;
                return Salary;
            }

            else if (experience <= 35)
            {
                Salary = (baseRate + (baseRate * 0.01 * experience));
                return Salary;
            }

            else if (experience > 35)
            {
                Salary = (baseRate + (baseRate * 0.01 * 35));
                return Salary;
            }
            else
                return 0;
        }
    }
}
