using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Security.Model
{
    public class User
    {
        [Key]
        [Column("id_user")]
        public int UserId { get; set; }        
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
