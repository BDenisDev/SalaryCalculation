using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryApplication.DataBase
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Employe> Employees { get; set; }
    }
}
