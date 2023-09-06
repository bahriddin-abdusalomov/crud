using EntityCRUD.Models.Staffs;
using System.ComponentModel.DataAnnotations;

namespace EntityCRUD.Models.Vehicles;

public class Vehicle : BaseModel
{
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;

    public ICollection<User> Users { get; set; } = new List<User>();
}
