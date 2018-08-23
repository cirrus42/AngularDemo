using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularWebApplication.Data.Models
{
    public class Result : BaseModel
    {
        [Required]
        public int QuizId { get; set; }
        [Required]
        public string Text { get; set; }

        public int? MinValue { get; set; }

        public int? MaxValue { get; set; }

        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }
    }
}
