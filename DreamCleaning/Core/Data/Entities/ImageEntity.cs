using System.ComponentModel.DataAnnotations;

namespace DC.WebApi.Core.Data.Entities
{
    public class ImageEntity
    {
        [Key]
        long Id { get; set; }
        public string URI { get; set; }
    }
}
