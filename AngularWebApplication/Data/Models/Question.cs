using System.ComponentModel.DataAnnotations;

namespace AngularWebApplication.Data.Models
{
    public class Question : BaseModel
    {
        [Required]
        public int QuizId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
