using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class ProductViewModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [Required]
        [JsonProperty("name")]
        [DisplayName("Product Name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
