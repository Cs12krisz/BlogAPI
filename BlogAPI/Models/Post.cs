using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCommentEnable { get; set; } = true;
        public string Author { get; set; }
        public DateTime Regtime { get; set; } = DateTime.Now;
        public DateTime ModTime { get; set; } = DateTime.Now;

        public int BloggerId { get; set; }

        public virtual Blogger Bloggers { get; set; }

    }
}
