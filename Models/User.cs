using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WepApiEcommerceIDYGS91.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address{ get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public int IsActive { get; set; }
        [JsonIgnore]
        public int RolId { get; set; }
        [ForeignKey("RolId")]
        [JsonIgnore]
        [NotMapped]
        public Rol? Rol { get; set; }
    }
}
