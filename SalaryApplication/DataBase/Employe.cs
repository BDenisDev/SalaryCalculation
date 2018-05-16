using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryApplication.DataBase
{
    [Table("Employe")]
    public class Employe
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string EmployeeType { get; set; }

        public DateTime EnrollmentDate { get; set; }    

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]

        public virtual Company Company { get; set; }
    }
}
