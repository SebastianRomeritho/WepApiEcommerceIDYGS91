using System.Text.Json.Serialization;

namespace WepApiEcommerceIDYGS91.Models
{
    public partial class Category
    {
        public int IdCategory { get; set; }

        public string? NameCategory { get; set; }

        public string? DescriptionCategory { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
