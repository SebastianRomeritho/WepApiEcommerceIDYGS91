using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WepApiEcommerceIDYGS91.Models
{
    public partial class Product
    {
        public int IdProduct { get; set; }

        public string? NameProduct { get; set; }

        public string? DescriptionProduct { get; set; }

        public int? IdCategory {  get; set; }
        
        public string ImageProduct { get; set; }

        public int? Stock { get; set; }

        public decimal? Price { get; set; }

        public bool? IsActive { get; set; }

        [JsonIgnore]
        public virtual Category? oCategory { get; set; }
    }
}
