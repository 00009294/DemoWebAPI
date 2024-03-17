using Newtonsoft.Json;

namespace DemoMVC.Models
{
    public class SwaggerResponse<T>
    {
        public List<T> Result { get; set; }
    }
}
