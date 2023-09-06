using System.ComponentModel.DataAnnotations;

namespace CrudForEntity.Dtos
{
    public class UserDto
    {
        [MaxLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(30)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(13)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
