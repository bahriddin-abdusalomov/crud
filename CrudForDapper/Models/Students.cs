namespace CrudForDapper.Models
{
    public class Students : BaseModel
    {
        public string FristName { get; set; }  = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public long CourseId { get; set; }
    }
}
