using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApplication.Models
{
    class EmployeeModel : EmployeeBase
    {
        public override double CalculateSalary(DateTime enrollmentDate, double baseRate)
        {
            var experience = DateTime.Now.Year - enrollmentDate.Year;

            if (experience == 0)
            {
                Salary = baseRate;
                return Salary;
            }

            else if (experience <= 10)
            {
                Salary = (baseRate + (baseRate * 0.03 * experience));
                return Salary;
            }

            else if (experience > 10)
            {
                Salary = (baseRate + (baseRate * 0.03 * 10));
                return Salary;
            }
            else
                return 0;
        }
    }
}
