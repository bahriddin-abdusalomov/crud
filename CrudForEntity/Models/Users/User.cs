using EntityCRUD.Models.Travels;
using EntityCRUD.Models.Vehicles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCRUD.Models.Staffs;

public class User : BaseModel
{
    [MaxLength(30)] 
    public string FirstName { get; set; } = string.Empty; 

    [MaxLength(30)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    //[ForeignKey(nameof(VehicleID))]
    //public int VehicleID { get; set; }
    //public Vehicle Vehicles { get; set; } = null!;

    //[ForeignKey(nameof(TravelID))]
    //public int TravelID { get; set; }
    //public Travel Travels { get; set; } = null!;

}
