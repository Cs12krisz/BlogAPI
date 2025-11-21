namespace BlogAPI.Models.Dtos
{
    public class AddPostDto
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int BloggerID { get; set; }
    }
}
