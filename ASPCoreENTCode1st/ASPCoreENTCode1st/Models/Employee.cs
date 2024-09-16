using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreENTCode1st.Models
{
    public class Employee
    {
        [Key]
        [Column("EmpId")]
        public int ID { get; set; }
        [Column("EmpName",TypeName ="nvarchar(100)")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("EmpEmail",TypeName ="nvarchar(100)")]
        [Required]
        //[RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        //ErrorMessage = "Email is required and must be properly formatted.")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column("EmpContact",TypeName ="nvarchar(12)")]
        [Required]
        public string Contact { get; set; }
        [Column("EmpAddress",TypeName ="nvarchar(100)")]
        [Required]
        [StringLength(100)]
        public string Address { get; set; }

    }
}
