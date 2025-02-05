using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppDemo.Data.Model
{
    public class tblUser
    {
        [Key]
        [Column("RegistrationId")]
        public int RegistrationId { get; set; }
        public string ? UserType { get; set; }
        public string ? Name { get; set; }
        public string ? Emailid { get; set; }
        public string ? Gender { get; set; }
        public string ? State { get; set; }
        public string ? Password { get; set; }
  
    }

    public class UserRegistrationViewModel
    {
        public tblUser  User { get; set; }         
        public List<tblUser>? lstUsers { get; set; }  
    }


}
