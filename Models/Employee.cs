using System.ComponentModel.DataAnnotations.Schema;

namespace EDP_WebAPI_Security.Models
{
    public class Employee
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("salary")]
        public decimal Salary { get; set; }

        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
    }
}
