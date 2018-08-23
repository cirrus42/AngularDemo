using System.ComponentModel.DataAnnotations;

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
    }
}
