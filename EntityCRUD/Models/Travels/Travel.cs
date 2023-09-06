using EntityCRUD.Models.Staffs;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCRUD.Models.Travels;

public class Travel : BaseModel
{
    public decimal Price { get; set; }
    public string Description { get; set;} = string.Empty;

    [ForeignKey(nameof(UserID))]
    public int UserID { get; set; }
    public User Users { get; set; } = null!;
}
