using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularWebApplication.Data.Models
{
    public class Answer : BaseModel
    {
        [Required]
        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Value { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
