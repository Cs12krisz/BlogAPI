using Microsoft.EntityFrameworkCore.Storage.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models
{
    public class Blogger
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string? Name { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string? Email { get; set; }
        public DateTime RegTime { get; set; } = DateTime.Now;
        public DateTime ModTime { get; set; } = DateTime.Now;

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    }
}
