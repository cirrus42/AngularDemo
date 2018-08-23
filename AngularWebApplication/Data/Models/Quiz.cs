using System.ComponentModel.DataAnnotations;

namespace AngularWebApplication.Data.Models
{
    public class Quiz : BaseModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }

        public int ViewCount { get; set; }
    }
}
