using System.ComponentModel.DataAnnotations;

namespace CrudForEntity.Dtos
{
    public class VehicleDto
    {
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
    }
}
