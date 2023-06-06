namespace Application.Models
{
    public class UpdateImageDto
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
