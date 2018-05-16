using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryApplication.Enums;

namespace SalaryApplication.Models
{
    public abstract class EmployeeBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public EmployeeType Type { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public double BaseRate { get; set; }

        public int CompanyId { get; set; }
        public double Salary { get; set; }
        public abstract double CalculateSalary(DateTime enrollmentDate, double baseRate);
    }
}
