namespace CrudForDapper.Models
{
    public class Courses : BaseModel
    {
        public string CourseName { get; set; } = string.Empty;
        public long StudentId { get; set; }
    }
}
