using System.ComponentModel.DataAnnotations;

namespace WepApiEcommerceIDYGS91.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public ICollection<User> Users { get; set; }
    }
}
